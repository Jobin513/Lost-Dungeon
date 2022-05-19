using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    /*
    //Leaderboard
    Vector2 leaderboardScroll = Vector2.zero;
    bool showLeaderboard = false;
    int currentScore = 0; 
    int previousScore = 0;
    float submitTimer; //Delay score submission for optimization purposes
    bool submittingScore = false;
    int highestScore = 0;
    int playerRank = -1;
    [System.Serializable]
    public class LeaderboardUser
    {
        public string username;
        public int score;
    }
    LeaderboardUser[] leaderboardUsers;

    //Leaderboard
    IEnumerator SubmitScore(int score_value)
    {
        submittingScore = true;

        print("Submitting Score...");

        WWWForm form = new WWWForm();
        form.AddField("email", userEmail);
        form.AddField("username", userName);
        form.AddField("score", score_value);

        using (UnityWebRequest www = UnityWebRequest.Post(rootURL + "score_submit.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                print(www.error);
            }
            else
            {
                string responseText = www.downloadHandler.text;

                if (responseText.StartsWith("Success"))
                {
                    print("New Score Submitted!");
                }
                else
                {
                    print(responseText);
                }
            }
        }

        submittingScore = false;
    }

    IEnumerator GetLeaderboard()
    {
        isWorking = true;

        WWWForm form = new WWWForm();
        form.AddField("email", userEmail);
        form.AddField("username", userName);

        using (UnityWebRequest www = UnityWebRequest.Post(rootURL + "leaderboard.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                print(www.error);
            }
            else
            {
                string responseText = www.downloadHandler.text;

                if (responseText.StartsWith("User"))
                {
                    string[] dataChunks = responseText.Split('|');
                    //Retrieve our player score and rank
                    if (dataChunks[0].Contains(","))
                    {
                        string[] tmp = dataChunks[0].Split(',');
                        highestScore = int.Parse(tmp[1]);
                        playerRank = int.Parse(tmp[2]);
                    }
                    else
                    {
                        highestScore = 0;
                        playerRank = -1;
                    }

                    //Retrieve player leaderboard
                    leaderboardUsers = new LeaderboardUser[dataChunks.Length - 1];
                    for (int i = 1; i < dataChunks.Length; i++)
                    {
                        string[] tmp = dataChunks[i].Split(',');
                        LeaderboardUser user = new LeaderboardUser();
                        user.username = tmp[0];
                        user.score = int.Parse(tmp[1]);
                        leaderboardUsers[i - 1] = user;
                    }
                }
                else
                {
                    print(responseText);
                }
            }
        }

        isWorking = false;
    }

    //Leaderboard
    void LeaderboardWindow(int index)
    {
        if (isWorking)
        {
            GUILayout.Label("Loading...");
        }
        else
        {
            GUILayout.BeginHorizontal();
            GUI.color = Color.green;
            GUILayout.Label("Your Rank: " + (playerRank > 0 ? playerRank.ToString() : "Not ranked yet"));
            GUILayout.Label("Highest Score: " + highestScore.ToString());
            GUI.color = Color.white;
            GUILayout.EndHorizontal();

            leaderboardScroll = GUILayout.BeginScrollView(leaderboardScroll, false, true);

            for (int i = 0; i < leaderboardUsers.Length; i++)
            {
                GUILayout.BeginHorizontal("box");
                if (leaderboardUsers[i].username == userName)
                {
                    GUI.color = Color.green;
                }
                GUILayout.Label((i + 1).ToString(), GUILayout.Width(30));
                GUILayout.Label(leaderboardUsers[i].username, GUILayout.Width(230));
                GUILayout.Label(leaderboardUsers[i].score.ToString());
                GUI.color = Color.white;
                GUILayout.EndHorizontal();
            }

            GUILayout.EndScrollView();
        }
        //Leaderboard
        if (showLeaderboard)
        {
            GUI.Window(1, new Rect(Screen.width / 2 - 300, Screen.height / 2 - 225, 600, 450), LeaderboardWindow, "Leaderboard");
        }
        if (!isLoggedIn)
        {
            showLeaderboard = false;
            currentScore = 0;
        }
        else
        {
            GUI.Box(new Rect(Screen.width / 2 - 65, 5, 120, 25), currentScore.ToString());

            if (GUI.Button(new Rect(5, 60, 100, 25), "Leaderboard"))
            {
                showLeaderboard = !showLeaderboard;
                if (!isWorking)
                {
                    StartCoroutine(GetLeaderboard());
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isLoggedIn)
        {
            //Submit score if it was changed
            if (currentScore != previousScore && !submittingScore)
            {
                if (submitTimer > 0)
                {
                    submitTimer -= Time.deltaTime;
                }
                else
                {
                    previousScore = currentScore;
                    StartCoroutine(SubmitScore(currentScore));
                }
            }
            else
            {
                submitTimer = 3; //Wait 3 seconds when it's time to submit again
            }

            //**Testing** Increase score on key press
            if (Input.GetKeyDown(KeyCode.Q))
            {
                currentScore += 5;
            }
        }
    }*/
}
