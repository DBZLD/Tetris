using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountCombo : MonoBehaviour
{
    public Text text;
    public int ComboCount = 0;
    public bool IsCombo = false;

    public void SetText()
    {
        text.text = ComboCount.ToString() + " Combo";
    }
    public void CheckCombo()
    {
        if(IsCombo == false)
        {
            IsCombo = true;
            ComboCount = 1;
        }
        else
        {
            ComboCount++;
            SetText();
        }
    }
    public void ResetCombo()
    {
        IsCombo = false;
        ComboCount = 0;
        text.text = "Combo";
    }
}
