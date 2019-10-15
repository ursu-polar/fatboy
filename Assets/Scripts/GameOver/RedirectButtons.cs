using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RedirectButtons : MonoBehaviour
{
    public void RestartGame()
    {

        print("RestartGame");
        SceneManager.LoadScene(1);
    }
    public void MenuScreen()
    {
        print("MenuScreen");
        SceneManager.LoadScene(0);
    }
}
