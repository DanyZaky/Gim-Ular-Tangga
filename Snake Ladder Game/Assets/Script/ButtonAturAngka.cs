using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAturAngka : MonoBehaviour
{
    public Dice _dc;

    public void SetAngkaAcak(int angka)
    {
        _dc.diceMin = angka;
        _dc.diceMax = angka + 1;
    }


    public void SetAcak()
    {
        _dc.diceMin = 1;
        _dc.diceMax = 7;
    }
}
