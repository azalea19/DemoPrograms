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
        //private Texture2D m_texture;

        //private int m_frameWidthInPixels;
        //private int m_frameHeightInPixels;

        private float m_frameTime;
        private bool m_isLooping;
        private TextureReel m_reel;

        public Animation(Texture2D texture, float frameTime, bool isLooping)
        {
            //m_texture = texture;
            m_frameTime = frameTime;
            m_isLooping = isLooping;
            m_reel = new TextureReel(texture);
        }

        public Animation(float frameTime, bool isLooping)
        {
            //m_texture = texture;
            m_frameTime = frameTime;
            m_isLooping = isLooping;
            m_reel = new TextureReel();
        }

        public void AddFrame(Texture2D texture)
        {
            m_reel.AddTexture(texture);
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
            //return m_texture.Width / m_texture.Height;
            return m_reel.GetFrameCount();
        }

        public int GetFrameWidth()
        {
            //return m_frameWidthInPixels;
            //return m_texture.Height;
            return m_reel.GetTextureWidth();
        }

        public int GetFrameHeight()
        {
            //return m_frameHeightInPixels;
            return m_reel.GetTextureHeight();
        }

        public Texture2D GetTexture(int index)
        {
            return m_reel.GetTexture(index);
        }
    }
}
