using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// GameOverManager 
/// Displays the score and Highscore from GO
/// Saves the highscore
/// </summary>
public class GameOverManager : MonoBehaviour
{
    /************************* VARIABLES ****************************/
    //PUBLIC
    public TextMeshProUGUI Scor;
    public TextMeshProUGUI HighScoreText;

    //PRIVATE
    private GlobalObject GO;
    /*********************** END OF VARIABLES ***********************/


    void Start()
    {
        GO = GlobalObject.Instance;
        GO.InitQuitDialog();
        
        Scor.text = GO.score.ToString() + " points";

        GO.GetHighscore();
        HighScoreText.text = GO.highscore.ToString();
        GO.SaveHighscore();
    }
}
