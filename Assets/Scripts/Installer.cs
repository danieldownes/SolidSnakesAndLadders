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
        ui.NewGame += game.StartNew;
        ui.Pause += game.Pause;
        ui.UnPause += game.UnPause;

        turn.NextTurn += ui.NextTurn;
        turn.NextTurn += game.WaitForRoll;
        ui.HumanRoll += game.RollDice;
        bot.Roll += game.RollDice;
        game.RolledDice += ui.DiceRolled;
        game.MovePlayer += gameView.PositionPlayer;
        gameView.PlayerMoveCompleted += game.CheckForSnakeOrLadder;

        // Initialise
        ui.Init();
        gameView.Init();


        // Dev helper
        game.StartNew();
        ui.ShowGameScreen();
    }


}
