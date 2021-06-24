using System.Collections.Generic;
using SFML.System;
using System.Threading;

namespace Snake
{
    class ThreadManager 
    {
        public void InitAnimationThread(Player player)
        {
            Thread animThread = new Thread(new ThreadStart(player.Animation));
            animThread.Start();
        }

    }

}
