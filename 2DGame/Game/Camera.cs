using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGame
{
    public class Camera
    {
        public Vector2 m_position;
        public float m_margin;

        public Camera(Vector2 position, float margin)
        {
            m_position = position;
            m_margin = margin;
        }

        public void SetPosition(Vector2 position)
        {
            m_position = position;
        }
    }
}
