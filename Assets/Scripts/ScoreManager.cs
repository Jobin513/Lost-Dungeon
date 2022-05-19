using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    public static TMP_Text scoreText;
    public static TMP_Text highscoreText;
    public static ScoreManager instance;
    public static int score = 0;
    public int displayscore = 0;
    public static int highscore = 0;

    private void Awake()
    {
        instance = this;
    }
    private  void Start()
    {

        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = displayscore.ToString() + " POINTS";
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();
    }
  
    // Start is called before the first frame update
    public void AddPoint()
    {
        score += 1;
        displayscore += 1;
        scoreText.text = score + " POINTS";
        if (highscore < score)
            PlayerPrefs.SetInt("highscore", score);
    }
  
    public int GetScore()
    {
        return score;
    }
}
