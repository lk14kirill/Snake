using System;
using SFML.System;
using System.Collections.Generic;


namespace Snake
{
    public static class MathExt
    {
        public static float VectorLength(Vector2f firstVector, Vector2f secondVector)
        {
            return (float)Math.Sqrt(Math.Pow(secondVector.X - firstVector.X, 2) +
                                    Math.Pow(secondVector.Y - firstVector.Y, 2));
        }
        public static float GetPercentOf(float value, float percent)
        {
            return value / 100 * percent;
        }
        public static bool CheckForIntersect(CircleObject firstCircle, CircleObject secondCircle)     //Ricochets first circle
        {
            double distanceBetweenRadiuses = VectorLength(secondCircle.GetCenter(), firstCircle.GetCenter()); ;

            if (distanceBetweenRadiuses <= firstCircle.GetRadius() + secondCircle.GetRadius() / 2)
            {
                return true;
            }
            return false;
        }

    }
    public static class Vector2
    {
        public static Vector2f left = new Vector2f(-1, 0);
        public static Vector2f right = new Vector2f(1, 0);
        public static Vector2f up = new Vector2f(0, -1);
        public static Vector2f down = new Vector2f(0, 1);

        public static Vector2f upLeft = new Vector2f(-1, -1);
        public static Vector2f upRight = new Vector2f(1, -1);
        public static Vector2f downLeft = new Vector2f(-1, 1);
        public static Vector2f downRight = new Vector2f(1, 1);
    }
}
