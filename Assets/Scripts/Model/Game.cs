using System;
using System.Collections.Generic;

namespace SnakesAndLadders
{
    internal class Game
    {
        public Action WaitingForRoll;
        public Action<int> RolledDice;
        public Action<int, int> MovePlayer;

        private Board board;
        private IDice dice;
        private Turn turn;

        private List<Player> players;
        private Player currentPlayer;

        public void Inject(Board board, IDice dice, Turn turn)
        {
            this.board = board;
            this.dice = dice;
            this.turn = turn;
        }

        internal void SetPlayers(List<Player> players)
        {
            this.players = players;
            for( int i = 0; i < players.Count; i++ )
                players[i].Id = i;

            turn.Setup(players.Count);
        }

        internal void StartNew()
        {
            board.SetupFromView();
            turn.Reset();
        }

        internal void WaitForRoll(int playerId)
        {
            WaitingForRoll?.Invoke();
            currentPlayer = players[playerId];
            currentPlayer.StartTurn();
        }

        internal void RollDice()
        {
            int d = dice.Roll();
            RolledDice?.Invoke(d);
            movePlayer(d);
        }

        internal void CheckForSnakeOrLadder()
        {
            int jumpVal = board.SnakeOrLadderMoveOffset(currentPlayer.PlaceId);
            if( jumpVal != 0 )
                movePlayer(jumpVal);
            else
                turn.Next();
        }

        private void movePlayer(int jumpVal)
        {
            currentPlayer.PlaceId += jumpVal;
            MovePlayer?.Invoke(currentPlayer.Id, currentPlayer.PlaceId);
        }

        internal void Pause()
        {
            throw new NotImplementedException();
        }

        internal void UnPause()
        {
            throw new NotImplementedException();
        }
    }
}