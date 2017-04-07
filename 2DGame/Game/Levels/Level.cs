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
        public List<Platform> m_platforms;
        public List<BackgroundImage> m_images;      

        public Level()
        {
            m_platforms = new List<Platform>();
            m_images = new List<BackgroundImage>();
        }

        public virtual void Initialise()
        {

        }

        public virtual void Update(GameTime gameTime)
        {
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch, SpriteEffects spriteEffects, Camera camera)
        {

        }
    }
}
