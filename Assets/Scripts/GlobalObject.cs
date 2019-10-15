using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Global Object class, needs to be in every level.
/// </summary>
public class GlobalObject : MonoBehaviour 
{
    /************************* VARIABLES ****************************/
    //PUBLIC
    public static GlobalObject Instance;
    public int score = 0;
    public int highscore = 0;
    //PRIVATE
    private string HIGHSCORE = "HIGHSCORE";
    //Quit dialog box
    private GameObject quitDialog;
    private Canvas quitCanvas;
    private Button quitBtn;
    private Button cancelBtn;
    /*********************** END OF VARIABLES ***********************/

    //To have only on instance
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

    void Update()
    {
        //Quit
        if (Application.platform == RuntimePlatform.Android || Input.GetKeyDown(KeyCode.Escape))
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                quitDialog.SetActive(true);
            }
        }
    }

    /// <summary>
    /// Needs to get reference at the init of each Scene
    /// </summary>
    //Could be done better?
    public void InitQuitDialog() {
        quitDialog = GameObject.Find("QuitDialog");
        quitCanvas = quitDialog.GetComponent<Canvas>();
        quitBtn = GameObject.Find("quitBtn").GetComponent<UnityEngine.UI.Button>();
        cancelBtn = GameObject.Find("cancelBtn").GetComponent<UnityEngine.UI.Button>();

        quitBtn.onClick.AddListener(() => {
            print("*** [QUIT GAME] ***");
            Application.Quit();
        });
        cancelBtn.onClick.AddListener(() => {
            quitDialog.SetActive(false);
        });

        quitDialog.SetActive(false);
    }

    /// <summary>
    /// Get the highscore from PlayerPrefs
    /// </summary>
    public void GetHighscore() {
        //Get high score
        if (PlayerPrefs.HasKey(HIGHSCORE)) highscore = PlayerPrefs.GetInt(HIGHSCORE);
        else highscore = 0;
    }

    /// <summary>
    /// Sets the Highscore in PlayerPrefs if it is a new one
    /// </summary>
    public void SaveHighscore() {
        if(score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt(HIGHSCORE, score);
            PlayerPrefs.Save();
        }       
    }
}
