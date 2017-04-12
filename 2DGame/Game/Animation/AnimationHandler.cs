using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGame
{
   
    public class AnimationHandler
    {
        /// <summary>
        /// The animation the handler is in charge of.
        /// </summary>
        private Animation animation;


        /// <summary>
        /// Initializes a new instance of the <see cref="AnimationHandler"/> class.
        /// </summary>
        /// <param name="animation">The animation.</param>
        public AnimationHandler(Animation animation)
        {
            this.animation = animation;
        }


        /// <summary>
        /// Returns the total the animation time.
        /// </summary>
        /// <returns></returns>
        public float TotalAnimationTime()
        {
            return animation.GetFrameTime() * animation.GetFrameCount();
        }

        /// <summary>
        /// Gets the animation the handler is in charge of.
        /// </summary>
        /// <returns></returns>
        public Animation GetAnimation()
        {
            return animation;
        }

        /// <summary>
        /// Gets the index of the frame based on the current time.
        /// </summary>
        /// <param name="dt">The change in time.</param>
        /// <returns></returns>
        public int GetFrameIndex(float dt)
        {
            if(animation.IsLooping())
            {
                return (int)((dt / animation.GetFrameTime()) % animation.GetFrameCount());
            }
            else
            {
                return Math.Min((int)(dt / animation.GetFrameTime()), animation.GetFrameCount() - 1);
            }
        }

        /// <summary>
        /// Draws the animation at the frame based on the current time.
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <param name="spriteBatch">The sprite batch.</param>
        /// <param name="position">The position.</param>
        /// <param name="spriteEffects">The sprite effects.</param>
        /// <param name="scale">The scale.</param>
        /// <exception cref="Exception">No animation is currently linked to this handler.</exception>
        public void Draw(float dt, SpriteBatch spriteBatch, Vector2 position, SpriteEffects spriteEffects, float scale)
        {
            if (animation == null)
            {
                throw new Exception("No animation is currently linked to this handler.");
            }                    
            spriteBatch.Draw(animation.GetTexture(GetFrameIndex(dt)), position, null, Color.White, 0, new Vector2(0, 0), scale, spriteEffects, 0);           
        }

    }
}
