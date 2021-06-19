using System;
using System.Collections.Generic;

namespace Snake
{
    class Controller
    {
        public void ChangePlayerAndReplaceBots(UpdatableObjects updatableObjects)
        {
            Player player = null;
            Player currentPlayer = updatableObjects.GetPlayer();
            Random rand = new Random();
            int r = rand.Next(0, updatableObjects.GetBots().Count);

            player = updatableObjects.GetBots()[r];
            ReplaceBotAndChangeStatus(currentPlayer,player);
            
        }
        private void ReplaceBotAndChangeStatus(Player currentPlayer,Player player)
        {
            if (currentPlayer == null || player == null)
                return;
            currentPlayer.SetIsPlayer(false);
            player.SetIsPlayer(true);
        }
    }
}
