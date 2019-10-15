using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Redirect to Menu or restart the game
/// </summary>
public class RedirectButtons : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void MenuScreen()
    {
        SceneManager.LoadScene(0);
    }
}
