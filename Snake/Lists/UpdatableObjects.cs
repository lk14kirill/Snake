using System.Collections.Generic;
using SFML.System;

namespace Snake
{
    public class UpdatableObjects
    {
        public List<IUpdatable> updatableObjects = new List<IUpdatable>();
         public List<IUpdatable> GetList() => updatableObjects;
    
        public List<Food> GetFood()
        {
            List<Food> foodList = new List<Food>();
            foreach (IUpdatable updatable in updatableObjects)
            {
                if (updatable is Food)
                {
                    Food food = (Food)updatable;
                        foodList.Add(food);
                }
            }
            return foodList;
        }
        public Player GetPlayer()
        {
            Player player = null;
            foreach (IUpdatable pl in updatableObjects)
            {

                if (pl is Player)
                {
                    Player tempPlayer = pl as Player;
                      player = tempPlayer;
                }
            }
            return player;
        }
        public void Add(IUpdatable updatable)
        {
            updatableObjects.Add(updatable);
        }
        public void Remove(IUpdatable updatable)
        {
            updatableObjects.Remove(updatable);
        }
        public void Update(Vector2f direction, List<Food> food, float time,Player player)
        {
            foreach (IUpdatable updatable in updatableObjects)
            {
                updatable.Update(direction, food, time,player);
            }
        }
    }
}
