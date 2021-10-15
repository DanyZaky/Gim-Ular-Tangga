using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : UIController
{
    public InputField _iField;
    public bool isNameAllowed;
    public GameObject warningWindow, inputWindow;

    private void Update()
    {
        NicknameCheck();
    }

    public void ButtonMulai()
    {
        if (isNameAllowed)
        {
            print(_iField.text);
            PlayerPrefs.SetString("PlayerName", _iField.text);
            LoadScene("GameplayScene");
        }        
    }

    void NicknameCheck()
    {
        if (inputWindow.activeInHierarchy)
        {
            if (_iField.text.Length <= 12)
            {
                isNameAllowed = true;
                warningWindow.SetActive(false);
            }
            else
            {
                isNameAllowed = false;
                warningWindow.SetActive(true);
            }
        }        
    }

    
}
