using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Game manager for the game, doh
/// </summary>
public class GameManager : MonoBehaviour
{
    /************************* VARIABLES ****************************/
    //PUBLIC
    public TextMeshProUGUI Scor; //Score text
    public TextMeshProUGUI GameOverText; //GameOver text
    public TextMeshProUGUI LevelSpeed; //Level Text (actualy gravity *10)
    public bool canSpawn = true; //Flag that will stop spawning of food items
    public float Gravity; //gravity of food. used to increase speed
    public string GravityState; //states that the gravity could be
    public int numberOfSpawns = 1; //number of simultaneous spawned food items
    //PRIVATE
    private int scor = 0; //the score
    private GlobalObject GO; //GlobalObject
    private SpawnManager spawnerManager; //The spawner manager that spawns the food items

    private float gravitySpeedIncrement = 0.05F; //it will be added to Gravity so the food will fall faster
    private Hashtable levelToSpawnTable; //keep the correlation betwen the level and the spawn delay
    private Hashtable numberOfSpawnsPerLevel; //correlation betwen the level and number of spawn elements
    private IEnumerator GameOverDelayCorotine; //Adds a delay before changing sceene to GameOver
    private IEnumerator IncreaseDifficultyCorotine; //Increase gravity over time
    private int increaseDifficultyDelay = 10; //will increment increase difficulty every 10 seconds
                                              //maybe not a fix value?
    private string NORMAL = "normal";
    private string PAUSE = "pause";
    private string SLOW = "slow";
    private string RESUME = "resume";
    /*********************** END OF VARIABLES ***********************/

    void Start()
    {
        //GlobalObject reference
        GO = GlobalObject.Instance;
        GO.InitQuitDialog();

        GameObject _spawnM = GameObject.Find("SpawnManager");
        spawnerManager = _spawnM.GetComponent<SpawnManager>();
        spawnerManager.StartSpawning();
        GameOverText.alpha = 0;

        Gravity = 0.5F;
        GravityState = NORMAL;

        DefineLevelToSpawnHash();
        IncreaseDifficulty();
    }

    /// <summary>
    /// Set the score
    /// </summary>
    /// <param name="value">integer</param>
    public void SetScore(int value) {
        scor = value;
        UpdateScore();
    }

    /// <summary>
    /// Increase the score with given value
    /// </summary>
    /// <param name="value">integer</param>
    public void IncreaseScore(int value)
    {
        scor += value;
        UpdateScore();
    }

    /// <summary>
    /// Double the score for Bonus Food
    /// </summary>
    public void DoubleScore() {
        if (scor == 0) scor = 50; else scor *= 2;
        UpdateScore();
    }

    /// <summary>
    /// Updates the score in the scene and in the GO
    /// </summary>
    private void UpdateScore() {
        Scor.text = scor.ToString();
        GO.score = scor;
    }

    /// <summary>
    /// Prepare GameOver
    /// - set False canSpawn boolean
    /// - set visible GameOver text
    /// - start corotine with 3 seconds delay to GameOver scene
    /// </summary>
    public void GameOver() {
        canSpawn = false;
        GameOverText.alpha = 1;
        spawnerManager.DestroyAll();
        GameOverDelayCorotine = ChangeSceneToEndGame();
        StartCoroutine(GameOverDelayCorotine);
    }

    /// <summary>
    ///  Change scene to GameOver in 3 seconds
    /// </summary>
    /// <returns></returns>
    private IEnumerator ChangeSceneToEndGame() {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(2);
    }

    /// <summary>
    /// Keep the correlation betwen the level and the spawn delay
    /// </summary>
    private void DefineLevelToSpawnHash() {
        levelToSpawnTable = new Hashtable(){
            {"4", 1.8f },
            {"6", 1.6f },
            {"8", 1.4f },
            {"10", 1.0f },
            {"12", 0.9f },
            {"14", 0.8f },
            {"16", 0.7f },
            {"18", 0.6f },
            {"20", 0.5f },
            {"22", 0.4f },
            {"24", 0.3f },
            {"25", 0.2f },
            {"26", 0.1f },
        };

        numberOfSpawnsPerLevel = new Hashtable(){      
            {"9", 2 },
            {"16", 3 },
            {"20", 4 },
            {"26", 5 }
        };
    }

    /// <summary>
    /// Declare corotine
    /// </summary>
    private void IncreaseDifficulty() {
        IncreaseDifficultyCorotine = IncreaseGravity();
        StartCoroutine(IncreaseDifficultyCorotine);
    }


    /// <summary>
    /// Increase gravity over time - increaseDifficultyDelay with gravitySpeedIncrement
    /// Sets the Level by  Mathf.Round(Gravity * 10)
    /// Checks the levelToSpawnTable for level and if found sets the new (smaller) spawn interval
    /// </summary>
    /// <returns></returns>
    private IEnumerator IncreaseGravity() {
        while (canSpawn)
        {
            Gravity += gravitySpeedIncrement;
            string _level = Mathf.Round(Gravity * 10).ToString();
            LevelSpeed.text = _level;

            //increase spawn rate
            if (levelToSpawnTable.Contains(_level)) {
                //print("Spawn Speed: " +levelToSpawnTable[_level]);
                spawnerManager.SetSpawnInterval((float)levelToSpawnTable[_level]);
            }

            if (numberOfSpawnsPerLevel.Contains(_level)){
                numberOfSpawns = (int)numberOfSpawnsPerLevel[_level];
            }

            yield return new WaitForSeconds(increaseDifficultyDelay);
        }
    }

    /// <summary>
    /// change the state of gravity to be used in the Food addForce falling
    /// </summary>
    /// <param name="STATE">NORMAL,PAUSE,SLOW,RESUME</param>
    public void SetGravityState(string STATE) {
        GravityState = STATE;
    }
}
