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
        private int m_frameIndex;
        private float m_time;

        public AnimationHandler(Animation animation)
        {
            m_animation = animation;
            m_frameIndex = 0;
            m_time = 0.0f;
        }

        public Vector2 GetOrigin()
        {
            return new Vector2(m_animation.GetFrameWidth() / 2.0f, m_animation.GetFrameHeight());
        }

        //Gets the animation currently playing
        public Animation GetAnimation()
        {
            return m_animation;
        }

        public int GetFrameIndex()
        {
            return m_frameIndex;
        } 

        public void Draw(Animation animation, GameTime gameTime, SpriteBatch spriteBatch, Vector2 position, SpriteEffects spriteEffects, float scale)
        {
            if (animation == null)
            {
                throw new NotSupportedException("No animation is currently playing.");
            }

            //Process time passing
            m_time += (float)gameTime.ElapsedGameTime.TotalSeconds;
            while (m_time > animation.GetFrameTime())
            {
                m_time -= animation.GetFrameTime();

                if (animation.IsLooping())
                {
                    m_frameIndex = (m_frameIndex + 1) % animation.GetFrameCount();
                }
                else
                {
                    m_frameIndex = Math.Min(m_frameIndex + 1, animation.GetFrameCount() - 1);
                }
            }

            //Rectangle source = new Rectangle(m_frameIndex * animation.GetTexture().Height, 0, animation.GetTexture().Height, animation.GetTexture().Height);
            //spriteBatch.Draw(animation.GetTexture(m_frameIndex), position, Color.White);
            spriteBatch.Draw(animation.GetTexture(m_frameIndex), position, null, Color.White, 0, new Vector2(0, 0), scale, spriteEffects, 0);
            //spriteBatch.Draw(animation.GetTexture(), position, source, Color.White, 0.0f, GetOrigin(), 1.0f, spriteEffects, 0.0f);
        }

    }
}
