using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGame
{

    public class InputHandler
    {
        /// <summary>
        /// The last keyboard state
        /// </summary>
        private KeyboardState lastKeyboardState;
        /// <summary>
        /// The current keyboard state
        /// </summary>
        private KeyboardState currentKeyboardState;

        /// <summary>
        /// The last mouse
        /// </summary>
        private MouseState lastMouse;
        /// <summary>
        /// The current mouse
        /// </summary>
        private MouseState currentMouse;

        /// <summary>
        /// The mouse delta x
        /// </summary>
        private int mouseDeltaX;
        /// <summary>
        /// The mouse delta y
        /// </summary>
        private int mouseDeltaY;

        /// <summary>
        /// The last pad state
        /// </summary>
        private GamePadState lastPadState;
        /// <summary>
        /// The current pad state
        /// </summary>
        private GamePadState currentPadState;


        /// <summary>
        /// Initializes a new instance of the <see cref="InputHandler"/> class.
        /// </summary>
        public InputHandler()
        {
            currentKeyboardState = Keyboard.GetState();
            currentMouse = Mouse.GetState();
            currentPadState = GamePad.GetState(0);
            Update();
        }

        /// <summary>
        /// Updates this instance.
        /// </summary>
        public void Update() 
        {
            lastKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();
            lastMouse = currentMouse;
            currentMouse = Mouse.GetState();

            if(currentPadState.IsConnected)
            {
                lastPadState = currentPadState;
                currentPadState = GamePad.GetState(0);
            }
        }

        /// <summary>
        /// Checks if a key is pressed.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public bool KeyPressed(Keys key)
        {
            if(lastKeyboardState.IsKeyUp(key) && currentKeyboardState.IsKeyDown(key))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks is a key is down.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public bool KeyDown(Keys key)
        {
            if(lastKeyboardState.IsKeyDown(key))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if mouse left pressed.
        /// </summary>
        /// <returns></returns>
        public bool MouseLeftPressed()
        {
            if(lastMouse.LeftButton == ButtonState.Released && currentMouse.LeftButton == ButtonState.Pressed)
            {
                return true;
            }         
            return false;
        }

        /// <summary>
        /// Check if mouse left down.
        /// </summary>
        /// <returns></returns>
        public bool MouseLeftDown()
        {
            if(currentMouse.LeftButton == ButtonState.Pressed)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if mouse right down.
        /// </summary>
        /// <returns></returns>
        public bool MouseRightDown()
        {
            if(currentMouse.RightButton == ButtonState.Pressed)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if mouse right pressed.
        /// </summary>
        /// <returns></returns>
        public bool MouseRightPressed()
        {
            if(lastMouse.RightButton == ButtonState.Released && currentMouse.RightButton == ButtonState.Pressed)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Check if game pad A button pressed.
        /// </summary>
        /// <returns></returns>
        public bool GamePadAPressed()
        {
            if(lastPadState.IsButtonUp(Buttons.A) && currentPadState.IsButtonDown(Buttons.A))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Check if game pad X button pressed.
        /// </summary>
        /// <returns></returns>
        public bool GamePadXPressed()
        {
            if (lastPadState.IsButtonUp(Buttons.X) && currentPadState.IsButtonDown(Buttons.X))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if game pad Y button pressed.
        /// </summary>
        /// <returns></returns>
        public bool GamePadYPressed()
        {
            if (lastPadState.IsButtonUp(Buttons.Y) && currentPadState.IsButtonDown(Buttons.Y))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if game pad B button pressed.
        /// </summary>
        /// <returns></returns>
        public bool GamePadBPressed()
        {
            if (lastPadState.IsButtonUp(Buttons.B) && currentPadState.IsButtonDown(Buttons.B))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Gets the right thumb stick.
        /// </summary>
        /// <returns></returns>
        public Vector2 GetRightTS()
        {
            return currentPadState.ThumbSticks.Right;
        }

        /// <summary>
        /// Gets the left thumbstick.
        /// </summary>
        /// <returns></returns>
        public Vector2 GetLeftTS()
        {
            return currentPadState.ThumbSticks.Left;
        }

        /// <summary>
        /// Checks if game pad left trigger pressed.
        /// </summary>
        /// <returns></returns>
        public bool GamePadLTPressed()
        {
            if (lastPadState.Triggers.Left == 0 && currentPadState.Triggers.Left > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if game pad right trigger pressed.
        /// </summary>
        /// <returns></returns>
        public bool GamePadRTPressed()
        {
            if (lastPadState.Triggers.Right == 0 && currentPadState.Triggers.Right > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Gets the current mouse.
        /// </summary>
        /// <returns></returns>
        public MouseState GetCurrentMouse()
        {
            return currentMouse;
        }


    }
}
