using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameplayController : MonoBehaviour
{
    public TextMeshProUGUI playerName;

    private void Awake()
    {
        
    }

    private void Start()
    {
        playerName.text = PlayerPrefs.GetString("PlayerName");
    }
}
