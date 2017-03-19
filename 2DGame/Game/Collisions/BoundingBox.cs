using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGame
{
    class BoundingBox
    {
        private int m_width { set; get; }
        private int m_height { set; get; }

        public BoundingBox(int width, int height)
        {
            m_width = width;
            m_height = height;
        }

        public BoundingBox GetAABB(Texture2D texture)
        {
            return new BoundingBox(texture.Width, texture.Height);           
        }

    }
}
