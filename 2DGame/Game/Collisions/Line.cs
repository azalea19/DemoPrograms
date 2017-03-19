using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGame
{
    class Line
    {
        public Vector2 A;
        public Vector2 B;
        public float Thickness;

        public Line()
        {
        }

        public Line(Vector2 a, Vector2 b, int thickness)
        {
            A = a;
            B = b;
            Thickness = thickness;
        }
           
    }
}
