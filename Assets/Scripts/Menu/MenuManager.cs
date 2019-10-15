using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Manage Menu screen
/// Gets Highscore
/// </summary>
public class MenuManager : MonoBehaviour
{
    /************************* VARIABLES ****************************/
    //PUBLIC
    public TextMeshProUGUI HighScoreText;

    //PRIVATE
    private GlobalObject GO;
    /*********************** END OF VARIABLES ***********************/
    
    private void Start()
    {
        GO = GlobalObject.Instance;
        GO.InitQuitDialog();

        GO.GetHighscore();
        HighScoreText.text = GO.highscore.ToString();
    }
}
