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
            SetRandomPosition(new Vector2f(Constants.windowX, Constants.windowY));
            for (int i = 0; i < 39; i++)
            {
                IncreaseTail();
            }
        }
      
        public void Animation()
        {
            Clock clock = new Clock();
            while (true)
            {
                if (clock.ElapsedTime.AsSeconds() > 0.01f)
                {
                    clock.Restart();
                    ChangeColor();
                    foreach (CircleObject circle in tail)
                    {
                        circle.ChangeColor();
                    }
                }
            }
        }

        public void Update(Vector2f playerDirection,List<Food> food,float time,Player player, bool wasPaused)
        {   
            MoveToward(playerDirection, time);
            TryEatFood(food);
            MoveTail();
            //if(tail.Count >=15)
            //Intersect(wasPaused);
        }
        private void Intersect(bool wasPaused)
        {
            if(!wasPaused)
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
                Color color = tail[0].GetColor();
                circle.colorB = color.B;
                circle.colorG = color.G;
                circle.colorR = color.R;
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
