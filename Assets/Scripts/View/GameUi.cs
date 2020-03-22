using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUi : MonoBehaviour
{
    public Action Roll;

    public TextMeshProUGUI TurnLabel;
    public TextMeshProUGUI RollLabel;
    public Button RollButton;

    public void UpdateTurn(bool humansTurn)
    {
        if( humansTurn )
        {
            TurnLabel.text = "Your turn";
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
        Roll?.Invoke();
    }
}
