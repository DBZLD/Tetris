using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class CountClearLine : MonoBehaviour
{
    public Text text;
    public int ClearLine = 0;
    public string[] chClearLine = { "SINGLE", "DOUBLE", "TRIPLE", "TETRIS"};

    public float DuratioSec = 1f;
    public AnimationCurve AlphaCurve;

    public void SetText()
    {
        text.text = chClearLine[ClearLine - 1];
    }
    public void AddCount()
    {
        ClearLine++;
    }

    public void UpdateUI()
    {
        SetText();

        Color col = text.color;
        col.a = 0f;
        text.color = col;
        text.DOFade(1f, DuratioSec)
            .SetEase(AlphaCurve);
    }

    public void ResetCount()
    {
        ClearLine = 0;

    }
    private void Start()
    {
        Color col = text.color;
        col.a = 0f;
        text.color = col;
    }

}
