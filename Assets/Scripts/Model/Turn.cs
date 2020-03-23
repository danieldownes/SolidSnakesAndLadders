using System;
using System.Collections.Generic;

namespace SnakesAndLadders
{
    public class Turn
    {
        public Action<int> OnNextTurn;

        private int playerIndex;
        private List<Player> players;

        public Player CurrentPlayer { get; private set; }

        public void Setup(List<Player> players)
        {
            this.players = players;
        }

        public void Reset()
        {
            playerIndex = 0;
            CurrentPlayer = players[playerIndex];
        }

        public void Next()
        {
            playerIndex++;
            if( playerIndex >= players.Count )
                playerIndex = 0;

            CurrentPlayer = players[playerIndex];
            CurrentPlayer.StartTurn();

            OnNextTurn?.Invoke(playerIndex);
        }

    }
}