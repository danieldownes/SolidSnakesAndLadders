using System;
using UnityEngine;

namespace SnakesAndLadders
{
    public class Ui : MonoBehaviour
    {
        public Action OnNewGame;
        public Action OnPause;
        public Action OnUnPause;
        public Action OnHumanRoll;

        [SerializeField]
        private GameObject menuView;

        [SerializeField]
        private GameUi gameUi;

        [SerializeField]
        private GameObject pauseView;

        [SerializeField]
        private GameOverUi gameoverView;

        public void Init()
        {
            gameUi.OnRoll += RollClick;
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

        public void ShowGameoverScreen(bool humanWon)
        {
            gameoverView.UpdateResult(humanWon);
            showScreen(gameoverView.gameObject);
        }

        private void showScreen(GameObject screenObject)
        {
            menuView.SetActive(menuView == screenObject);
            gameUi.gameObject.SetActive(gameUi.gameObject == screenObject);
            menuView.SetActive(menuView == screenObject);
            pauseView.SetActive(pauseView == screenObject);
            gameoverView.gameObject.SetActive(gameoverView.gameObject == screenObject);
        }

        // UI bound in editor

        public void NewGameClick()
        {
            gameUi.Init();
            ShowGameScreen();
            OnNewGame?.Invoke();
        }

        public void RollClick()
        {
            OnHumanRoll?.Invoke();
        }

        public void PauseClick()
        {
            ShowPauseScreen();
            OnPause?.Invoke();
        }

        public void UnpauseClick()
        {
            ShowGameScreen();
            OnUnPause?.Invoke();
        }
    }
}