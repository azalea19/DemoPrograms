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
        private List<Texture> m_textures;

        public TextureReel()
        {          
            m_textures = new List<Texture>();
        }

        public TextureReel(Texture reel)
        {
            m_textures = SplitTexture(reel);
        }

        public void AddTexture(Texture texture)
        {
            m_textures.Add(texture);
        }

        public int GetFrameCount()
        {
            return m_textures.Count;
        }

        public int GetTextureWidth()
        {
            if(m_textures.Count == 0)
            {
                return 0;
            }
            return m_textures[0].Width;         
        }

        public int GetTextureHeight()
        {
            if(m_textures.Count == 0)
            {
                return 0;
            }
            return m_textures[0].Height;
        }

        public Texture GetTexture(int index)
        {
            return m_textures[index];
        }

        private List<Texture> SplitTexture(Texture reel)
        {
            List<Texture> newList;
            newList = new List<Texture>(reel.Width / reel.Height);     

            for (int i = 0; i < newList.Capacity; i++)
            {
                RenderTarget2D newTarget = new RenderTarget2D(Game1.graphicsDevice, reel.Height, reel.Height,false,SurfaceFormat.Color,DepthFormat.Depth24);
                //newTarget = new RenderTarget2D(Game1.graphicsDevice, reel.Height, reel.Height, SurfaceFormat.Vector4,DepthFormat.Depth24);
                Game1.graphicsDevice.SetRenderTarget(newTarget);
                Game1.graphicsDevice.Clear(Color.Transparent);
                Game1.spriteBatch.Begin();
                Game1.spriteBatch.Draw(reel, new Rectangle(0, 0, reel.Height, reel.Height), new Rectangle(i * reel.Height, 0, reel.Height, reel.Height), Color.White);
                Game1.spriteBatch.End();
                Game1.graphicsDevice.SetRenderTarget(null);
                Texture newTex = new Texture((Texture2D)newTarget);
                newList.Add(newTex);
            }
            return newList;
        }

    }
}
