﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGame
{
    class Platform
    {
        public Texture m_texture;
        public Vector2 m_position;

        public Platform(Texture texture, Vector2 position)
        {
            m_texture = texture;
            m_position = position;
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            Rectangle sourceRect = new Rectangle(0, 0, m_texture.Width, m_texture.Height);
            Vector2 origin = new Vector2(m_texture.Width / 2, m_texture.Height / 2);
            spriteBatch.Draw(m_texture, m_position - camera.m_position, sourceRect, Color.White);
        }

        public Texture GetTexture()
        {
            return m_texture;
        }

        public BoundingBox GetBoundingBox()
        {
            return new BoundingBox(new Vector2(m_texture.Width, m_texture.Height), m_position);
        }
    }
}