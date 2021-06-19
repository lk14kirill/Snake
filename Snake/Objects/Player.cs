using SFML.System;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Snake
{
    public class Player : CircleObject,IUpdatable
    {
        private List<CircleObject> tail = new List<CircleObject>();
        private float speedModifier = 1;
        public Player()
        {
            SetRandomColor();
            SetRandomPosition(new Vector2f(Constants.windowX, Constants.windowY));
            for (int i = 0; i < 10; i++)
            {
                Eat();
            }
        }
        public void Update(Vector2f playerDirection,List<Food> food,float time,Player player)
        {   
            MoveToward(playerDirection, time);
            TryEatFood(food);
            MoveTail();
        }

        public  void TryEatFood(List<Food> foodList)
        {
            foreach (Food food in foodList)
            {
                if (MathExt.CheckForIntersect(this, food))
                {
                    Fabric.Instance.AddToObjectsToRemove(food);
                    if (GetRadius() < 400)
                        Eat();
                    return;
                }
            }
        }
        private int count = -1;
        Vector2f tempPos; Vector2f cachedPos;
        public void  MoveTail()
        {
            Vector2f tempPos; Vector2f cachedPos;
            cachedPos = GetCenter();
            foreach (CircleObject circle in tail)
            {
                tempPos = circle.GetCenter();
                circle.SetCenter(cachedPos);
                cachedPos = tempPos;
            }
        }
        public void Eat()
        {
            tail.Add(InitNewPartOfTail());
        }
        public CircleObject InitNewPartOfTail()
        {
            CircleObject circle = new CircleObject();
            
            Fabric.Instance.AddToObjectsToRegister(circle);
            if (tail.Count >1)
            {
                circle.SetCenter(tail[tail.Count-1].GetPosition());
                circle.gameObject.FillColor = tail[0].GetColor();
            }
            else
            {
                circle.SetCenter(GetCenter());
                circle.gameObject.FillColor = GetColor();
                SetRandomColor();
            }
            return circle;
        }
    }
}
