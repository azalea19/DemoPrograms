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
        /// <summary>
        /// The texture
        /// </summary>
        Texture2D texture;

        /// <summary>
        /// The pixels
        /// </summary>
        Microsoft.Xna.Framework.Color[] pixels;

        /// <summary>
        /// Prevents a default instance of the <see cref="Texture"/> class from being created.
        /// </summary>
        private Texture()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Texture"/> class.
        /// </summary>
        /// <param name="texture">The texture.</param>
        public Texture(Texture2D texture)
        {
            this.texture = texture;
            pixels = new Microsoft.Xna.Framework.Color[this.texture.Width * this.texture.Height];
            this.texture.GetData<Microsoft.Xna.Framework.Color>(pixels);
        }

        /// <summary>
        /// Creates a Texture from the specified texture path.
        /// </summary>
        /// <param name="texturePath">The texture path.</param>
        /// <returns></returns>
        public static Texture Create(string texturePath)
        {
            return new Texture(Game1.contentManager.Load<Texture2D>(texturePath));
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="Texture"/> to <see cref="Texture2D"/>.
        /// </summary>
        /// <param name="texture">The texture.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator Texture2D(Texture texture)
        {
            return texture.texture;
        }

        /// <summary>
        /// Gets the width.
        /// </summary>
        /// <value>
        /// The width.
        /// </value>
        public int Width
        {
            get
            {
                return texture.Width;
            }
        }

        /// <summary>
        /// Gets the height.
        /// </summary>
        /// <value>
        /// The height.
        /// </value>
        public int Height
        {
            get
            {
                return texture.Height;
            }
        }

        /// <summary>
        /// Gets the pixel at [x,y].
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns></returns>
        public Microsoft.Xna.Framework.Color GetPixel(int x, int y)
        {
            return pixels[y * texture.Width + x];
        }

        /// <summary>
        /// Gets the pixel at [x,y].
        /// </summary>
        /// <param name="position">The position.</param>
        /// <returns></returns>
        public Microsoft.Xna.Framework.Color GetPixel(Vector2 position)
        {
            return GetPixel((int)position.X, (int)position.Y);
        }

        /// <summary>
        /// Saves the texture to a bitmap.
        /// </summary>
        /// <returns></returns>
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
