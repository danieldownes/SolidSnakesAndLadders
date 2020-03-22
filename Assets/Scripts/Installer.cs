using UnityEngine;
using SnakesAndLadders;
using System.Collections.Generic;

public class Installer : MonoBehaviour
{
    [SerializeField]
    private Ui ui;
    
    [SerializeField]
    private GameView gameView;

    void Start()
    {
        // Instigate
        Game game = new Game();
        IDice dice = new DiceUnityRandom();
        Board board = new Board();
        Turn turn = new Turn();
        Player human = new PlayerHuman();
        Player bot = new PlayerBot();

        // Injections
        board.Inject(gameView, new List<Place>());
        game.Inject(board, dice, turn);
        game.SetPlayers(new List<Player> { human, bot });

        // Event bindings
        ui.OnNewGame += game.StartNew;
        ui.OnNewGame += gameView.ResetView;
        ui.OnPause += game.Pause;
        ui.OnUnPause += game.UnPause;

        turn.OnNextTurn += ui.NextTurn;
        ui.OnHumanRoll += game.RollDice;
        bot.OnRoll += game.RollDice;
        game.OnDiceRolled += ui.DiceRolled;
        game.OnMovePlayer += gameView.PositionPlayer;
        gameView.OnMoveCompleted += game.PostMoveChecks;
        game.OnGameOver += ui.ShowGameoverScreen;

        // Initialise
        ui.Init();
        gameView.Init();

        // Run
        ui.ShowMenuScreen();

        return;

        // Dev helper
        game.StartNew();
        ui.ShowGameScreen();
    }


}
