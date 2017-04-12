using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGame
{

    class Spikes
    {
        /// <summary>
        /// The texture
        /// </summary>
        private Texture texture;

        /// <summary>
        /// The position
        /// </summary>
        private Vector2 position;

        /// <summary>
        /// Initializes a new instance of the <see cref="Spikes"/> class.
        /// </summary>
        /// <param name="texture">The texture.</param>
        /// <param name="position">The position.</param>
        public Spikes(Texture texture, Vector2 position)
        {
            this.texture = texture;
            this.position = position;
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
        /// Draws the spikes.
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
