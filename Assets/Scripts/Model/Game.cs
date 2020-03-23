using System;
using System.Collections.Generic;

namespace SnakesAndLadders
{
    public class Game
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

        public void StartNew()
        {
            resetPlayers();
            turn.Reset();
        }

        public void SetPlayers(List<Player> players)
        {
            this.players = players;
            for( int i = 0; i < players.Count; i++ )
                players[i].Id = i;

            turn.Setup(players);
        }

        private void resetPlayers()
        {
            for( int i = 0; i < players.Count; i++ )
            {
                players[i].MoveTo(0);
            }
        }

        public void RollDice()
        {
            int d = dice.Roll();
            OnDiceRolled?.Invoke(d);
            movePlayer(d);
        }

        public void PostMoveChecks()
        {
            if( checkGameOver() )
            {
                gameOver(turn.CurrentPlayer.Id == 0);
                return;
            }

            checkSnakeOrLadder();
        }

        private void checkSnakeOrLadder()
        {
            int jumpVal = board.SnakeOrLadderMoveOffset(turn.CurrentPlayer.PlaceId);
            if( jumpVal != 0 )
                movePlayer(jumpVal);
            else
                turn.Next();
        }

        private void movePlayer(int jumpVal)
        {
            turn.CurrentPlayer.MoveBy(jumpVal);

            // Reached end place?
            if( board.ReachedEndPlace(turn.CurrentPlayer.PlaceId) )
                turn.CurrentPlayer.MoveTo(board.EndPlace);

            OnMovePlayer?.Invoke(turn.CurrentPlayer.Id, turn.CurrentPlayer.PlaceId);
        }

        private bool checkGameOver()
        {
            return board.ReachedEndPlace(turn.CurrentPlayer.PlaceId);
        }

        private void gameOver(bool humanWon)
        {
            OnGameOver?.Invoke(humanWon);
        }
    }
}