using System;

namespace SnakesAndLadders
{
    internal class Turn
    {
        public Action<int> NextTurn;

        private int playerIndex;
        private int playerCount;

        internal void Setup(int playerCount)
        {
            this.playerCount = playerCount;
        }

        internal void Reset()
        {
            playerIndex = 0;
            NextTurn?.Invoke(playerIndex);
        }

        public void Next()
        {
            playerIndex++;
            if( playerIndex >= playerCount )
                playerIndex = 0;

            NextTurn?.Invoke(playerIndex);
        }

    }
}