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
        public int GetPoints() => tail.Count;
        public Player()
        {
            SetRandomColor();
            SetRandomPosition(new Vector2f(Constants.windowX, Constants.windowY));
            for (int i = 0; i < 9; i++)
            {
                IncreaseTail();
            }
        }
        public void Update(Vector2f playerDirection,List<Food> food,float time,Player player, bool wasPaused)
        {   
            MoveToward(playerDirection, time);
            TryEatFood(food);
            MoveTail();
            if(tail.Count >=15)
            Intersect();
        }
        private void Intersect()
        {
            for (int i = 7; i < tail.Count; i++)
            {
                if(MathExt.CheckForIntersect(this, tail[i]))
                {
                    Fabric.Instance.AddToObjectsToRemove(this);
                    foreach(CircleObject circle in tail)
                    {
                     Fabric.Instance.AddToObjectsToRemove(circle);
                    }
                    break;
                }
            }
        }
        public  void TryEatFood(List<Food> foodList)
        {
            foreach (Food food in foodList)
            {
                if (MathExt.CheckForIntersect(this, food))
                {
                    Fabric.Instance.AddToObjectsToRemove(food);
                        IncreaseTail();
                    return;
                }
            }
        }
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
        public void IncreaseTail()
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
