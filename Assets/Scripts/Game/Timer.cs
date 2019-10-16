using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Timer class
/// </summary>
public class Timer : MonoBehaviour
{
    /************************* VARIABLES ****************************/
    //PUBLIC
    public TextMeshProUGUI timerText;

    //PRIVATE
    float minutes = 0f;
    float seconds = 0f;
    float milliseconds = 0f;
    string minutesS = "";
    string secondsS = "";
    string millisecondsS = "";
    private GameManager GM;
    /*********************** END OF VARIABLES ***********************/

    private void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        UpdateTimerUI();
    }

    /// <summary>
    /// Updates the UI Timer if GM.canSpawn = true;
    /// </summary>
    private void UpdateTimerUI()
    {
        if (!GM.canSpawn) return;
        if (milliseconds >= 100)
           {
                if (seconds >= 59)
                {
                    minutes++;
                    seconds = 0;
                }
                else if (seconds < 59)
                {
                    seconds++;
                }
                milliseconds = 0;
            }
            milliseconds += Time.deltaTime * 100;
            if (minutes < 10)
            {
                minutesS = "0" +minutes;
            }
            else
            {
                minutesS = "" +minutes;
            }

            if (seconds < 10)
            {
                secondsS = "0" +seconds;
            }
            else
            {
                secondsS = "" +seconds;
            }

            if ((int)milliseconds < 10)
            {
                millisecondsS = "0" +(int)milliseconds;
            }
            else
            {
                millisecondsS = "" +(int)milliseconds;
            }

        timerText.text = minutesS +":"+ secondsS +":"+ millisecondsS;
    }

}


