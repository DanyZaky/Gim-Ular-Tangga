using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeLeft;
    public string timeDisplay;
    public bool isTimerStart;
    public GameControl _gc;

    public int mins = 0;
    public int secs = 0;

    public TextMeshProUGUI timerText;

    // Start is called before the first frame update
    void Start()
    {
        isTimerStart = true;
    }

    // Update is called once per frame
    void Update()
    {
        Countdown();
        CheckObjective();
    }

    void CheckObjective()
    {
        if ((timeLeft <= 0  || _gc.points > 70))
        {
            isTimerStart = false;
            timeLeft = 0;
            if (!_gc.isSoalShown && !_gc.isGameOver)
            {
                _gc.CalculateStageClear();
            }            
        }
    }

    void Countdown()
    {
        if (isTimerStart)
        {
            timeLeft -= Time.deltaTime;
            TimetoDisplay();
        }
    }
    void TimetoDisplay()
    {
        mins = (int)(timeLeft / 60);
        secs = (int)(timeLeft % 60);
        string ssecs;
        string smins;
        if (secs < 10){ ssecs = "0" + secs; } else { ssecs = secs.ToString(); }
        if (mins < 10){ smins = "0" + mins; } else { smins = mins.ToString(); }
        timeDisplay = "Waktu: " + smins + ":" + ssecs;
        //if (secs < 10)
        //{
        //    timeDisplay = "Waktu: " + "0" + mins + ":" + "0" + secs;
        //}
        //else
        //{
        //    timeDisplay = "Waktu: " + "0" + mins + ":" + secs;
        //}       
        timerText.text = timeDisplay;
    }
}
