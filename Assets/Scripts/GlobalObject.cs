using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Global Object class, needs to be in every level.
/// </summary>
public class GlobalObject : MonoBehaviour 
{
    public static GlobalObject Instance;

    public int score = 0;
    public int highscore = 0;
    private string HIGHSCORE = "HIGHSCORE";

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        GetHighscore();

    }

    public void GetHighscore() {
        //Get high score
        if (PlayerPrefs.HasKey(HIGHSCORE)) highscore = PlayerPrefs.GetInt(HIGHSCORE);
        else highscore = 0;
    }
    public void SaveHighscore() {
        if(score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt(HIGHSCORE, score);
            PlayerPrefs.Save();
        }       
    }
}
