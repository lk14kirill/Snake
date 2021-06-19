using SFML.System;
using SFML.Graphics;
using System;
using System.Collections.Generic;

namespace Snake
{
    public class Food : CircleObject,IUpdatable,IDrawable
    {
        public Food()
        {
            SetRandomPosition(new Vector2f(Constants.windowX -10,Constants.windowY -10 ));
            SetRandomColor();
            SetRadius(5);
        }
        public void Update(Vector2f direction,List<Food> food,float time,Player player)
        {

        }
        public Drawable WhatToDraw()
        {
           return GetGO();
        }
    }
}
