using UnityEngine;
using TMPro;
using System.IO;
using System;

public class SoalController: MonoBehaviour
{
    public int currentIndexSoal;
    public string currentAnswer;
    public string correctAnswer;
    public TextMeshProUGUI textSoal;
    public GameControl _gc;
    public GameObject imgSoal, imgCorrect, imgIncorrect;

    public string[] kunciJawaban;
    int[] imgSoalIndex;

    private void Awake()
    {
        imgSoalIndex = new int[] {10, 18, 23 };
        GetKunciJawaban();
    }

    public void GetSoal()
    {
        //string path = "Assets/Media/Soal/soal (" + _gc.playerStartWaypoint + ").txt";
        //currentIndexSoal = _gc.playerStartWaypoint;
        //currentAnswer = _gc.playerStartWaypoint.ToString();
        //correctAnswer = kunciJawaban[currentIndexSoal - 1];
        //StreamReader reader = new StreamReader(path);
        //textSoal.text = reader.ReadToEnd();
        //reader.Close();
        TextAsset file = Resources.Load("Soal/soal ("+ _gc.playerStartWaypoint+")") as TextAsset;
        string txt = file.ToString();
        currentIndexSoal = _gc.playerStartWaypoint;
        currentAnswer = _gc.playerStartWaypoint.ToString();
        correctAnswer = kunciJawaban[currentIndexSoal - 1];
        textSoal.text = txt;
        foreach (int element in imgSoalIndex)
        {
            if (currentIndexSoal == element)
            {
                imgSoal.SetActive(true);
            }
        }
    }

    void GetKunciJawaban()
    {
        TextAsset file = Resources.Load("Soal/kunci") as TextAsset;
        string txt = file.ToString();
        char[] separators = new char[] { ' ', ',' };
        kunciJawaban = txt.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        //string temp;
        //string path = "Assets/Media/Soal/kunci.txt";
        //StreamReader reader = new StreamReader(path);
        //temp = reader.ReadToEnd();
        //char[] separators = new char[] { ' ', ',' };
        //kunciJawaban = temp.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        //reader.Close();
    }

    public void ButtonAnswer(string answer)
    {
        SoundSystem.Instance.PlaySFX("SFXHit");
        currentAnswer += answer;
        imgSoal.SetActive(false);
        _gc._gpc.CloseSoalWindow();
        _gc.currentCheckTile.isAnswered = true;
        //_gc.isSoalShown = false;
        if (CheckAnswer())
        {
            SoundSystem.Instance.PlaySFX("SFXCorrect");
            imgCorrect.SetActive(true);
            _gc._gpc.OnBGPanel();
            _gc.points += 10;
            _gc.currentCheckTile.isAnswerCorrect = true;
            _gc.ColorBoard(true);
            print($"Soal {currentIndexSoal}, jawab {currentAnswer}, kunci {correctAnswer} : Correct");
        }
        else
        {
            SoundSystem.Instance.PlaySFX("SFXIncorrect");
            imgIncorrect.SetActive(true);
            _gc._gpc.OnBGPanel();
            _gc.currentCheckTile.isAnswerCorrect = false;
            _gc.ColorBoard(false);
            print($"Soal {currentIndexSoal}, jawab {currentAnswer}, kunci {correctAnswer} : Incorrect");
        }

        if (CheckIsLastSoal())
        {
            //_gc.isGameOver = true;
        }
        else
        {
            if (_gc.currentCheckTile.isLadder || _gc.currentCheckTile.isSnake)
            {
                _gc.CheckTile();
            }
            else if (!_gc.currentCheckTile.isAnswerCorrect)
            {
                if (_gc.playerEndWaypoint == 1) { }
                else
                {
                    _gc.ForceMovePlayer(_gc.playerEndWaypoint - 1);
                }
            }
        }

    }

    bool CheckAnswer()
    {        
        return  Array.Exists(kunciJawaban, jawaban => jawaban == currentAnswer);
    }

    bool CheckIsLastSoal()
    {
        if (_gc.playerEndWaypoint == _gc.waypoints.Length)
        {
            return true;
        } else
        {
            return false;
        }
    }
}
