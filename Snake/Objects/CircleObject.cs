using SFML.System;
using SFML.Graphics;
using System;

namespace Snake
{
    public class CircleObject :IDrawable
    {
        private byte r = 255, g, b;
        public byte colorR
        {
            get { return r; }
            set {
                gameObject.FillColor = new Color(value, g, b);
                r = value; 
                }
        }
        public byte colorG
        {
            get { return g; }
            set
            {
                gameObject.FillColor = new Color(r, value, b);
                g = value;
            }
        }
        public byte colorB
        {
            get { return b; }
            set
            {
                gameObject.FillColor = new Color(r, g, value);
                b = value;
            }
        }


        private bool canMove = true;
        private float speed = 0.2f;
        public CircleShape gameObject = new CircleShape();
        public CircleObject()
        {
            SetRadius(5);
            gameObject.FillColor = new Color(254, 0, 0);
        }
        public void ChangeColor()
        {
            if (colorR > 0 && colorB == 0)
            {
                colorR -= 1;
                colorG += 1;
            }
            if (colorG > 0 && colorR == 0)
            {
                colorG -= 1;
                colorB += 1;
            }
            if (colorB > 0 && colorG == 0)
            {
                colorB -= 1;
                colorR += 1;
            }
        }
        public void SetColor(Color color) => gameObject.FillColor = color;
        public Color GetColor() => gameObject.FillColor;
        public Drawable WhatToDraw()
        {
            return GetGO();
        }
        public void SetBoolCanMove(bool a) => canMove = a;
        public bool GetCanMove() => canMove;
        public void SetPosition(Vector2f vector)
        {
            if (canMove)
                gameObject.Position = new Vector2f(vector.X - GetRadius(), vector.Y - GetRadius());
        }
        public Vector2f GetPosition() => new Vector2f(gameObject.Position.X, gameObject.Position.Y);
        public void SetCenter(Vector2f vector) => gameObject.Position = new Vector2f(vector.X - GetRadius(), vector.Y-GetRadius());
        public Vector2f GetCenter() => new Vector2f(gameObject.Position.X + gameObject.Radius, gameObject.Position.Y + gameObject.Radius);
        public void SetRadius(float radius) => gameObject.Radius = radius;
        public float GetRadius() => gameObject.Radius;
        public CircleShape GetGO() => gameObject;
        public float GetSpeed() => speed;
        public void SetSpeed(float tempSpeed) => speed = tempSpeed;
        public void SetRandomPosition(Vector2f window)
        {
            Random rand = new Random();
            Vector2f vector = new Vector2f(rand.Next(0, (int)window.X),rand.Next(0, (int)window.Y));
            SetPosition(vector);
        }
        public void SetRandomColor()
        {
            Random rand = new Random();
            Color color = new Color((byte)rand.Next(0, 256), (byte)rand.Next(0, 256), (byte)rand.Next(0, 256));
            gameObject.FillColor = color;
        }
        public void MoveToward(Vector2f direction, float time)
        {
            if (direction != new Vector2f(0, 0) && GetCanMove())
            {
                    Vector2f directionTemp = new Vector2f(speed * time * direction.X ,
                                      speed * time * direction.Y );
                    gameObject.Position += directionTemp;
            }
        }
    }
}
