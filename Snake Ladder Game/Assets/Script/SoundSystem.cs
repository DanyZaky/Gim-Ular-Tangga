using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour
{
    public static SoundSystem Instance { get; private set; }
    public Setting setting = new Setting();
    [Header("BGM")]
    public GameObject[] BGM;
    [Header("SFX")]
    public GameObject[] SFX;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //UpdateVolume();
    }

    private void UpdateVolume()
    {
        float BGMVolume = SoundSystem.Instance.setting.BgmVolume;
        float SFXVolume = SoundSystem.Instance.setting.SfxVolume;
        for (int i = 0; i < BGM.Length; i++)
        {
            BGM[i].GetComponent<AudioSource>().volume = BGMVolume;
        }

        for (int i = 0; i < SFX.Length; i++)
        {
            SFX[i].GetComponent<AudioSource>().volume = SFXVolume;
        }
    }

    public void PlaySFX(string name)
    {
        for (int i = 0; i < SFX.Length; i++)
        {

            if (SFX[i].name == name)
            {
                SFX[i].GetComponent<AudioSource>().Play();
            }
        }

    }

    public void PlayBGM(string name)
    {
        for (int i = 0; i < BGM.Length; i++)
        {
            BGM[i].GetComponent<AudioSource>().Stop();
        }

        for (int i = 0; i < BGM.Length; i++)
        {
            if (BGM[i].name == name)
            {
                BGM[i].GetComponent<AudioSource>().Play();
            }
        }

    }

    public void ButtonOnSFX()
    {
        SoundSystem.Instance.setting.SfxVolume = 1f;
    }

    public void ButtonOffSFX()
    {
        SoundSystem.Instance.setting.SfxVolume = 0f;
    }

    public void ButtonOnBGM()
    {
        SoundSystem.Instance.setting.BgmVolume = 1f;
    }

    public void ButtonOffBGM()
    {
        SoundSystem.Instance.setting.BgmVolume = 0f;
    }

    public class Setting
    {
        public float SfxVolume
        {
            get { return PlayerPrefs.GetFloat("sfxVolume"); }
            set { PlayerPrefs.SetFloat("sfxVolume", value); }
        }

        public float BgmVolume
        {
            get { return PlayerPrefs.GetFloat("bgmVolume"); }
            set { PlayerPrefs.SetFloat("bgmVolume", value); }
        }
    }
}