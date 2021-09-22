using UnityEngine;
using TMPro;
using System.IO;
public class SoalController: MonoBehaviour
{
    public string pathSoal;
    public TextMeshProUGUI textSoal;

    private void Start()
    {
        ReadString();
    }

    public void ReadString()
    {
        string path = "Assets/Media/Soal/" + pathSoal + ".txt";
        StreamReader reader = new StreamReader(path);
        textSoal.text = reader.ReadToEnd();
        reader.Close();
    }
}
