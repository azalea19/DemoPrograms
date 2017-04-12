using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGame
{
    
    class TextureReel
    {
        /// <summary>
        /// The textures in the texture reel.
        /// </summary>
        private List<Texture> textures;

        /// <summary>
        /// Initializes a new instance of the <see cref="TextureReel"/> class.
        /// </summary>
        public TextureReel()
        {          
            textures = new List<Texture>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextureReel"/> class.
        /// </summary>
        /// <param name="spriteSheet">The sprite sheet.</param>
        public TextureReel(Texture spriteSheet)
        {
            textures = SplitTexture(spriteSheet);
        }

        /// <summary>
        /// Adds the texture.
        /// </summary>
        /// <param name="texture">The texture.</param>
        public void AddTexture(Texture texture)
        {
            textures.Add(texture);
        }

        /// <summary>
        /// Gets the frame count.
        /// </summary>
        /// <returns></returns>
        public int GetFrameCount()
        {
            return textures.Count;
        }

        /// <summary>
        /// Gets the width of the texture.
        /// </summary>
        /// <returns></returns>
        public int GetTextureWidth()
        {
            if(textures.Count == 0)
            {
                return 0;
            }
            return textures[0].Width;         
        }

        /// <summary>
        /// Gets the height of the texture.
        /// </summary>
        /// <returns></returns>
        public int GetTextureHeight()
        {
            if(textures.Count == 0)
            {
                return 0;
            }
            return textures[0].Height;
        }

        /// <summary>
        /// Gets the texture.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public Texture GetTexture(int index)
        {
            return textures[index];
        }

        /// <summary>
        /// Splits the sprite sheet in to a list of textures.
        /// </summary>
        /// <param name="spriteSheet">The sprite sheet.</param>
        /// <returns></returns>
        private List<Texture> SplitTexture(Texture spriteSheet)
        {
            List<Texture> newList;
            newList = new List<Texture>(spriteSheet.Width / spriteSheet.Height);     

            for (int i = 0; i < newList.Capacity; i++)
            {
                RenderTarget2D newTarget = new RenderTarget2D(Game1.graphicsDevice, spriteSheet.Height, spriteSheet.Height,false,SurfaceFormat.Color,DepthFormat.Depth24);               
                Game1.graphicsDevice.SetRenderTarget(newTarget);
                Game1.graphicsDevice.Clear(Color.Transparent);
                Game1.spriteBatch.Begin();
                Game1.spriteBatch.Draw(spriteSheet, new Rectangle(0, 0, spriteSheet.Height, spriteSheet.Height), new Rectangle(i * spriteSheet.Height, 0, spriteSheet.Height, spriteSheet.Height), Color.White);
                Game1.spriteBatch.End();
                Game1.graphicsDevice.SetRenderTarget(null);
                Texture newTex = new Texture((Texture2D)newTarget);
                newList.Add(newTex);
            }
            return newList;
        }

    }
}
