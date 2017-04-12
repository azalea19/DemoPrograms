using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGame
{

    class ParticleEngine
    {
        /// <summary>
        /// The scale
        /// </summary>
        private float scale;

        /// <summary>
        /// Whether the emitter is enabled
        /// </summary>
        private bool enabled = false;

        /// <summary>
        /// The random generator
        /// </summary>
        private Random random;

        /// <summary>
        /// Gets or sets the emitter location.
        /// </summary>
        /// <value>
        /// The emitter location.
        /// </value>
        private Vector2 emitterLocation { get; set; }

        /// <summary>
        /// The particles
        /// </summary>
        private List<Particle> particles;

        /// <summary>
        /// The textures
        /// </summary>
        private List<Texture> textures;

        /// <summary>
        /// The particle stages
        /// </summary>
        private int particleStages;

        /// <summary>
        /// The start time
        /// </summary>
        float startTime;

        /// <summary>
        /// The particles per second to emit
        /// </summary>
        float particlesPerSecond;

        /// <summary>
        /// The particles created
        /// </summary>
        int particlesCreated;

        /// <summary>
        /// Initializes a new instance of the <see cref="ParticleEngine"/> class.
        /// </summary>
        /// <param name="textures">The textures.</param>
        /// <param name="location">The location.</param>
        /// <param name="particleStages">The particle stages.</param>
        /// <param name="scale">The scale.</param>
        /// <param name="particlesPerSecond">The particles per second.</param>
        public ParticleEngine(List<Texture> textures, Vector2 location, int particleStages, float scale, float particlesPerSecond)
        {
            this.particleStages = particleStages;
            this.scale = scale;
            this.textures = textures;
            emitterLocation = location;
            particles = new List<Particle>();            
            random = new Random();         
            startTime = 0;
            this.particlesPerSecond = particlesPerSecond;
            particlesCreated = 0;
        }

        /// <summary>
        /// Generates a new particle.
        /// </summary>
        /// <returns></returns>
        private Particle GenerateNewParticle()
        {
            Texture texture = textures[random.Next(textures.Count)];
            Vector2 position = emitterLocation;
            Vector2 velocity = new Vector2(1f * (float)(random.NextDouble() * 2 - 1), 1f * (float)(random.NextDouble() * 2 - 1));
            float angle = 0;
            float angularVelocity = 0.1f * (float)(random.NextDouble() * 2 - 1);
            Color color = Color.White;//new Color((float)m_random.NextDouble(), (float)m_random.NextDouble(), (float)m_random.NextDouble());
            float size = (float)(random.NextDouble() * 0.8 + 0.2) * scale;
            int ttl = 1 + random.Next(100,500);

            return new Particle(texture, position, velocity, angle, angularVelocity, color, size, ttl, particleStages);
        }

        /// <summary>
        /// Restarts the start time.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        public void Restart(float gameTime)
        {
            startTime = gameTime;
            particlesCreated = 0;
        }

        /// <summary>
        /// Sets the emitter location.
        /// </summary>
        /// <param name="location">The location.</param>
        public void SetEmitterLocation(Vector2 location)
        {
            emitterLocation = location;
        }

        /// <summary>
        /// Sets if particle emitter is enabled or disabled.
        /// </summary>
        /// <param name="value">if set to <c>true</c> [value].</param>
        public void SetEnabled(bool value)
        {
            enabled = value;
        }

        /// <summary>
        /// Updates the particle engine.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        public void Update(float gameTime)
        {
            float dt = gameTime - startTime;
            int newParticles = (int)(dt * particlesPerSecond) - particlesCreated;
            particlesCreated += newParticles;
            
            if(enabled)
            {
                for (int i = 0; i < newParticles; i++)
                {
                    particles.Add(GenerateNewParticle());
                }                
            }

            for (int particle = 0; particle < particles.Count; particle++)
            {
                particles[particle].Update();
                if (particles[particle].GetTimeToLive() <= 0)
                {
                    particles.RemoveAt(particle);
                    particle--;
                }
            }
        }

        /// <summary>
        /// Draws the particles.
        /// </summary>
        /// <param name="spriteBatch">The sprite batch.</param>
        /// <param name="camera">The camera.</param>
        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            for(int i =0; i < particles.Count; i++)
            {
                particles[i].Draw(spriteBatch, camera);
            }
        }
    }
}
