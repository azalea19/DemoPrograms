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
        private List<Texture2D> m_textures;

        public TextureReel()
        {          
            m_textures = new List<Texture2D>();
        }

        public TextureReel(Texture2D reel)
        {
            m_textures = SplitTexture(reel);
        }

        public void AddTexture(Texture2D texture)
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

        public Texture2D GetTexture(int index)
        {
            return m_textures[index];
        }

        private List<Texture2D> SplitTexture(Texture2D reel)
        {
            List<Texture2D> newList;
            newList = new List<Texture2D>(reel.Width / reel.Height);     

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
                Texture2D newTex = (Texture2D)newTarget;
                newList.Add(newTex);
            }

            

            return newList;
        }

    }
}
