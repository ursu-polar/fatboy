using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private GlobalObject GO;
    public SpawnManager spawnerManager;
    public TextMeshProUGUI Scor;
    public TextMeshProUGUI GameOverText;
    public TextMeshProUGUI LevelSpeed;
    private int scor = 0;

    public bool canSpawn = true;

    public float Gravity;

    private float difficultyIncrement = 0.1F;

    private IEnumerator GameOverDelayCorotine;
    private IEnumerator IncreaseDifficultyCorotine;




    // Start is called before the first frame update
    void Start()
    {
        spawnerManager.StartSpawning();
        GameOverText.alpha = 0;
       
        GO = GlobalObject.Instance;

        IncreaseDifficulty();
    }

    public void SetScore(int value) {
        scor = value;
        UpdateScore();
    }

    public void IncreaseScore(int value)
    {
        scor += value;
        UpdateScore();
    }

    public void DoubleScore() {
        if (scor == 0) scor = 50; else scor *= 2;
        UpdateScore();
    }

    private void UpdateScore() {
        Scor.text = scor.ToString();
        GO.score = scor;
    }

    public void GameOver() {
        canSpawn = false;
        GameOverText.alpha = 1;
        spawnerManager.DestroyAll();
        GameOverDelayCorotine = ChangeSceneToEndGame();
        StartCoroutine(GameOverDelayCorotine);
    }

    private IEnumerator ChangeSceneToEndGame() {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(2);
    }

    private void IncreaseDifficulty() {
        IncreaseDifficultyCorotine = IncreaseGravity();
        StartCoroutine(IncreaseDifficultyCorotine);
    }

    private IEnumerator IncreaseGravity() {
        while (canSpawn)
        {
            Gravity += difficultyIncrement;
            LevelSpeed.text = (Gravity * 10).ToString();
            yield return new WaitForSeconds(10);
        }
    }



}
