using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public InputField _iField;
    public bool isNameAllowed;
    public GameObject warningWindow;

    private void Update()
    {
        NicknameCheck();
    }

    public void ButtonMulai()
    {
        print(_iField.text);
        if (isNameAllowed)
        {
            PlayerPrefs.SetString("PlayerName", _iField.text);
            LoadScene();
        }        
    }

    void NicknameCheck()
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

    private void LoadScene()
    {
        PlayerPrefs.SetString("NewScene", "GameplayScene");
        SceneManager.LoadScene("LoadingScene");
    }
}
