using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{

    private GlobalObject GO;

    public TextMeshProUGUI HighScoreText;
    private void Start()
    {
        GO = GlobalObject.Instance;
        GO.GetHighscore();
        HighScoreText.text = GO.highscore.ToString();
    }
    public void PlayGame(){
        SceneManager.LoadScene(1);
    }
}
