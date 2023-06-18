using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameoverScore : MonoBehaviour
{
    public Text text;
    public int Score = 0;

    public void SetText(int GetScore)
    {
        Score = GetScore;

        text.text = "Your Score is " + Score.ToString();
    }
}
