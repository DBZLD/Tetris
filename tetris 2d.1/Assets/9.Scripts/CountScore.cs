using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountScore : MonoBehaviour
{
    public Text text;
    public int Score = 0;
    public int AddScore = 0;
    public void SetText()
    {
        text.text = "Score : " + Score.ToString();
        ResetAddScore();
    }
    public void GetAddScore(int ClearLine, int ComboCount)
    {
        if (ClearLine == 4)
        {
            AddScore = (100 * ComboCount);
        }
        else
        {
            AddScore = (ClearLine * (20 * ComboCount));
        }

        Score += AddScore;
        SetText();
    }

    public void ResetAddScore()
    {
        AddScore = 0;

    }
}
