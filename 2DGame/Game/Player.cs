using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGame
{

    public static class PlayerState
    {
        public const int IDLE_RIGHT = 0;
        public const int RUN_RIGHT = 1;
        public const int DEAD_RIGHT = 2;
        public const int JUMP_RIGHT = 3;

        public const int IDLE_LEFT = 4;    
        public const int RUN_LEFT = 5;
        public const int DEAD_LEFT = 6;
        public const int JUMP_LEFT = 7;

        public const int NUM_STATES = 8;
    }

    public static class InputAction
    {
        public const int LEFT = 0;
        public const int RIGHT = 1;
        public const int JUMP = 2;
        public const int NUM_INPUTS = 3;       
    }

    public class Player
    {
        List<Texture> particles = new List<Texture>();
        private ParticleEngine jumpEmitter;


        public AnimationHandler[] m_animations;

        int m_currentState;
        float m_animationStart;

        static private int[,] m_stateLookup;

        public Vector2 m_position;
        public Vector2 m_velocity;

        public Player(Vector2 startPos)
        {
            m_animations = new AnimationHandler[PlayerState.NUM_STATES];           
            m_stateLookup = new int[PlayerState.NUM_STATES, InputAction.NUM_INPUTS];
            LoadAnimations();
            LoadStateLookup();
            m_position = startPos;
            m_velocity = new Vector2(0, 0);
            m_currentState = PlayerState.IDLE_RIGHT;
            m_animationStart = 0;        
            
            particles.Add(Texture.Create("Particles/magicparticle"));
            particles.Add(Texture.Create("Particles/blueglow"));
            particles.Add(Texture.Create("Particles/whiteglow"));
            jumpEmitter = new ParticleEngine(particles, m_position, 1, 0.4f);
        } 


        public BoundingBox GetBoundingBox(GameTime gameTime)
        {
            float dt = (float)gameTime.TotalGameTime.TotalSeconds - m_animationStart;
            int index = m_animations[m_currentState].GetFrameIndex(dt);

            return new BoundingBox(m_animations[m_currentState].GetAnimation().GetTexture(index), m_position);
        }


        public Texture GetCurrentTexture(GameTime gameTime)
        {
            float dt = (float)gameTime.TotalGameTime.TotalSeconds - m_animationStart;
            int index = m_animations[m_currentState].GetFrameIndex(dt);

            return new Texture(m_animations[m_currentState].GetAnimation().GetTexture(index));
        }


        public void LoadStateLookup()
        {
            m_stateLookup[PlayerState.IDLE_LEFT, InputAction.LEFT] = PlayerState.RUN_LEFT;
            m_stateLookup[PlayerState.IDLE_LEFT, InputAction.RIGHT] = PlayerState.IDLE_RIGHT;
            m_stateLookup[PlayerState.IDLE_LEFT, InputAction.JUMP] = PlayerState.JUMP_LEFT;

            m_stateLookup[PlayerState.IDLE_RIGHT, InputAction.LEFT] = PlayerState.IDLE_LEFT;
            m_stateLookup[PlayerState.IDLE_RIGHT, InputAction.RIGHT] = PlayerState.RUN_RIGHT;
            m_stateLookup[PlayerState.IDLE_RIGHT, InputAction.JUMP] = PlayerState.JUMP_RIGHT;

            m_stateLookup[PlayerState.RUN_LEFT, InputAction.LEFT] = PlayerState.RUN_LEFT;
            m_stateLookup[PlayerState.RUN_LEFT, InputAction.RIGHT] = PlayerState.IDLE_RIGHT;
            m_stateLookup[PlayerState.RUN_LEFT, InputAction.JUMP] = PlayerState.JUMP_LEFT;

            m_stateLookup[PlayerState.RUN_RIGHT, InputAction.LEFT] = PlayerState.IDLE_LEFT;
            m_stateLookup[PlayerState.RUN_RIGHT, InputAction.RIGHT] = PlayerState.RUN_RIGHT;
            m_stateLookup[PlayerState.RUN_RIGHT, InputAction.JUMP] = PlayerState.JUMP_RIGHT;

            m_stateLookup[PlayerState.JUMP_LEFT, InputAction.LEFT] = PlayerState.JUMP_LEFT;
            m_stateLookup[PlayerState.JUMP_LEFT, InputAction.RIGHT] = PlayerState.JUMP_LEFT;
            m_stateLookup[PlayerState.JUMP_LEFT, InputAction.JUMP] = PlayerState.JUMP_LEFT;

            m_stateLookup[PlayerState.JUMP_RIGHT, InputAction.LEFT] = PlayerState.JUMP_RIGHT;
            m_stateLookup[PlayerState.JUMP_RIGHT, InputAction.RIGHT] = PlayerState.JUMP_RIGHT;
            m_stateLookup[PlayerState.JUMP_RIGHT, InputAction.JUMP] = PlayerState.JUMP_RIGHT;

            m_stateLookup[PlayerState.DEAD_LEFT, InputAction.LEFT] = PlayerState.DEAD_LEFT;
            m_stateLookup[PlayerState.DEAD_LEFT, InputAction.RIGHT] = PlayerState.DEAD_LEFT;
            m_stateLookup[PlayerState.DEAD_LEFT, InputAction.JUMP] = PlayerState.DEAD_LEFT;

            m_stateLookup[PlayerState.DEAD_RIGHT, InputAction.LEFT] = PlayerState.DEAD_RIGHT;
            m_stateLookup[PlayerState.DEAD_RIGHT, InputAction.RIGHT] = PlayerState.DEAD_RIGHT;
            m_stateLookup[PlayerState.DEAD_RIGHT, InputAction.JUMP] = PlayerState.DEAD_RIGHT;
        }
          
          
        public void LoadAnimations()
        {
            Animation dead_left = new Animation(0.1f, true);
            dead_left.AddFrame(Texture.Create("Player/Dead_Left/001_Left"));
            dead_left.AddFrame(Texture.Create("Player/Dead_Left/002_Left"));
            dead_left.AddFrame(Texture.Create("Player/Dead_Left/003_Left"));
            dead_left.AddFrame(Texture.Create("Player/Dead_Left/004_Left"));
            dead_left.AddFrame(Texture.Create("Player/Dead_Left/005_Left"));
            dead_left.AddFrame(Texture.Create("Player/Dead_Left/006_Left"));
            dead_left.AddFrame(Texture.Create("Player/Dead_Left/007_Left"));
            dead_left.AddFrame(Texture.Create("Player/Dead_Left/008_Left"));
            dead_left.AddFrame(Texture.Create("Player/Dead_Left/009_Left"));
            dead_left.AddFrame(Texture.Create("Player/Dead_Left/010_Left"));
            dead_left.AddFrame(Texture.Create("Player/Dead_Left/011_Left"));
            dead_left.AddFrame(Texture.Create("Player/Dead_Left/012_Left"));
            dead_left.AddFrame(Texture.Create("Player/Dead_Left/013_Left"));
            dead_left.AddFrame(Texture.Create("Player/Dead_Left/014_Left"));
            dead_left.AddFrame(Texture.Create("Player/Dead_Left/015_Left"));
            dead_left.AddFrame(Texture.Create("Player/Dead_Left/016_Left"));
            dead_left.AddFrame(Texture.Create("Player/Dead_Left/017_Left"));
            dead_left.AddFrame(Texture.Create("Player/Dead_Left/018_Left"));
            dead_left.AddFrame(Texture.Create("Player/Dead_Left/019_Left"));          
            m_animations[PlayerState.DEAD_LEFT] = new AnimationHandler(dead_left);

            Animation dead_right = new Animation(0.1f, true);
            dead_right.AddFrame(Texture.Create("Player/Dead_Right/001_Right"));
            dead_right.AddFrame(Texture.Create("Player/Dead_Right/002_Right"));
            dead_right.AddFrame(Texture.Create("Player/Dead_Right/003_Right"));
            dead_right.AddFrame(Texture.Create("Player/Dead_Right/004_Right"));
            dead_right.AddFrame(Texture.Create("Player/Dead_Right/005_Right"));
            dead_right.AddFrame(Texture.Create("Player/Dead_Right/006_Right"));
            dead_right.AddFrame(Texture.Create("Player/Dead_Right/007_Right"));
            dead_right.AddFrame(Texture.Create("Player/Dead_Right/008_Right"));
            dead_right.AddFrame(Texture.Create("Player/Dead_Right/009_Right"));
            dead_right.AddFrame(Texture.Create("Player/Dead_Right/010_Right"));
            dead_right.AddFrame(Texture.Create("Player/Dead_Right/011_Right"));
            dead_right.AddFrame(Texture.Create("Player/Dead_Right/012_Right"));
            dead_right.AddFrame(Texture.Create("Player/Dead_Right/013_Right"));
            dead_right.AddFrame(Texture.Create("Player/Dead_Right/014_Right"));
            dead_right.AddFrame(Texture.Create("Player/Dead_Right/015_Right"));
            dead_right.AddFrame(Texture.Create("Player/Dead_Right/016_Right"));
            dead_right.AddFrame(Texture.Create("Player/Dead_Right/017_Right"));
            dead_right.AddFrame(Texture.Create("Player/Dead_Right/018_Right"));
            dead_right.AddFrame(Texture.Create("Player/Dead_Right/019_Right"));
            m_animations[PlayerState.DEAD_RIGHT] = new AnimationHandler(dead_right);

            Animation jump_left = new Animation(0.03f, false);
            jump_left.AddFrame(Texture.Create("Player/Jump_Left/1_Left"));
            jump_left.AddFrame(Texture.Create("Player/Jump_Left/2_Left"));
            jump_left.AddFrame(Texture.Create("Player/Jump_Left/3_Left"));
            jump_left.AddFrame(Texture.Create("Player/Jump_Left/4_Left"));
            jump_left.AddFrame(Texture.Create("Player/Jump_Left/5_Left"));
            jump_left.AddFrame(Texture.Create("Player/Jump_Left/6_Left"));
            jump_left.AddFrame(Texture.Create("Player/Jump_Left/7_Left"));
            jump_left.AddFrame(Texture.Create("Player/Jump_Left/8_Left"));            
            jump_left.AddFrame(Texture.Create("Player/Jump_Left/10_Left"));
            jump_left.AddFrame(Texture.Create("Player/Jump_Left/13_Left"));
            jump_left.AddFrame(Texture.Create("Player/Jump_Left/15_Left"));
            jump_left.AddFrame(Texture.Create("Player/Jump_Left/17_Left"));
            jump_left.AddFrame(Texture.Create("Player/Jump_Left/19_Left"));
            jump_left.AddFrame(Texture.Create("Player/Jump_Left/21_Left"));
            m_animations[PlayerState.JUMP_LEFT] = new AnimationHandler(jump_left);


            Animation jump_right = new Animation(0.03f, false);
            jump_right.AddFrame(Texture.Create("Player/Jump_Right/1_Right"));
            jump_right.AddFrame(Texture.Create("Player/Jump_Right/2_Right"));
            jump_right.AddFrame(Texture.Create("Player/Jump_Right/3_Right"));
            jump_right.AddFrame(Texture.Create("Player/Jump_Right/4_Right"));
            jump_right.AddFrame(Texture.Create("Player/Jump_Right/5_Right"));
            jump_right.AddFrame(Texture.Create("Player/Jump_Right/6_Right"));
            jump_right.AddFrame(Texture.Create("Player/Jump_Right/7_Right"));
            jump_right.AddFrame(Texture.Create("Player/Jump_Right/8_Right"));
            jump_right.AddFrame(Texture.Create("Player/Jump_Right/10_Right"));
            jump_right.AddFrame(Texture.Create("Player/Jump_Right/13_Right"));
            jump_right.AddFrame(Texture.Create("Player/Jump_Right/15_Right"));
            jump_right.AddFrame(Texture.Create("Player/Jump_Right/17_Right"));
            jump_right.AddFrame(Texture.Create("Player/Jump_Right/19_Right"));
            jump_right.AddFrame(Texture.Create("Player/Jump_Right/21_Right"));
            m_animations[PlayerState.JUMP_RIGHT] = new AnimationHandler(jump_right);


            Animation idle_left = new Animation(0.1f, true);
            idle_left.AddFrame(Texture.Create("Player/Idle_Left/001_Left"));
            idle_left.AddFrame(Texture.Create("Player/Idle_Left/002_Left"));
            idle_left.AddFrame(Texture.Create("Player/Idle_Left/003_Left"));
            idle_left.AddFrame(Texture.Create("Player/Idle_Left/004_Left"));
            idle_left.AddFrame(Texture.Create("Player/Idle_Left/005_Left"));
            idle_left.AddFrame(Texture.Create("Player/Idle_Left/006_Left"));
            idle_left.AddFrame(Texture.Create("Player/Idle_Left/007_Left"));
            idle_left.AddFrame(Texture.Create("Player/Idle_Left/008_Left"));
            idle_left.AddFrame(Texture.Create("Player/Idle_Left/009_Left"));
            idle_left.AddFrame(Texture.Create("Player/Idle_Left/010_Left"));
            idle_left.AddFrame(Texture.Create("Player/Idle_Left/011_Left"));
            idle_left.AddFrame(Texture.Create("Player/Idle_Left/012_Left"));
            idle_left.AddFrame(Texture.Create("Player/Idle_Left/013_Left"));
            idle_left.AddFrame(Texture.Create("Player/Idle_Left/014_Left"));
            idle_left.AddFrame(Texture.Create("Player/Idle_Left/015_Left"));
            idle_left.AddFrame(Texture.Create("Player/Idle_Left/016_Left"));
            idle_left.AddFrame(Texture.Create("Player/Idle_Left/017_Left"));
            idle_left.AddFrame(Texture.Create("Player/Idle_Left/018_Left"));
            idle_left.AddFrame(Texture.Create("Player/Idle_Left/019_Left"));
            m_animations[PlayerState.IDLE_LEFT] = new AnimationHandler(idle_left);

            Animation idle_right = new Animation(0.1f, true);
            idle_right.AddFrame(Texture.Create("Player/Idle_Right/001_Right"));
            idle_right.AddFrame(Texture.Create("Player/Idle_Right/002_Right"));
            idle_right.AddFrame(Texture.Create("Player/Idle_Right/003_Right"));
            idle_right.AddFrame(Texture.Create("Player/Idle_Right/004_Right"));
            idle_right.AddFrame(Texture.Create("Player/Idle_Right/005_Right"));
            idle_right.AddFrame(Texture.Create("Player/Idle_Right/006_Right"));
            idle_right.AddFrame(Texture.Create("Player/Idle_Right/007_Right"));
            idle_right.AddFrame(Texture.Create("Player/Idle_Right/008_Right"));
            idle_right.AddFrame(Texture.Create("Player/Idle_Right/009_Right"));
            idle_right.AddFrame(Texture.Create("Player/Idle_Right/010_Right"));
            idle_right.AddFrame(Texture.Create("Player/Idle_Right/011_Right"));
            idle_right.AddFrame(Texture.Create("Player/Idle_Right/012_Right"));
            idle_right.AddFrame(Texture.Create("Player/Idle_Right/013_Right"));
            idle_right.AddFrame(Texture.Create("Player/Idle_Right/014_Right"));
            idle_right.AddFrame(Texture.Create("Player/Idle_Right/015_Right"));
            idle_right.AddFrame(Texture.Create("Player/Idle_Right/016_Right"));
            idle_right.AddFrame(Texture.Create("Player/Idle_Right/017_Right"));
            idle_right.AddFrame(Texture.Create("Player/Idle_Right/018_Right"));
            idle_right.AddFrame(Texture.Create("Player/Idle_Right/019_Right"));
            m_animations[PlayerState.IDLE_RIGHT] = new AnimationHandler(idle_right);


            Animation run_left = new Animation(0.1f, true);
            run_left.AddFrame(Texture.Create("Player/Run_Left/001_Left"));
            run_left.AddFrame(Texture.Create("Player/Run_Left/002_Left"));
            run_left.AddFrame(Texture.Create("Player/Run_Left/003_Left"));
            run_left.AddFrame(Texture.Create("Player/Run_Left/004_Left"));
            run_left.AddFrame(Texture.Create("Player/Run_Left/005_Left"));
            run_left.AddFrame(Texture.Create("Player/Run_Left/006_Left"));
            run_left.AddFrame(Texture.Create("Player/Run_Left/007_Left"));
            run_left.AddFrame(Texture.Create("Player/Run_Left/008_Left"));
            run_left.AddFrame(Texture.Create("Player/Run_Left/009_Left"));
            run_left.AddFrame(Texture.Create("Player/Run_Left/010_Left"));
            run_left.AddFrame(Texture.Create("Player/Run_Left/011_Left"));
            m_animations[PlayerState.RUN_LEFT] = new AnimationHandler(run_left);

            Animation run_right = new Animation(0.1f, true);
            run_right.AddFrame(Texture.Create("Player/Run_Right/001_Right"));
            run_right.AddFrame(Texture.Create("Player/Run_Right/002_Right"));
            run_right.AddFrame(Texture.Create("Player/Run_Right/003_Right"));
            run_right.AddFrame(Texture.Create("Player/Run_Right/004_Right"));
            run_right.AddFrame(Texture.Create("Player/Run_Right/005_Right"));
            run_right.AddFrame(Texture.Create("Player/Run_Right/006_Right"));
            run_right.AddFrame(Texture.Create("Player/Run_Right/007_Right"));
            run_right.AddFrame(Texture.Create("Player/Run_Right/008_Right"));
            run_right.AddFrame(Texture.Create("Player/Run_Right/009_Right"));
            run_right.AddFrame(Texture.Create("Player/Run_Right/010_Right"));
            run_right.AddFrame(Texture.Create("Player/Run_Right/011_Right"));
            m_animations[PlayerState.RUN_RIGHT] = new AnimationHandler(run_right);
        }


        public void Restart(float currentTime)
        {
            m_animationStart = currentTime;
        }


        public bool AnimationPlaying(float currentTime)
        {
            bool isPlaying = false;
            float dt = currentTime - m_animationStart;      
            
            switch (m_currentState)
            {                
                case PlayerState.DEAD_LEFT:
                    if(dt > m_animations[PlayerState.DEAD_LEFT].TotalAnimationTime() )
                    {              
                        //TODO         
                    }
                    else
                    {
                        isPlaying = true;
                    }
                    break;

                case PlayerState.DEAD_RIGHT:
                    if(dt > m_animations[PlayerState.DEAD_RIGHT].TotalAnimationTime())
                    {                       
                        //TODO
                    }
                    else
                    {
                        isPlaying = true;
                    }
                    break;

                case PlayerState.JUMP_LEFT:
                    if (dt > m_animations[PlayerState.JUMP_LEFT].TotalAnimationTime())
                    {                                              
                        SetState(PlayerState.IDLE_LEFT, currentTime);
                        jumpEmitter.SetEnabled(false);
                    }
                    else
                    {
                        isPlaying = true;
                    }
                    break;

                case PlayerState.JUMP_RIGHT:
                    if (dt > m_animations[PlayerState.JUMP_RIGHT].TotalAnimationTime())
                    {                                            
                        SetState(PlayerState.IDLE_RIGHT, currentTime);
                        jumpEmitter.SetEnabled(false);
                    }
                    else
                    {
                        isPlaying = true;
                    }
                    break;
                default:                   
                    break;
            }

            return isPlaying;
        }


        public void SetState(int newState, float currentTime)
        {
            if(m_currentState != newState)
            {
                m_currentState = newState;
                Restart(currentTime);
            }
        }


        public void Update(GameTime gameTime)
        {
            float currentTime = (float)gameTime.TotalGameTime.TotalSeconds;

            //Check1:
            //If still jumping or still dying
            //Keep playing that animation don't check input
            //Check2:
            //If not busy with an animation
            //Check our inputs, perform lookup and get the new state           
            //Check3:
            //If no input we are idle in the left or right direction
            //If we were in a right state then we are idling right
            //If we were in a left state then we are idling left


            //Only do the following if not jumping or dying            
            if(!AnimationPlaying(currentTime))
            {
                if (Game1.inputHandler.KeyDown(Keys.A))
                {
                    SetState(m_stateLookup[m_currentState, InputAction.LEFT], currentTime);
                }
                else if (Game1.inputHandler.KeyDown(Keys.D))
                {
                    SetState(m_stateLookup[m_currentState, InputAction.RIGHT], currentTime);
                }
                else if (m_currentState < 4)
                {
                    SetState(PlayerState.IDLE_RIGHT, currentTime);
                }
                else
                {
                    SetState(PlayerState.IDLE_LEFT, currentTime);    
                }
            }

            if (Game1.inputHandler.KeyDown(Keys.A))
            {
                m_velocity += new Vector2(-3.5f, 0);
            }
            else if (Game1.inputHandler.KeyDown(Keys.D))
            {
                m_velocity += new Vector2(3.5f, 0);
            }

            //So you can jump while running
            if (m_currentState != PlayerState.JUMP_RIGHT && m_currentState != PlayerState.JUMP_RIGHT && Game1.inputHandler.KeyPressed(Keys.Space))
            {
                jumpEmitter.SetEnabled(true);
                m_velocity += new Vector2(0, -35.0f);
                SetState(m_stateLookup[m_currentState, InputAction.JUMP], currentTime);
            }
            jumpEmitter.SetEmitterLocation(new Vector2(m_position.X + (m_animations[m_currentState].GetAnimation().GetFrameWidth() /2), m_position.Y + m_animations[m_currentState].GetAnimation().GetFrameHeight()));
            jumpEmitter.Update();
        }


        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, SpriteEffects spriteEffects, Camera camera)
        {
            float dt = (float)gameTime.TotalGameTime.TotalSeconds - m_animationStart;
            
            m_animations[m_currentState].Draw(dt, spriteBatch, m_position - camera.m_position, spriteEffects, 1f);
            jumpEmitter.Draw(spriteBatch, camera);
        }    

    }
}
