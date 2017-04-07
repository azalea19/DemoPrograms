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
    public class AnimationHandler
    {
        private Animation m_animation;

        public AnimationHandler(Animation animation)
        {
            m_animation = animation;
        }

        public Vector2 GetOrigin()
        {
            return new Vector2(m_animation.GetFrameWidth() / 2.0f, m_animation.GetFrameHeight());
        }

        public float TotalAnimationTime()
        {
            return m_animation.GetFrameTime() * m_animation.GetFrameCount();
        }

        //Gets the animation currently playing
        public Animation GetAnimation()
        {
            return m_animation;
        }

        public int GetFrameIndex(float dt)
        {
            if(m_animation.IsLooping())
            {
                return (int)((dt / m_animation.GetFrameTime()) % m_animation.GetFrameCount());
            }
            else
            {
                return Math.Min((int)(dt / m_animation.GetFrameTime()), m_animation.GetFrameCount() - 1);
            }
        } 

        public void Draw(float dt, SpriteBatch spriteBatch, Vector2 position, SpriteEffects spriteEffects, float scale)
        {
            if (m_animation == null)
            {
                throw new Exception("No animation is currently linked to this handler.");
            }
                    
            spriteBatch.Draw(m_animation.GetTexture(GetFrameIndex(dt)), position, null, Color.White, 0, new Vector2(0, 0), scale, spriteEffects, 0);           
        }

    }
}
