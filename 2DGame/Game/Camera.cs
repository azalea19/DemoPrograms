using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGame
{

    public class Camera
    {
        /// <summary>
        /// The position
        /// </summary>
        private Vector2 position;
        /// <summary>
        /// The margin
        /// </summary>
        private float margin;

        /// <summary>
        /// Initializes a new instance of the <see cref="Camera"/> class.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="margin">The margin.</param>
        public Camera(Vector2 position, float margin)
        {
            this.position = position;
            this.margin = margin;
        }

        /// <summary>
        /// Sets the position.
        /// </summary>
        /// <param name="position">The position.</param>
        public void SetPosition(Vector2 position)
        {
            this.position = position;
        }

        /// <summary>
        /// Sets the x value of the position.
        /// </summary>
        /// <param name="x">The x value.</param>
        public void SetX(float x)
        {
            this.position.X = x;
        }

        /// <summary>
        /// Sets the y value of the position.
        /// </summary>
        /// <param name="y">The y value.</param>
        public void SetY(float y)
        {
            this.position.Y = y;
        }

        /// <summary>
        /// Gets the position.
        /// </summary>
        /// <returns></returns>
        public Vector2 GetPosition()
        {
            return position;
        }

        /// <summary>
        /// Sets the margin.
        /// </summary>
        /// <param name="margin">The margin.</param>
        public void SetMargin(float margin)
        {
            this.margin = margin;
        }

        /// <summary>
        /// Gets the margin.
        /// </summary>
        /// <returns></returns>
        public float GetMargin()
        {
            return margin;
        }
    }
}
