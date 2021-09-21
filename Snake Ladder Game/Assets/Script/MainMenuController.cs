using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public InputField _iField;

    public void ButtonMulai()
    {
        print(_iField.text);
        PlayerPrefs.SetString("PlayerName", _iField.text);
    }
}
