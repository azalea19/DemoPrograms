using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGame
{
 
    class MovingPlatform : Platform
    {
        /// <summary>
        /// The start position
        /// </summary>
        private Vector2 startPosition;

        /// <summary>
        /// The end position
        /// </summary>
        private Vector2 endPosition;

        /// <summary>
        /// The trip time
        /// </summary>
        private float tripTime;

        /// <summary>
        /// The timer
        /// </summary>
        private float timer;

        /// <summary>
        /// Initializes a new instance of the <see cref="MovingPlatform"/> class.
        /// </summary>
        /// <param name="texture">The texture.</param>
        /// <param name="startPosition">The start position.</param>
        /// <param name="endPosition">The end position.</param>
        /// <param name="tripTime">The trip time.</param>
        public MovingPlatform(Texture texture, Vector2 startPosition, Vector2 endPosition, float tripTime)
            : base(texture,startPosition)
        {
            this.startPosition = startPosition;
            this.endPosition = endPosition;
            this.tripTime = tripTime;
            timer = 0;
            isMoving = true;
        }


        /// <summary>
        /// Updates the platform.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        public override void Update(GameTime gameTime)
        {
            float t = (float)gameTime.ElapsedGameTime.TotalSeconds;
            timer += t;
            Vector2 oldPos = position;

            if(timer < tripTime)
            {
                //We are still moving from start position to end position
                position = Vector2.Lerp(startPosition, endPosition, timer/tripTime);
                changeInPos = position - oldPos;
            }
            else
            {
                timer = 0;
                Vector2 temp = startPosition;
                startPosition = endPosition;
                endPosition = temp;
            }                   
        }

    }
}
