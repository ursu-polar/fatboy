using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class GameOverManager : MonoBehaviour
{

    private GlobalObject GO;

    public TextMeshProUGUI Scor;
    public TextMeshProUGUI HighScoreText;

    void Start()
    {
        GO = GlobalObject.Instance;
        Scor.text = GO.score.ToString() + " points";

        GO.GetHighscore();
        HighScoreText.text = GO.highscore.ToString();
        GO.SaveHighscore();
    }
   
}
