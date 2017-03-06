using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGame
{
    class Player
    {
        private Animation m_dead;
        private Vector2 m_position;
        private Vector2 m_velocity;
        private Rectangle m_localBounds;
        private AnimationHandler m_sprite;

        public Rectangle GetBoundingRectangle()
        {
            int left = (int)Math.Round(m_position.X - m_sprite.GetOrigin().X) + m_localBounds.X;
            int top = (int)Math.Round(m_position.Y - m_sprite.GetOrigin().Y) + m_localBounds.Y;

            return new Rectangle(left, top, m_localBounds.Width, m_localBounds.Height);
        }

        public void LoadContent()
        {
            
        }

    }
}
