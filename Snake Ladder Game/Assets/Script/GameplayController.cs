using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameplayController : UIController
{
    public GameControl _gc;
    public TextMeshProUGUI playerName;
    public RectTransform pauseWindow, soalWindow, startWindow, winWindow, confirmWindow, confirmWindow2;
    public GameObject panelBG;

    private void Awake()
    {
        
    }

    private void Start()
    {
        SoundSystem.Instance.PlayBGM("BGMGameplay");
        playerName.text = PlayerPrefs.GetString("PlayerName");
    }

    public void ButtonSFXHit()
    {
        SoundSystem.Instance.PlaySFX("SFXHit");
    }

    public void ButtonOpenPause()
    {
        SoundSystem.Instance.PlaySFX("SFXHit");
        Time.timeScale = 0f;
        OnBGPanel();
        StartCoroutine(AnimationWideOut(pauseWindow, 0.15f));
    }

    public void ButtonRestart()
    {
        Time.timeScale = 1f;
        SoundSystem.Instance.PlaySFX("SFXHit");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OpenWinWindow()
    {
        OnBGPanel();
        StartCoroutine(AnimationWideOut(winWindow, 0.15f));
    }

    public void ButtonClosePause()
    {
        Time.timeScale = 1f;
        SoundSystem.Instance.PlaySFX("SFXHit");
        OffBGPanel();
        StartCoroutine(AnimationWideIn(pauseWindow, 0.15f));
    }

    public void OpenSoalWindow()
    {
        OnBGPanel();
        StartCoroutine(AnimationWideOut(soalWindow, 0.15f));
    }
    public void CloseSoalWindow()
    {
        OffBGPanel();
        StartCoroutine(AnimationWideIn(soalWindow, 0.15f));
    }

    public void OnBGPanel()
    {
        panelBG.SetActive(true);
    }

    public void OffBGPanel()
    {
        panelBG.SetActive(false);
    }

    public void OpenConfirmWindow()
    {
        SoundSystem.Instance.PlaySFX("SFXHit");
        //OnBGPanel();
        StartCoroutine(AnimationWideOut(confirmWindow, 0.15f));
    }

    public void CloseConfirmWindow()
    {
        SoundSystem.Instance.PlaySFX("SFXHit");
        //OffBGPanel();
        StartCoroutine(AnimationWideIn(confirmWindow, 0.15f));
    }

    public void OpenConfirmWindow2()
    {
        SoundSystem.Instance.PlaySFX("SFXHit");
        //OnBGPanel();
        StartCoroutine(AnimationWideOut(confirmWindow2, 0.15f));
    }

    public void CloseConfirmWindow2()
    {
        SoundSystem.Instance.PlaySFX("SFXHit");
        //OffBGPanel();
        StartCoroutine(AnimationWideIn(confirmWindow2, 0.15f));
    }

    public void CloseSoalImg()
    {
        _gc.isSoalShown = false;
    }
}
