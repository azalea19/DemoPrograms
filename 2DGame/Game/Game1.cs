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
        public static GraphicsDevice graphicsDevice;
        public static ContentManager contentManager;
        public static InputHandler inputHandler;
        GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;
        SpriteEffects spriteEffects;

        DarkForest df_level;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            contentManager = Content;
            contentManager.RootDirectory = "Content";
            inputHandler = new InputHandler();           
        }


        public void ToggleFullScreen()
        {
            if(fullScreen)
            {
                graphics.PreferredBackBufferWidth = 1024;
                graphics.PreferredBackBufferHeight = 728;
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
            graphicsDevice = GraphicsDevice;
            fullScreen = false;
            camera = new Camera(new Vector2(0, 0), 20);
            df_level = new DarkForest(camera);
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

            df_level.Update(gameTime);

            base.Update(gameTime);
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
            UpdateViewport(df_level.player);

            spriteBatch.Begin();

            df_level.Draw(gameTime, spriteBatch, spriteEffects, camera);

            spriteBatch.End();
          
            base.Draw(gameTime);
        }
    }
}
