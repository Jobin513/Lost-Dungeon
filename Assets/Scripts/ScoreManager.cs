using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoreText;
    public static TMP_Text highscoreText;
    public static ScoreManager instance;
    public static int score = 0;
    public int displayscore = 0;
    public static int highscore = 0;

    private void Awake()
    {
        // Ensure that only one instance of ScoreManager exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Mark the GameObject as persistent
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }
    private  void Start()
    {
        scoreText.text = displayscore.ToString() + " POINTS";
    }
  
    // Start is called before the first frame update
    public void AddPoint()
    {
        score += 1;
        displayscore += 1;
       
    }
  
    public void GetScore()
    {
        scoreText.text = score + " POINTS";
    }

    private void Update()
    {
        GetScore();
    }
}
