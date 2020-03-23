using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SnakesAndLadders
{
    public class GameUi : MonoBehaviour
    {
        public Action OnRoll;

        public TextMeshProUGUI TurnLabel;
        public TextMeshProUGUI RollLabel;
        public Button RollButton;

        public void Init()
        {
            RollLabel.text = "Roll to start game";
            RollButton.interactable = true;
        }

        public void UpdateTurn(bool humansTurn)
        {
            if( humansTurn )
            {
                TurnLabel.text = "Your turn";
                RollLabel.text = "Press Roll";
                RollButton.interactable = true;
            }
            else
            {
                TurnLabel.text = "Bots turn";
            }
        }

        public void ShowDice(int dice)
        {
            RollLabel.text = dice.ToString();
        }

        public void RollClicked()
        {
            RollButton.interactable = false;
            OnRoll?.Invoke();
        }
    }
}