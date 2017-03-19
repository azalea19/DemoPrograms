using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGame
{
    class InputHandler
    {
        private KeyboardState lastKeyboardState;
        private KeyboardState currentKeyboardState;

        private MouseState lastMouse;
        private MouseState currentMouse;

        private int mouseDeltaX;
        private int mouseDeltaY;

        private GamePadState lastPadState;
        private GamePadState currentPadState;
        

        public InputHandler()
        {
            currentKeyboardState = Keyboard.GetState();
            currentMouse = Mouse.GetState();
            currentPadState = GamePad.GetState(0);
            Update();
        }

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

        public bool KeyPressed(Keys key)
        {
            if(lastKeyboardState.IsKeyUp(key) && currentKeyboardState.IsKeyDown(key))
            {
                return true;
            }
            return false;
        }

        public bool KeyDown(Keys key)
        {
            if(lastKeyboardState.IsKeyDown(key))
            {
                return true;
            }
            return false;
        }

        public bool MouseLeftPressed()
        {
            if(lastMouse.LeftButton == ButtonState.Released && currentMouse.LeftButton == ButtonState.Pressed)
            {
                return true;
            }         
            return false;
        }

        public bool MouseLeftDown()
        {
            if(currentMouse.LeftButton == ButtonState.Pressed)
            {
                return true;
            }
            return false;
        }

        public bool MouseRightDown()
        {
            if(currentMouse.RightButton == ButtonState.Pressed)
            {
                return true;
            }
            return false;
        }

        public bool MouseRightPressed()
        {
            if(lastMouse.RightButton == ButtonState.Released && currentMouse.RightButton == ButtonState.Pressed)
            {
                return true;
            }
            return false;
        }

        public bool GamePadAPressed()
        {
            if(lastPadState.IsButtonUp(Buttons.A) && currentPadState.IsButtonDown(Buttons.A))
            {
                return true;
            }
            return false;
        }

        public bool GamePadXPressed()
        {
            if (lastPadState.IsButtonUp(Buttons.X) && currentPadState.IsButtonDown(Buttons.X))
            {
                return true;
            }
            return false;
        }

        public bool GamePadYPressed()
        {
            if (lastPadState.IsButtonUp(Buttons.Y) && currentPadState.IsButtonDown(Buttons.Y))
            {
                return true;
            }
            return false;
        }

        public bool GamePadBPressed()
        {
            if (lastPadState.IsButtonUp(Buttons.B) && currentPadState.IsButtonDown(Buttons.B))
            {
                return true;
            }
            return false;
        }

        public Vector2 GetRightTS()
        {
            return currentPadState.ThumbSticks.Right;
        }

        public Vector2 GetLeftTS()
        {
            return currentPadState.ThumbSticks.Left;
        }

        public bool GamePadLTPressed()
        {
            if (lastPadState.Triggers.Left == 0 && currentPadState.Triggers.Left > 0)
            {
                return true;
            }
            return false;
        }

        public bool GamePadRTPressed()
        {
            if (lastPadState.Triggers.Right == 0 && currentPadState.Triggers.Right > 0)
            {
                return true;
            }
            return false;
        }


    }
}
