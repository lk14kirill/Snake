using System.Collections.Generic;
using SFML.System;
using System.Threading;

namespace Snake
{
    class ThreadManager : IUpdatable
    {
        private bool isSleeping;
        public bool IsSleeping
        {
            set
            {
                isSleeping = value;
            }
            get { return isSleeping; }
        }
        public void Update(Vector2f playerDirection, List<Food> food, float time, Player player, bool wasPaused)
        {
        }

    }

}
