using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGame
{
    //Controls the playback of an animation.
    class AnimationHandler
    {
        private Animation m_animation;
        private float m_time;

        public AnimationHandler(Animation animation)
        {
            m_animation = animation;
            m_time = 0.0f;
        }

        public Vector2 GetOrigin()
        {
            return new Vector2(m_animation.GetFrameWidth() / 2.0f, m_animation.GetFrameHeight());
        }

        public void Restart()
        {
            m_time = 0;
        }

        //Gets the animation currently playing
        public Animation GetAnimation()
        {
            return m_animation;
        }

        public int GetFrameIndex()
        {
            if(m_animation.IsLooping())
            {
                return (int)((m_time / m_animation.GetFrameTime()) % m_animation.GetFrameCount());
            }
            else
            {
                return Math.Min((int)(m_time / m_animation.GetFrameTime()), m_animation.GetFrameCount() - 1);
            }
        } 

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Vector2 position, SpriteEffects spriteEffects, float scale)
        {
            if (m_animation == null)
            {
                throw new NotSupportedException("No animation is currently linked to this handler.");
            }

            //Process time passing
            m_time += (float)gameTime.ElapsedGameTime.TotalSeconds;
                    
            spriteBatch.Draw(m_animation.GetTexture(GetFrameIndex()), position, null, Color.White, 0, new Vector2(0, 0), scale, spriteEffects, 0);           
        }

    }
}
