using UnityEngine.UI;
using UnityEngine;
using System.IO;

public class GameScore : MonoBehaviour
{
    [SerializeField] private Text TextCrystal;
    [SerializeField] private Text TextPlatfrom;

    public int ScoreCrystal { get; set; }
    public int ScorePlatform { get; set; }

    private void Start()
    {
        LoadingScore();
    }

    private void LoadingScore()
    {
        if (File.Exists(Application.dataPath + "/data/SSC.dat")) LoadScore();
        TextCrystal.text = $"{ScoreCrystal}";
        TextPlatfrom.text = $"{ScorePlatform}";
    }

    public void ChangeScoreCrystal(string act)
    {
        if (act == "addition")
        {
            ScoreCrystal++;
            TextCrystal.text = $"{ScoreCrystal}";
        }
    }

    public void ChangeScorePlatform(string act)
    {
        if (act == "addition")
        {
            ScorePlatform++;
            TextPlatfrom.text = $"{ScorePlatform}";
        }
    }

    public void SaveScore()
    {
        SALCrystal.SaveScoreCrystal(this);
    }

    private void LoadScore()
    {
        int[] dataScore = SALCrystal.LoadScoreCrystal();
        ScoreCrystal = dataScore[0];
    }
}