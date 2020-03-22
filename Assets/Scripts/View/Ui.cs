using System;
using UnityEngine;

public class Ui : MonoBehaviour
{
    public Action NewGame;
    public Action Pause;
    public Action UnPause;
    public Action HumanRoll;

    [SerializeField]
    private GameObject menuView;

    [SerializeField]
    private GameUi gameUi;

    [SerializeField]
    private GameObject pauseView;

    [SerializeField]
    private GameObject gameoverView;


    public void Init()
    {
        gameUi.Roll += RollClick;
    }


    public void DiceRolled(int diceValue)
    {
        gameUi.ShowDice(diceValue);
    }

    public void NextTurn(int playerId)
    {
        gameUi.UpdateTurn(playerId == 0);
    }


    // I'd use a screen manager on larger projects
    public void ShowMenuScreen()
    {
        showScreen(menuView);
    }

    public void ShowGameScreen()
    {
        showScreen(gameUi.gameObject);
    }

    public void ShowPauseScreen()
    {
        showScreen(pauseView);
    }

    public void ShowGameoverScreen()
    {
        showScreen(gameoverView);
    }


    private void showScreen(GameObject screenObject)
    {
        menuView.SetActive(menuView == screenObject);
        gameUi.gameObject.SetActive(gameUi.gameObject == screenObject);
        menuView.SetActive(menuView == screenObject);
        pauseView.SetActive(pauseView == screenObject);
        gameoverView.SetActive(gameoverView == screenObject);
    }

    // UI bound in editor

    public void NewGameClick()
    {
        ShowGameScreen();
        NewGame?.Invoke();
    }

    public void RollClick()
    {
        HumanRoll?.Invoke();
    }

    public void PauseClick()
    {
        Pause?.Invoke();
    }

    public void UnpauseClick()
    {
        UnPause?.Invoke();
    }

}
