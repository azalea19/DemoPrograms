using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace _2DGame
{

    public class Game1 : Game
    {
        public Camera camera;

        public static bool fullScreen;
        public static bool editMode;

        public static GraphicsDevice graphicsDevice;
        public static ContentManager contentManager;
        public static InputHandler inputHandler;
        GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;
        SpriteEffects spriteEffects;
        public static int windowWidth;
        public static int windowHeight;

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
            Rectangle vertical = new Rectangle(inputHandler.currentMouse.Position.X, 0, 1, windowHeight);
            Rectangle horizontal = new Rectangle(0,inputHandler.currentMouse.Position.Y, windowWidth, 1);
            
            spriteBatch.Draw(pixel, vertical, Color.Red);
            spriteBatch.Draw(pixel, horizontal, Color.Red);
        }

        public void ShowCursorPos()
        {           
            spriteBatch.DrawString(f, (inputHandler.currentMouse.Position.X + camera.m_position.X) + "," + (inputHandler.currentMouse.Position.Y + camera.m_position.Y), new Vector2(100,100), Color.White);
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
            windowWidth = 1200;
            windowHeight = 900;
            graphicsDevice = GraphicsDevice;
            fullScreen = false;
            camera = new Camera(new Vector2(0, 0), 250);
            df_level = new DarkForest(camera);
            graphics.PreferredBackBufferWidth = windowWidth;
            graphics.PreferredBackBufferHeight = windowHeight;
            f = contentManager.Load<SpriteFont>("Fonts/Helion");
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
                         
            if(inputHandler.KeyPressed(Keys.F11))
            {
                ToggleFullScreen();
            }
            if(inputHandler.KeyPressed(Keys.F1))
            {
                ToggleEditMode();
            }

            if(editMode)
            {
                ControlViewPort();                
            }

            df_level.Update(gameTime);

            base.Update(gameTime);
        }


        public void ControlViewPort()
        {
            if(inputHandler.KeyDown(Keys.W))
            {
                camera.m_position.Y -= 50;
            }
            if(inputHandler.KeyDown(Keys.S))
            {
                camera.m_position.Y += 50;
            }
            if(inputHandler.KeyDown(Keys.D))
            {
                camera.m_position.X += 50;
            }
            if(inputHandler.KeyDown(Keys.A))
            {
                camera.m_position.X -= 50;
            }
        }


        public void UpdateViewport(Player player)
        {
            float spriteWidth = 120;
            float spriteHeight = 150;
            float width = graphicsDevice.PresentationParameters.BackBufferWidth;
            float height = graphicsDevice.PresentationParameters.BackBufferHeight;

            float leftMargin = camera.m_position.X + camera.m_margin;
            float rightMargin = camera.m_position.X + width - camera.m_margin;

            float topMargin = camera.m_position.Y + camera.m_margin;
            float bottomMargin = camera.m_position.Y + height - camera.m_margin;

            if (player.m_position.X < leftMargin)
            {
                camera.m_position.X = player.m_position.X - camera.m_margin;
            }
            if(player.m_position.X + spriteWidth > rightMargin)
            {
                camera.m_position.X = player.m_position.X  + spriteWidth - width + camera.m_margin;
            }
            if(player.m_position.Y < topMargin)
            {
                camera.m_position.Y = player.m_position.Y - camera.m_margin;
            }
            if(player.m_position.Y + spriteHeight > bottomMargin)
            {
                camera.m_position.Y = player.m_position.Y + spriteHeight - height + camera.m_margin;
            }

        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            if(!editMode)
            {
                UpdateViewport(df_level.player);
            }
            
            spriteBatch.Begin();

            df_level.Draw(gameTime, spriteBatch, spriteEffects, camera);


            ShowCursorPos();
            DrawCrossHair();

            spriteBatch.End();
          
            base.Draw(gameTime);
        }
    }
}
