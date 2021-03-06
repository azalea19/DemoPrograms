﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGame
{
    class Particle
    {
        public Texture2D m_texture { get; set; }
        public Vector2 m_position { get; set; }
        public Vector2 m_velocity { get; set; }
        public float m_angle { get; set; }
        public float m_angularVelocity { get; set; }
        public Color m_color { get; set; }
        public float m_size { get; set; }
        public int m_ttl { get; set; }
        public int m_numStages;

        public Particle(Texture2D texture, Vector2 position, Vector2 velocity, float angle, float angularVelocity, Color color, float size, int ttl, int numStages)
        {
            m_texture = texture;
            m_position = position;
            m_velocity = velocity;
            m_angle = angle;
            m_angularVelocity = angularVelocity;
            m_color = color;
            m_size = size;
            m_ttl = ttl;
            m_numStages = numStages;
        }

        public void Update()
        {
            m_ttl--;
            m_position += m_velocity;
            m_angle += m_angularVelocity;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRect = new Rectangle(0, 0, m_texture.Width, m_texture.Height);
            Vector2 origin = new Vector2(m_texture.Width / 2, m_texture.Height / 2);
            spriteBatch.Draw(m_texture, m_position, sourceRect, m_color, m_angle, origin, m_size, SpriteEffects.None, 0f);
        }
    }
}
