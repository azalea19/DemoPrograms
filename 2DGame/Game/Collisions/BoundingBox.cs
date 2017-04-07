using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGame
{
    public class BoundingBox
    {
        public Vector2 m_size;
        public Vector2 m_position;

        public BoundingBox(Vector2 size, Vector2 position)
        {
            m_size = size;
            m_position = position;
        }

        public BoundingBox(Texture texture, Vector2 position)
        {
            m_size.X = texture.Width;
            m_size.Y = texture.Height;
            m_position = position;
        }

        public BoundingBox GetAABB(Texture texture)
        {
            return new BoundingBox(new Vector2(texture.Width,texture.Height), m_position);           
        }

        public static bool Intersects(BoundingBox box1, BoundingBox box2)
        {
            Vector2 xyDistance = box2.m_position - box1.m_position + ((box2.m_size - box1.m_size) / 2);
            Vector2 xyOverlap = (box2.m_size + box1.m_size) / 2;

            if(Math.Abs(xyDistance.X) > xyOverlap.X)            
                return false;
            
            if(Math.Abs(xyDistance.Y) > xyOverlap.Y)            
                return false;
            
            return true;
        }

        public static BoundingBox Intersection(BoundingBox a, BoundingBox b)
        {
            float xmin = Math.Max(a.m_position.X, b.m_position.X);
            float xmax = Math.Min(a.m_position.X + a.m_size.X, b.m_position.X + b.m_size.X);
            float ymin = Math.Max(a.m_position.Y, b.m_position.Y);
            float ymax = Math.Min(a.m_position.Y + a.m_size.Y, b.m_position.Y + b.m_size.Y);
            return new BoundingBox(new Vector2(Math.Max(0, (xmax - xmin)), Math.Max(0, (ymax - ymin))), new Vector2(xmin, ymin));
        }

    }
}
