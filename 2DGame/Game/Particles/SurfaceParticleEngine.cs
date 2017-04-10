using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGame
{
    class SurfaceParticleEngine
    {
        private float m_scale;
        private bool enabled = false;
        private Random m_random;
        public Vector2 m_emitterLocation { get; set; }
        private List<Particle> m_particles;
        private List<Texture> m_textures;
        private int m_particleStages;
        float m_startTime;
        float m_particlesPerSecond;
        int m_particlesCreated;
        float m_width;


        public SurfaceParticleEngine(List<Texture> textures, Vector2 location, float width, int particleStages, float scale, float particlesPerSecond)
        {
            m_emitterLocation = location;
            m_particles = new List<Particle>();
            m_textures = textures;
            m_random = new Random();
            m_particleStages = particleStages;
            m_scale = scale;
            m_startTime = 0;
            m_particlesPerSecond = particlesPerSecond;
            m_particlesCreated = 0;
            m_width = width;

        }

        private Particle GenerateNewParticle()
        {
            Texture texture = m_textures[m_random.Next(m_textures.Count)];
            Vector2 position = new Vector2((float)m_random.NextDouble() * m_width + m_emitterLocation.X, m_emitterLocation.Y);
               
            Vector2 velocity = new Vector2(1f * (float)(m_random.NextDouble() * 2 - 1),  -1* Math.Abs(1f * (float)(m_random.NextDouble() * 2)));
            float angle = 0;
            float angularVelocity = 0.1f * (float)(m_random.NextDouble() * 2 - 1);
            Color color = Color.White;//new Color((float)m_random.NextDouble(), (float)m_random.NextDouble(), (float)m_random.NextDouble());
            float size = (float)(m_random.NextDouble() * 0.8 + 0.2) * m_scale;
            int ttl = 1 + m_random.Next(100, 500);

            return new Particle(texture, position, velocity, angle, angularVelocity, color, size, ttl, m_particleStages);
        }

        public void Restart(float gameTime)
        {
            m_startTime = gameTime;
            m_particlesCreated = 0;
        }

        public void SetEmitterLocation(Vector2 location)
        {
            m_emitterLocation = location;
        }

        public void SetEnabled(bool value)
        {
            enabled = value;
        }

        public void Update(float gameTime)
        {
            float dt = gameTime - m_startTime;
            int newParticles = (int)(dt * m_particlesPerSecond) - m_particlesCreated;
            m_particlesCreated += newParticles;

            if (enabled)
            {
                for (int i = 0; i < newParticles; i++)
                {
                    m_particles.Add(GenerateNewParticle());
                }
            }

            for (int particle = 0; particle < m_particles.Count; particle++)
            {
                m_particles[particle].Update();
                if (m_particles[particle].m_ttl <= 0)
                {
                    m_particles.RemoveAt(particle);
                    particle--;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            for (int i = 0; i < m_particles.Count; i++)
            {
                m_particles[i].Draw(spriteBatch, camera);
            }
        }
    }
}
