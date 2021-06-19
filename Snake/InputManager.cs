using System;
using SFML;
using SFML.System;
using SFML.Graphics;
using SFML.Window;

namespace Snake
{
    public class InputManager
    {
        private static Keyboard.Key key;
        private static bool wasPaused;
        public static bool WasPaused() => wasPaused;
        public static Vector2f GetKeyboardInput()
        {
            switch (key)
            {
                case Keyboard.Key.A:
                    return Vector2.left;
                case Keyboard.Key.S:
                    return Vector2.down;
                case Keyboard.Key.D:
                    return Vector2.right;
                case Keyboard.Key.W:
                    return Vector2.up;
            }
            
            return Vector2.right;
        }
        public static void OnKeyPressed(object sender, KeyEventArgs keyCode)
        {
            if (keyCode != null)
              key = keyCode.Code;

            if (key == Keyboard.Key.Escape)
            {
                if (wasPaused)
                    wasPaused = false;
                else
                    wasPaused = true;
            }
            Console.WriteLine(wasPaused);
        }
    }
}
