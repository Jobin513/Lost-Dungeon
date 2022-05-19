using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveData : ScoreManager
{
    public TMPro.TextMeshProUGUI myScore;
    public TMPro.TextMeshProUGUI myName;
    public int currentScore;
    private int highScore;
  
    void Update()
    {
        //myScore.text = $"SCORE: {PlayerPrefs.GetInt("highscore")}";
        currentScore = ScoreManager.score;
        
        highScore = int.Parse(myScore.text);
        myScore.text = highScore.ToString();
    }

    public void SendScore()
    {
        if (currentScore > highScore /*PlayerPrefs.GetInt("highscore")*/)
        {
            PlayerPrefs.SetInt("highscore", currentScore);
            HighScores.UploadScore(myName.text, currentScore);
        }
    }
}
