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
    public GameObject warningWindow, inputWindow, bGPanel;
    public RectTransform peraturanWindow, nicknameWindow, confirmWindow;

    private void Update()
    {
        NicknameCheck();
    }

    private void Start()
    {
        SoundSystem.Instance.PlayBGM("BGMMainMenu");
    }

    public void ButtonMulai()
    {
        SoundSystem.Instance.PlaySFX("SFXHit");
        if (isNameAllowed)
        {
            //print(_iField.text);
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
        //else
        //{
        //    warningWindow.SetActive(false);
        //}        
    }

    public void ButtonWindowNickname()
    {
        SoundSystem.Instance.PlaySFX("SFXHit");
        StartCoroutine(AnimationWideOut(nicknameWindow, 0.15f));
        StartCoroutine(AnimationWideIn(peraturanWindow, 0.15f));
    }

    public void ButtonWindowPeraturan()
    {
        SoundSystem.Instance.PlaySFX("SFXHit");
        StartCoroutine(AnimationWideOut(peraturanWindow, 0.15f));
        StartCoroutine(AnimationWideIn(nicknameWindow, 0.15f));
    }

    public void OpenConfirmWindow()
    {
        SoundSystem.Instance.PlaySFX("SFXHit");
        bGPanel.SetActive(true);
        StartCoroutine(AnimationWideOut(confirmWindow, 0.15f));
    }

    public void CloseConfirmWindow()
    {
        SoundSystem.Instance.PlaySFX("SFXHit");
        bGPanel.SetActive(false);
        StartCoroutine(AnimationWideIn(confirmWindow, 0.15f));
    }

    public void CloseApp()
    {
        SoundSystem.Instance.PlaySFX("SFXHit");
        Application.Quit();
    }
}
