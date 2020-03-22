using System;
using System.Collections.Generic;
using UnityEngine;

namespace SnakesAndLadders
{
    internal class Game
    {
        public Action OnNewGame;
        public Action OnWaitingForRoll;
        public Action<int> OnDiceRolled;        // Dice Value
        public Action<int, int> OnMovePlayer;   // PlayerId, PlaceId
        public Action<bool> OnGameOver;         // True = You win

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

        public void Init()
        {
            board.SetupFromView();
        }

        internal void StartNew()
        {
            currentPlayer = players[0];
            turn.OnNextTurn += WaitForRoll;
            resetPlayers();
            turn.Reset();
        }

        internal void SetPlayers(List<Player> players)
        {
            this.players = players;
            for( int i = 0; i < players.Count; i++ )
                players[i].Id = i;

            turn.Setup(players.Count);
        }

        private void resetPlayers()
        {
            for( int i = 0; i < players.Count; i++ )
            {
                players[i].MoveTo(0);
            }
        }

        internal void WaitForRoll(int playerId)
        {
            OnWaitingForRoll?.Invoke();
            currentPlayer = players[playerId];
            currentPlayer.StartTurn();
        }

        internal void RollDice()
        {
            int d = dice.Roll();
            OnDiceRolled?.Invoke(d);
            movePlayer(d);
        }

        internal void PostMoveChecks()
        {
            // Game Over?
            if( board.ReachedEndPlace(currentPlayer.PlaceId) )
            {
                gameOver(currentPlayer.Id == 0);
                return;
            }

            // Snake or ladder?
            int jumpVal = board.SnakeOrLadderMoveOffset(currentPlayer.PlaceId);
            if( jumpVal != 0 )
                movePlayer(jumpVal);
            else
                turn.Next();
        }

        private void movePlayer(int jumpVal)
        {
            currentPlayer.MoveBy(jumpVal);

            // Reached end place?
            if( board.ReachedEndPlace(currentPlayer.PlaceId) )
                currentPlayer.MoveTo(board.EndPlace);

            OnMovePlayer?.Invoke(currentPlayer.Id, currentPlayer.PlaceId);
        }

        private void gameOver(bool humanWon)
        {
            turn.OnNextTurn -= WaitForRoll;
            OnGameOver?.Invoke(humanWon);
        }

        internal void Pause()
        {
            Time.timeScale = 0;
        }

        internal void UnPause()
        {
            Time.timeScale = 1;
        }
    }
}