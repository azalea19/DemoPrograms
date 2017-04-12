using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGame
{

    public class Animation
    {

        /// <summary>
        /// The frame time to display each frame of the animation
        /// </summary>
        private float frameTime;

        /// <summary>
        /// Whether the animation is looping
        /// </summary>
        private bool isLooping;

        /// <summary>
        /// The texture reel
        /// </summary>
        private TextureReel reel;

        /// <summary>
        /// Initializes a new instance of the <see cref="Animation"/> class.
        /// </summary>
        /// <param name="texture">The texture.</param>
        /// <param name="frameTime">The frame time.</param>
        /// <param name="isLooping">if set to <c>true</c> [is looping].</param>
        public Animation(Texture texture, float frameTime, bool isLooping)
        {           
            this.frameTime = frameTime;
            this.isLooping = isLooping;
            this.reel = new TextureReel(texture);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Animation"/> class.
        /// </summary>
        /// <param name="frameTime">The frame time.</param>
        /// <param name="isLooping">if set to <c>true</c> [is looping].</param>
        public Animation(float frameTime, bool isLooping)
        {
            this.frameTime = frameTime;
            this.isLooping = isLooping;
            this.reel = new TextureReel();
        }

        /// <summary>
        /// Adds a new frame to the animation.
        /// </summary>
        /// <param name="texture">The texture.</param>
        public void AddFrame(Texture texture)
        {
            reel.AddTexture(texture);
        }

        /// <summary>
        /// Gets the frame time.
        /// </summary>
        /// <returns></returns>
        public float GetFrameTime()
        {
            return frameTime;
        }

        /// <summary>
        /// Determines whether this animation is looping.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this animation is looping; otherwise, <c>false</c>.
        /// </returns>
        public bool IsLooping()
        {
            return isLooping;
        }

        /// <summary>
        /// Gets the frame count.
        /// </summary>
        /// <returns></returns>
        public int GetFrameCount()
        {          
            return reel.GetFrameCount();
        }

        /// <summary>
        /// Gets the width of the frame.
        /// </summary>
        /// <returns></returns>
        public int GetFrameWidth()
        {          
            return reel.GetTextureWidth();
        }

        /// <summary>
        /// Gets the height of the frame.
        /// </summary>
        /// <returns></returns>
        public int GetFrameHeight()
        {
            return reel.GetTextureHeight();
        }

        /// <summary>
        /// Gets the texture.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public Texture GetTexture(int index)
        {
            return reel.GetTexture(index);
        }
    }
}
