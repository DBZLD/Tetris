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
        text.text = "Score : " + (Score + AddScore).ToString();
        ResetAddScore();
    }
    public void GetAddScore(int ClearLine)
    {
        if (ClearLine == 4)
        {
            AddScore = 100;
        }
        else
        {
            AddScore = (ClearLine * 20);
        }
    }

    public void ResetAddScore()
    {
        AddScore = 0;

    }
}
