using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;

namespace _2DGame
{

    public class Game1 : Game
    {
        public Camera camera;
        public Song music;

        public static bool fullScreen;
        public static bool editMode;
        public static bool gameRunning;

        public static GraphicsDevice graphicsDevice;
        public static ContentManager contentManager;
        public static InputHandler inputHandler;
        GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;
        SpriteEffects spriteEffects;
        public static int windowWidth;
        public static int windowHeight;

        Texture openingScreen;

        DarkForest df_level;
        SpriteFont f;
        Texture2D pixel;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            contentManager = Content;
            contentManager.RootDirectory = "Content";
            inputHandler = new InputHandler();           
        }


        public void ToggleEditMode()
        {
            if(!editMode)
            {
                IsMouseVisible = true;
                editMode = true;
            }
            else
            {
                IsMouseVisible = false;
                editMode = false;
            }          
        }


        public void DrawCrossHair()
        {
            Rectangle vertical = new Rectangle(inputHandler.GetCurrentMouse().Position.X, 0, 1, windowHeight);
            Rectangle horizontal = new Rectangle(0,inputHandler.GetCurrentMouse().Position.Y, windowWidth, 1);
            
            spriteBatch.Draw(pixel, vertical, Color.Red);
            spriteBatch.Draw(pixel, horizontal, Color.Red);
        }


        public void ShowCursorPos()
        {           
            spriteBatch.DrawString(f, (inputHandler.GetCurrentMouse().Position.X + camera.GetPosition().X) + "," + (inputHandler.GetCurrentMouse().Position.Y + camera.GetPosition().Y), new Vector2(100,100), Color.White);
        }


        public void ToggleFullScreen()
        {
            if(fullScreen)
            {
                graphics.PreferredBackBufferWidth = windowWidth;
                graphics.PreferredBackBufferHeight = windowHeight;
                graphics.IsFullScreen = false;
                fullScreen = false;
            }
            else
            {
                graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
                graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
                graphics.IsFullScreen = true;
                fullScreen = true;
            }

            graphics.ApplyChanges();
        }


        protected override void Initialize()
        {
            base.Initialize();
            music = contentManager.Load<Song>("shock_wave");
            MediaPlayer.Play(music);
            MediaPlayer.IsRepeating = true;

            openingScreen = Texture.Create("open");
            gameRunning = false;
            windowWidth = 1200;
            windowHeight = 900;
            graphicsDevice = GraphicsDevice;
            fullScreen = false;
            camera = new Camera(new Vector2(0, 0), 250);
            df_level = new DarkForest(camera);
            graphics.PreferredBackBufferWidth = windowWidth;
            graphics.PreferredBackBufferHeight = windowHeight;
            f = contentManager.Load<SpriteFont>("arial");
            pixel = contentManager.Load<Texture2D>("pixel");
            editMode = true;
            graphics.ApplyChanges();
        }


        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            spriteEffects = new SpriteEffects();                                             
        }


        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }


        protected override void Update(GameTime gameTime)
        {         
            inputHandler.Update();        
                         
            if(inputHandler.KeyPressed(Keys.Space))
            {
                gameRunning = true;
            }

            if(gameRunning)
            { 
                df_level.Update(gameTime);
            }

            if(df_level.levelComplete)
            {
                gameRunning = false;

            }
            
            base.Update(gameTime);
        }


        public void ControlViewPort()
        {
            if(inputHandler.KeyDown(Keys.W))
            {
                float yPos = camera.GetPosition().Y;
                yPos -= 50;
                camera.SetY(yPos);
            }
            if(inputHandler.KeyDown(Keys.S))
            {
                float yPos = camera.GetPosition().Y;
                yPos += 50;
                camera.SetY(yPos);
            }
            if(inputHandler.KeyDown(Keys.D))
            {
                float xPos = camera.GetPosition().X;
                xPos += 50;
                camera.SetX(xPos);
            }
            if(inputHandler.KeyDown(Keys.A))
            {
                float xPos = camera.GetPosition().X;
                xPos -= 50;
                camera.SetX(xPos);
            }
        }


        public void UpdateViewport(Player player)
        {
            float spriteWidth = 120;
            float spriteHeight = 150;
            float width = graphicsDevice.PresentationParameters.BackBufferWidth;
            float height = graphicsDevice.PresentationParameters.BackBufferHeight;

            float leftMargin = camera.GetPosition().X + camera.GetMargin();
            float rightMargin = camera.GetPosition().X + width - camera.GetMargin();

            float topMargin = camera.GetPosition().Y + camera.GetMargin();
            float bottomMargin = camera.GetPosition().Y + height - camera.GetMargin();

            if (player.GetPosition().X < leftMargin)
            {
                camera.SetX(player.GetPosition().X - camera.GetMargin());                
            }
            if(player.GetPosition().X + spriteWidth > rightMargin)
            {
                camera.SetX(player.GetPosition().X + spriteWidth - width + camera.GetMargin());
            }
            if(player.GetPosition().Y < topMargin)
            {
                camera.SetY(player.GetPosition().Y - camera.GetMargin());
            }
            if(player.GetPosition().Y + spriteHeight > bottomMargin)
            {
                camera.SetY(player.GetPosition().Y + spriteHeight - height + camera.GetMargin());
            }

        }


        public void DrawOpenScreen()
        {
            Rectangle sourceRect = new Rectangle(0, 0, openingScreen.Width,openingScreen.Height);
            spriteBatch.Draw(openingScreen, new Vector2(0), sourceRect, Color.White);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();     

            if(gameRunning)
            {                
                IsMouseVisible = false;
                UpdateViewport(df_level.player);
                df_level.Draw(gameTime, spriteBatch, spriteEffects, camera);
                DrawCrossHair();
                ShowCursorPos();                
            }
            else
            {
                IsMouseVisible = true;
                DrawOpenScreen();           
            }

            spriteBatch.End();
          
            base.Draw(gameTime);
        }
    }
}
