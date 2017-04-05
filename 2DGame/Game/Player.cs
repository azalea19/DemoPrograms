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
    enum PlayerState
    {
        PS_IDLE,
        PS_RUN,
        PS_DEAD,
        PS_JUMP
    }

    public class Player
    {
        private AnimationHandler[] m_animations;
        private AnimationHandler m_idle;
        private AnimationHandler m_run;
        private AnimationHandler m_dead;
        private AnimationHandler m_jump;

        private AnimationHandler m_current;


        private Vector2 m_position;
        private Vector2 m_velocity;

        public Player()
        {          
            LoadAnimations();
            m_current = m_idle;
            m_position = new Vector2(100, 100);
            m_velocity = new Vector2(1, 1);            
        } 
            
        public void LoadAnimations()
        {
            Animation dead = new Animation(0.1f, true);
            dead.AddFrame(Game1.contentManager.Load<Texture2D>("Player/Dead/001"));
            dead.AddFrame(Game1.contentManager.Load<Texture2D>("Player/Dead/002"));
            dead.AddFrame(Game1.contentManager.Load<Texture2D>("Player/Dead/003"));
            dead.AddFrame(Game1.contentManager.Load<Texture2D>("Player/Dead/004"));
            dead.AddFrame(Game1.contentManager.Load<Texture2D>("Player/Dead/005"));
            dead.AddFrame(Game1.contentManager.Load<Texture2D>("Player/Dead/006"));
            dead.AddFrame(Game1.contentManager.Load<Texture2D>("Player/Dead/007"));
            dead.AddFrame(Game1.contentManager.Load<Texture2D>("Player/Dead/008"));
            dead.AddFrame(Game1.contentManager.Load<Texture2D>("Player/Dead/009"));
            dead.AddFrame(Game1.contentManager.Load<Texture2D>("Player/Dead/010"));
            dead.AddFrame(Game1.contentManager.Load<Texture2D>("Player/Dead/011"));
            dead.AddFrame(Game1.contentManager.Load<Texture2D>("Player/Dead/012"));
            dead.AddFrame(Game1.contentManager.Load<Texture2D>("Player/Dead/013"));
            dead.AddFrame(Game1.contentManager.Load<Texture2D>("Player/Dead/014"));
            dead.AddFrame(Game1.contentManager.Load<Texture2D>("Player/Dead/015"));
            dead.AddFrame(Game1.contentManager.Load<Texture2D>("Player/Dead/016"));
            dead.AddFrame(Game1.contentManager.Load<Texture2D>("Player/Dead/017"));
            dead.AddFrame(Game1.contentManager.Load<Texture2D>("Player/Dead/018"));
            dead.AddFrame(Game1.contentManager.Load<Texture2D>("Player/Dead/019"));
            m_dead = new AnimationHandler(dead);

            Animation jump = new Animation(0.1f, false);
            jump.AddFrame(Game1.contentManager.Load<Texture2D>("Player/Jump/1"));
            jump.AddFrame(Game1.contentManager.Load<Texture2D>("Player/Jump/2"));
            jump.AddFrame(Game1.contentManager.Load<Texture2D>("Player/Jump/3"));
            jump.AddFrame(Game1.contentManager.Load<Texture2D>("Player/Jump/4"));
            jump.AddFrame(Game1.contentManager.Load<Texture2D>("Player/Jump/5"));
            jump.AddFrame(Game1.contentManager.Load<Texture2D>("Player/Jump/6"));
            jump.AddFrame(Game1.contentManager.Load<Texture2D>("Player/Jump/7"));
            jump.AddFrame(Game1.contentManager.Load<Texture2D>("Player/Jump/8"));            
            jump.AddFrame(Game1.contentManager.Load<Texture2D>("Player/Jump/10"));
            jump.AddFrame(Game1.contentManager.Load<Texture2D>("Player/Jump/13"));
            jump.AddFrame(Game1.contentManager.Load<Texture2D>("Player/Jump/15"));
            jump.AddFrame(Game1.contentManager.Load<Texture2D>("Player/Jump/17"));
            jump.AddFrame(Game1.contentManager.Load<Texture2D>("Player/Jump/19"));
            jump.AddFrame(Game1.contentManager.Load<Texture2D>("Player/Jump/21"));
            m_jump = new AnimationHandler(jump);

            Animation idle = new Animation(0.1f, true);
            idle.AddFrame(Game1.contentManager.Load<Texture2D>("Player/Idle/001"));
            idle.AddFrame(Game1.contentManager.Load<Texture2D>("Player/Idle/002"));
            idle.AddFrame(Game1.contentManager.Load<Texture2D>("Player/Idle/003"));
            idle.AddFrame(Game1.contentManager.Load<Texture2D>("Player/Idle/004"));
            idle.AddFrame(Game1.contentManager.Load<Texture2D>("Player/Idle/005"));
            idle.AddFrame(Game1.contentManager.Load<Texture2D>("Player/Idle/006"));
            idle.AddFrame(Game1.contentManager.Load<Texture2D>("Player/Idle/007"));
            idle.AddFrame(Game1.contentManager.Load<Texture2D>("Player/Idle/008"));
            idle.AddFrame(Game1.contentManager.Load<Texture2D>("Player/Idle/009"));
            idle.AddFrame(Game1.contentManager.Load<Texture2D>("Player/Idle/010"));
            idle.AddFrame(Game1.contentManager.Load<Texture2D>("Player/Idle/011"));
            idle.AddFrame(Game1.contentManager.Load<Texture2D>("Player/Idle/012"));
            idle.AddFrame(Game1.contentManager.Load<Texture2D>("Player/Idle/013"));
            idle.AddFrame(Game1.contentManager.Load<Texture2D>("Player/Idle/014"));
            idle.AddFrame(Game1.contentManager.Load<Texture2D>("Player/Idle/015"));
            idle.AddFrame(Game1.contentManager.Load<Texture2D>("Player/Idle/016"));
            idle.AddFrame(Game1.contentManager.Load<Texture2D>("Player/Idle/017"));
            idle.AddFrame(Game1.contentManager.Load<Texture2D>("Player/Idle/018"));
            idle.AddFrame(Game1.contentManager.Load<Texture2D>("Player/Idle/019"));
            m_idle = new AnimationHandler(idle);

            Animation run = new Animation(0.1f, true);
            run.AddFrame(Game1.contentManager.Load<Texture2D>("Player/Run/001"));
            run.AddFrame(Game1.contentManager.Load<Texture2D>("Player/Run/002"));
            run.AddFrame(Game1.contentManager.Load<Texture2D>("Player/Run/003"));
            run.AddFrame(Game1.contentManager.Load<Texture2D>("Player/Run/004"));
            run.AddFrame(Game1.contentManager.Load<Texture2D>("Player/Run/005"));
            run.AddFrame(Game1.contentManager.Load<Texture2D>("Player/Run/006"));
            run.AddFrame(Game1.contentManager.Load<Texture2D>("Player/Run/007"));
            run.AddFrame(Game1.contentManager.Load<Texture2D>("Player/Run/008"));
            run.AddFrame(Game1.contentManager.Load<Texture2D>("Player/Run/009"));
            run.AddFrame(Game1.contentManager.Load<Texture2D>("Player/Run/010"));
            run.AddFrame(Game1.contentManager.Load<Texture2D>("Player/Run/011"));
            m_run = new AnimationHandler(run);
        }



        public void Update(GameTime gameTime)
        {
            timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
            deadTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (m_current == m_jump)
            {
                if(timeElapsed > m_jump.GetAnimation().GetFrameCount() * m_jump.GetAnimation().GetFrameTime())
                {
                    m_current = m_idle;
                    m_current.Restart();
                    timeElapsed = 0;
                }
            }

            if(m_current == m_dead)
            {
                if(deadTime > m_dead.GetAnimation().GetFrameCount()*m_dead.GetAnimation().GetFrameTime())
                {
                    m_current = m_dead;
                    m_current.Restart();
                    deadTime = 0;
                }
            }

            if(m_current != m_jump || m_current != m_dead)
            {
                if(Game1.inputHandler.KeyPressed(Keys.K))
                {
                    m_current = m_dead;
                    m_current.Restart();
                    deadTime = 0;
                }
                if (Game1.inputHandler.KeyPressed(Keys.Space))
                {
                    m_current = m_jump;
                    m_current.Restart();
                    timeElapsed = 0;
                }
                else if (Game1.inputHandler.KeyDown(Keys.D))
                {
                    if(m_current != m_run)
                    {
                        m_current = m_run;
                        m_current.Restart();
                    }
                }
                else
                {
                    if(m_current != m_idle)
                    {
                        m_current = m_idle;
                        m_current.Restart();
                    }
 
                }
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, SpriteEffects spriteEffects)
        {
            m_current.Draw(gameTime, spriteBatch, m_position, spriteEffects, 1f);
        }    

    }
}
