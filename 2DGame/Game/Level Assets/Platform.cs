using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGame
{
 
    class Platform
    {
        /// <summary>
        /// The texture
        /// </summary>
        private Texture texture;

        /// <summary>
        /// The position
        /// </summary>
        protected Vector2 position;

        /// <summary>
        /// The is moving
        /// </summary>
        protected bool isMoving;

        /// <summary>
        /// The change in position
        /// </summary>
        protected Vector2 changeInPos;

        /// <summary>
        /// Initializes a new instance of the <see cref="Platform"/> class.
        /// </summary>
        /// <param name="texture">The texture.</param>
        /// <param name="position">The position.</param>
        public Platform(Texture texture, Vector2 position)
        {
            this.texture = texture;
            this.position = position;
            isMoving = false;
            changeInPos = new Vector2(0, 0);
        }

        /// <summary>
        /// Updates the specified game time.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        public virtual void Update(GameTime gameTime)
        {

        }

        /// <summary>
        /// Draws the specified sprite batch.
        /// </summary>
        /// <param name="spriteBatch">The sprite batch.</param>
        /// <param name="camera">The camera.</param>
        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            Rectangle sourceRect = new Rectangle(0, 0, texture.Width, texture.Height);
            Vector2 origin = new Vector2(texture.Width / 2, texture.Height / 2);
            spriteBatch.Draw(texture, position - camera.GetPosition(), sourceRect, Color.White);
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
        /// Gets the change in position.
        /// </summary>
        /// <returns></returns>
        public Vector2 GetChangeInPosition()
        {
            return changeInPos;
        }

        /// <summary>
        /// Determines whether this instance is moving.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance is moving; otherwise, <c>false</c>.
        /// </returns>
        public bool IsMoving()
        {
            return isMoving;
        }

        /// <summary>
        /// Gets the bounding box.
        /// </summary>
        /// <returns></returns>
        public BoundingBox GetBoundingBox()
        {
            return new BoundingBox(new Vector2(texture.Width, texture.Height), position);
        }
    }
}
