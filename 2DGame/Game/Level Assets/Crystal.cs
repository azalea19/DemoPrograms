using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGame
{
    class Crystal
    {
        /// <summary>
        /// The start position
        /// </summary>
        /// 
        private Vector2 startPosition;

        /// <summary>
        /// The end position
        /// </summary>
        /// 
        private Vector2 endPosition;

        /// <summary>
        /// The position
        /// </summary>
        private Vector2 position;

        /// <summary>
        /// The trip time
        /// </summary>
        private float tripTime;

        /// <summary>
        /// The timer
        /// </summary>
        private float timer;

        /// <summary>
        /// The texture
        /// </summary>
        private Texture texture;

        /// <summary>
        /// Initializes a new instance of the <see cref="Crystal"/> class.
        /// </summary>
        /// <param name="startPosition">The start position.</param>
        /// <param name="endPosition">The end position.</param>
        /// <param name="tripTime">The trip time.</param>
        public Crystal(Vector2 startPosition, Vector2 endPosition, float tripTime)        
        {           
            this.startPosition = startPosition;
            this.endPosition = endPosition;
            this.tripTime = tripTime;
            texture = Texture.Create("DarkForest/Crystals/s_9_glow1");
            position = startPosition;
            timer = 0;            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Crystal"/> class.
        /// </summary>
        /// <param name="startPosition">The start position.</param>
        public Crystal(Vector2 startPosition)
        {
            this.startPosition = startPosition;
            endPosition = new Vector2(startPosition.X, startPosition.Y + 15);
            texture = Texture.Create("DarkForest/Crystals/s_9_glow1");
            position = startPosition;                     
            tripTime = 2;
            timer = 0;
        }

        /// <summary>
        /// Gets the texture.
        /// </summary>
        /// <returns></returns>
        public Texture GetTexture()
        {
            return texture;
        }

        /// <summary>
        /// Gets the position.
        /// </summary>
        /// <returns></returns>
        public Vector2 GetPosition()
        {
            return position;
        }

        /// <summary>
        /// Updates the crystal.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        public void Update(GameTime gameTime)
        {
            float t = (float)gameTime.ElapsedGameTime.TotalSeconds;
            timer += t;

            if (timer < tripTime)
            {
                //We are still moving from start position to end position
                position = Vector2.Lerp(startPosition, endPosition, timer / tripTime);               
            }
            else
            {
                timer = 0;
                Vector2 temp = startPosition;
                startPosition = endPosition;
                endPosition = temp;
            }
        }

        /// <summary>
        /// Draws the crystal.
        /// </summary>
        /// <param name="spriteBatch">The sprite batch.</param>
        /// <param name="camera">The camera.</param>
        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            Rectangle sourceRect = new Rectangle(0, 0, texture.Width, texture.Height);
            Vector2 origin = new Vector2(texture.Width / 2, texture.Height / 2);
            spriteBatch.Draw(texture, position - camera.GetPosition(), sourceRect, Color.White);
        }

    }
}

