using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGame
{
    class Animation
    {
        private Texture2D m_texture;
        private int m_frameWidthInPixels;
        private int m_frameHeightInPixels;
        private float m_frameTime;
        private bool m_isLooping;

        public Animation(Texture2D texture, float frameTime, bool isLooping)
        {
            m_texture = texture;
            m_frameTime = frameTime;
            m_isLooping = isLooping;
        }

        public Texture2D GetTexture()
        {
            return m_texture;
        }

        public float GetFrameTime()
        {
            return m_frameTime;
        }

        public bool IsLooping()
        {
            return m_isLooping;
        }

        public int GetFrameCount()
        {
            //return m_texture.Width / m_frameWidthInPixels;
            return m_texture.Width / m_texture.Height;
        }

        public int GetFrameWidth()
        {
            //return m_frameWidthInPixels;
            return m_texture.Height;
        }

        public int GetFrameHeight()
        {
            //return m_frameHeightInPixels;
            return m_texture.Height;
        }
    }
}
