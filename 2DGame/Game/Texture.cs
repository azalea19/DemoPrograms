using System.Drawing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _2DGame
{
    public class Texture
    {
        Texture2D m_texture;
        Microsoft.Xna.Framework.Color[] pixels;

        private Texture()
        {
        }

        public Texture(Texture2D texture)
        {
            m_texture = texture;
            pixels = new Microsoft.Xna.Framework.Color[m_texture.Width * m_texture.Height];
            m_texture.GetData<Microsoft.Xna.Framework.Color>(pixels);



        }

        public static Texture Create(string texturePath)
        {
            return new Texture(Game1.contentManager.Load<Texture2D>(texturePath));
        }

        public static implicit operator Texture2D(Texture texture)
        {
            return texture.m_texture;
        }

        public int Width
        {
            get
            {
                return m_texture.Width;
            }
        }

        public int Height
        {
            get
            {
                return m_texture.Height;
            }
        }

        public Microsoft.Xna.Framework.Color GetPixel(int x, int y)
        {
            return pixels[y * m_texture.Width + x];
        }

        public Microsoft.Xna.Framework.Color GetPixel(Vector2 position)
        {
            return GetPixel((int)position.X, (int)position.Y);
        }

        public Bitmap ToBitmap()
        {
            Bitmap img = new Bitmap(Width, Height);
            for (int y = 0; y < Height; y++)
                for (int x = 0; x < Width; x++)
                    img.SetPixel(x, y, System.Drawing.Color.FromArgb(GetPixel(x, y).A, GetPixel(x, y).R, GetPixel(x, y).G, GetPixel(x, y).B));
            return img;
        }

    }
}
