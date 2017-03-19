using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace _2DGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        public static GraphicsDevice graphicsDevice;
        GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;
        SpriteEffects spriteEffects;
        private Texture2D robo;
        AnimationHandler handler;
        Animation animation;
        InputHandler inputHandler;
        Vector2 lastPos;
        int count = 0;
        ParticleEngine particleEngine;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);           
            Content.RootDirectory = "Content";     
            

            //My changes here
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
            graphicsDevice = GraphicsDevice;
            graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();

            // TODO: Add your initialization logic here
            List<Texture2D> particles = new List<Texture2D>();
            particles.Add(Content.Load<Texture2D>("Particles/magicparticle"));
            particles.Add(Content.Load<Texture2D>("Particles/whiteglow"));
            particles.Add(Content.Load<Texture2D>("Particles/blueglow"));
            particleEngine = new ParticleEngine(particles, new Vector2(100f,100f),1);

            //animation = new Animation(Content.Load<Texture2D>("Player/Run"), 0.1f, true);
            animation = new Animation(0.1f, true);
            handler = new AnimationHandler(animation);

            animation.AddFrame(Content.Load<Texture2D>("Jump/1"));
            animation.AddFrame(Content.Load<Texture2D>("Jump/2"));
            animation.AddFrame(Content.Load<Texture2D>("Jump/3"));
            animation.AddFrame(Content.Load<Texture2D>("Jump/4"));
            animation.AddFrame(Content.Load<Texture2D>("Jump/5"));
            animation.AddFrame(Content.Load<Texture2D>("Jump/6"));
            animation.AddFrame(Content.Load<Texture2D>("Jump/8"));
            //animation.AddFrame(Content.Load<Texture2D>("Jump/9"));
            animation.AddFrame(Content.Load<Texture2D>("Jump/10"));
            animation.AddFrame(Content.Load<Texture2D>("Jump/13"));
            animation.AddFrame(Content.Load<Texture2D>("Jump/17"));
            animation.AddFrame(Content.Load<Texture2D>("Jump/19"));
            animation.AddFrame(Content.Load<Texture2D>("Jump/21"));

            inputHandler = new InputHandler();
            lastPos = new Vector2(50f, 50f);
            
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            spriteEffects = new SpriteEffects();    
                  
            
            
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            inputHandler.Update();

            if(inputHandler.GamePadLTPressed())
            {
                count++;
                Console.WriteLine("pressed " + count);
            }

            lastPos += inputHandler.GetLeftTS()*2;

            // TODO: Add your update logic here

            particleEngine.m_emitterLocation = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
            particleEngine.Update();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            if(animation == null)
            {
                Console.WriteLine("null");
            }

            spriteBatch.Begin();
            handler.Draw(animation, gameTime, spriteBatch, lastPos, spriteEffects, 1f);
            spriteBatch.End();
            // TODO: Add your drawing code here
            particleEngine.Draw(spriteBatch);
            base.Draw(gameTime);
        }
    }
}
