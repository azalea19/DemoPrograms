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
        /// <summary>
        /// The width and height of the bounding box.
        /// </summary>
        private Vector2 size;

        /// <summary>
        /// The position of the bounding box.
        /// </summary>
        private Vector2 position;

        /// <summary>
        /// Initializes a new instance of the <see cref="BoundingBox"/> class.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <param name="position">The position.</param>
        public BoundingBox(Vector2 size, Vector2 position)
        {
            this.size = size;
            this.position = position;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BoundingBox"/> class.
        /// </summary>
        /// <param name="texture">The texture.</param>
        /// <param name="position">The position.</param>
        public BoundingBox(Texture texture, Vector2 position)
        {
            size.X = texture.Width;
            size.Y = texture.Height;
            this.position = position;
        }

        /// <summary>
        /// Gets the AABB.
        /// </summary>
        /// <param name="texture">The texture.</param>
        /// <returns></returns>
        public BoundingBox GetAABB(Texture texture)
        {
            return new BoundingBox(new Vector2(texture.Width,texture.Height), position);           
        }

        /// <summary>
        /// Checks if two boxes are intersecting.
        /// </summary>
        /// <param name="box1">The first box.</param>
        /// <param name="box2">The second box.</param>
        /// <returns></returns>
        public static bool Intersects(BoundingBox box1, BoundingBox box2)
        {
            Vector2 xyDistance = box2.position - box1.position + ((box2.size - box1.size) / 2);
            Vector2 xyOverlap = (box2.size + box1.size) / 2;

            if(Math.Abs(xyDistance.X) > xyOverlap.X)            
                return false;
            
            if(Math.Abs(xyDistance.Y) > xyOverlap.Y)            
                return false;
            
            return true;
        }

        /// <summary>
        /// Returns the bounding box of the intersection between box A and box B.
        /// </summary>
        /// <param name="a">Box A</param>
        /// <param name="b">Box B</param>
        /// <returns></returns>
        public static BoundingBox Intersection(BoundingBox a, BoundingBox b)
        {
            float xmin = Math.Max(a.position.X, b.position.X);
            float xmax = Math.Min(a.position.X + a.size.X, b.position.X + b.size.X);
            float ymin = Math.Max(a.position.Y, b.position.Y);
            float ymax = Math.Min(a.position.Y + a.size.Y, b.position.Y + b.size.Y);
            return new BoundingBox(new Vector2(Math.Max(0, (xmax - xmin)), Math.Max(0, (ymax - ymin))), new Vector2(xmin, ymin));
        }

        /// <summary>
        /// Gets the size.
        /// </summary>
        /// <returns></returns>
        public Vector2 GetSize()
        {
            return size;
        }

        /// <summary>
        /// Gets the position.
        /// </summary>
        /// <returns></returns>
        public Vector2 GetPosition()
        {
            return position;
        }

    }
}
