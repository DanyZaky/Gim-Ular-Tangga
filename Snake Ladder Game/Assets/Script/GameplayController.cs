using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameplayController : UIController
{
    public TextMeshProUGUI playerName;
    public RectTransform pauseWindow;
    public GameObject panelBG;

    private void Awake()
    {
        
    }

    private void Start()
    {
        playerName.text = PlayerPrefs.GetString("PlayerName");
    }

    public void ButtonOpenPause()
    {
        OnBGPanel();
        StartCoroutine(AnimationWideOut(pauseWindow, 0.15f));
    }

    public void ButtonClosePause()
    {
        OffBGPanel();
        StartCoroutine(AnimationWideIn(pauseWindow, 0.15f));
    }

    void OnBGPanel()
    {
        panelBG.SetActive(true);
    }

    void OffBGPanel()
    {
        panelBG.SetActive(false);
    }
}
