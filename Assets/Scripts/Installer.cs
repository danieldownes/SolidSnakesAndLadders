using UnityEngine;
using System.Collections.Generic;

namespace SnakesAndLadders
{
    public class Installer : MonoBehaviour
    {
        [SerializeField]
        private Ui ui;

        [SerializeField]
        private GameView gameView;

        private void Start()
        {
            // Instigate
            Game game = new Game();
            IDice dice = new DiceUnityRandom();
            Board board = new Board();
            Turn turn = new Turn();
            Player human = new PlayerHuman();
            Player bot = new PlayerBot();
            IPause pause = new PauseUnityTimeScale();

            // Injections
            board.Inject(gameView, new List<Place>());
            game.Inject(board, dice, turn);
            game.SetPlayers(new List<Player> { human, bot });

            // Event bindings
            ui.OnNewGame += game.StartNew;
            ui.OnNewGame += gameView.ResetView;
            ui.OnPause += pause.Pause;
            ui.OnUnPause += pause.UnPause;

            turn.OnNextTurn += ui.NextTurn;
            //game.OnWaitingForRoll + turn.StartNext;
            ui.OnHumanRoll += game.RollDice;
            bot.OnRoll += game.RollDice;
            game.OnDiceRolled += ui.DiceRolled;
            game.OnMovePlayer += gameView.PositionPlayer;
            gameView.OnMoveCompleted += game.PostMoveChecks;
            game.OnGameOver += ui.ShowGameoverScreen;

            // Initialise
            ui.Init();
            gameView.Init();
            game.Init();

            // Run
            ui.ShowMenuScreen();

        }
    }
}