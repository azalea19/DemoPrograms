using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGame
{
    class Crystal
    {
        Vector2 m_startPos;
        Vector2 m_endPos;
        Vector2 position;
        float m_tripTime;
        float m_timer;
        Texture texture;

        public Crystal(Vector2 startPosition, Vector2 endPosition, float tripTime)        
        {
            texture = Texture.Create("DarkForest/Crystals/s_9_glow1");
            position = startPosition;
            m_startPos = startPosition;
            m_endPos = endPosition;
            m_tripTime = tripTime;
            m_timer = 0;
            
        }

        public void Update(GameTime gameTime)
        {
            float t = (float)gameTime.ElapsedGameTime.TotalSeconds;
            m_timer += t;

            if (m_timer < m_tripTime)
            {
                //We are still moving from start pos to end pos
                position = Vector2.Lerp(m_startPos, m_endPos, m_timer / m_tripTime);               
            }
            else
            {
                m_timer = 0;
                Vector2 temp = m_startPos;
                m_startPos = m_endPos;
                m_endPos = temp;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            Rectangle sourceRect = new Rectangle(0, 0, texture.Width, texture.Height);
            Vector2 origin = new Vector2(texture.Width / 2, texture.Height / 2);
            spriteBatch.Draw(texture, position - camera.m_position, sourceRect, Color.White);
        }

    }
}

