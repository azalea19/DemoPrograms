using Microsoft.Xna.Framework;
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
        /// <summary>
        /// The texture
        /// </summary>
        private Texture texture;

        /// <summary>
        /// The position
        /// </summary>
        private Vector2 position;

        /// <summary>
        /// The velocity
        /// </summary>
        private Vector2 velocity;

        /// <summary>
        /// The angle
        /// </summary>
        private float angle;

        /// <summary>
        /// The angular velocity
        /// </summary>
        private float angularVelocity;

        /// <summary>
        /// The color
        /// </summary>
        private Color color;

        /// <summary>
        /// The size
        /// </summary>
        private float size;

        /// <summary>
        /// The time to live
        /// </summary>
        private int ttl;

        /// <summary>
        /// The max time to live
        /// </summary>
        private int maxttl;

        /// <summary>
        /// The number of particle stages per particle
        /// </summary>
        public int numStages;

        /// <summary>
        /// Initializes a new instance of the <see cref="Particle"/> class.
        /// </summary>
        /// <param name="texture">The texture.</param>
        /// <param name="position">The position.</param>
        /// <param name="velocity">The velocity.</param>
        /// <param name="angle">The angle.</param>
        /// <param name="angularVelocity">The angular velocity.</param>
        /// <param name="color">The color.</param>
        /// <param name="size">The size.</param>
        /// <param name="ttl">The TTL.</param>
        /// <param name="numStages">The number of stages.</param>
        public Particle(Texture texture, Vector2 position, Vector2 velocity, float angle, float angularVelocity, Color color, float size, int ttl, int numStages)
        {
            this.texture = texture;
            this.position = position;
            this.velocity = velocity;
            this.angle = angle;
            this.angularVelocity = angularVelocity;
            this.color = color;
            this.size = size;
            this.ttl = ttl;
            maxttl = ttl;
            this.numStages = numStages;
        }

        /// <summary>
        /// Gets the time to live.
        /// </summary>
        /// <returns></returns>
        public int GetTimeToLive()
        {
            return ttl;
        }

        /// <summary>
        /// Updates this instance.
        /// </summary>
        public void Update()
        {
            ttl--;
            position += velocity;
            angle += angularVelocity;
        }

        /// <summary>
        /// Draws the particle.
        /// </summary>
        /// <param name="spriteBatch">The sprite batch.</param>
        /// <param name="camera">The camera.</param>
        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            Rectangle sourceRect = new Rectangle(0, 0, texture.Width, texture.Height);
            Vector2 origin = new Vector2(texture.Width / 2, texture.Height / 2);
            float alphaScale = (float)Math.Sqrt(ttl / (float)maxttl);
            spriteBatch.Draw(texture, position - camera.GetPosition(), sourceRect, color * alphaScale, angle, origin, size, SpriteEffects.None, 0f);
        }
    }
}
