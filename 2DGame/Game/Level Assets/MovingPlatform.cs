using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGame
{ 
    class MovingPlatform : Platform
    {
        Vector2 m_startPos;
        Vector2 m_endPos;
        float m_tripTime;
        float m_timer;

        public MovingPlatform(Texture texture, Vector2 startPosition, Vector2 endPosition, float tripTime)
            : base(texture,startPosition)
        {
            m_startPos = startPosition;
            m_endPos = endPosition;
            m_tripTime = tripTime;
            m_timer = 0;
        }

        public override void Update(GameTime gameTime)
        {
            float t = (float)gameTime.ElapsedGameTime.TotalSeconds;
            m_timer += t;

            if(m_timer < m_tripTime)
            {
                //We are still moving from start pos to end pos
                m_position = Vector2.Lerp(m_startPos, m_endPos, m_timer/m_tripTime);
            }
            else
            {
                m_timer = 0;
                Vector2 temp = m_startPos;
                m_startPos = m_endPos;
                m_endPos = temp;
            }                   
        }

    }
}
