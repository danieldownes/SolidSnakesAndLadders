using TMPro;
using UnityEngine;

public class GameOverUi : MonoBehaviour
{
    public TextMeshProUGUI Result;

    public void UpdateResult(bool humanWon)
    {
        if( humanWon == true)
            Result.text = "You Win!!!";
        else
            Result.text = "You Lose :(";
    }

}
