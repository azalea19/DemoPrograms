using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGame
{

    class Level
    {
        /// <summary>
        /// The platforms
        /// </summary>
        public List<Platform> m_platforms;
        /// <summary>
        /// The images
        /// </summary>
        public List<BackgroundImage> m_images;

        /// <summary>
        /// Initializes a new instance of the <see cref="Level"/> class.
        /// </summary>
        public Level()
        {
            m_platforms = new List<Platform>();
            m_images = new List<BackgroundImage>();
        }

        /// <summary>
        /// Initialises this instance.
        /// </summary>
        public virtual void Initialise()
        {

        }

        /// <summary>
        /// Updates the level.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        public virtual void Update(GameTime gameTime)
        {
        }

        /// <summary>
        /// Draws the level.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        /// <param name="spriteBatch">The sprite batch.</param>
        /// <param name="spriteEffects">The sprite effects.</param>
        /// <param name="camera">The camera.</param>
        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch, SpriteEffects spriteEffects, Camera camera)
        {

        }
    }
}
