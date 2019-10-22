using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    /************************* VARIABLES ****************************/
    //PUBLIC
    public GameObject enemy;
    public GameObject life;
    public GameObject bonus;
    public float spawnLocationY;

    //PRIVATE
    private GameManager GM;
    private float spawnInterval;
    private GameObject newSpawn;
    private IEnumerator spawnCorotine;
    /*********************** END OF VARIABLES ***********************/

    private void Awake()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        spawnInterval = 2;
    }

    /// <summary>
    /// Start the corotin to spawn with delay Food items
    /// </summary>
    public void StartSpawning()
    {
        spawnCorotine = SpawnEnemy();
        StartCoroutine(spawnCorotine);
    }

    /// <summary>
    /// Spawn Enemys when the GM canSpawn flag is true
    /// Here are calculated the chances for each Food type (should be moved and improved)
    /// </summary>
    /// <returns></returns>
    private IEnumerator SpawnEnemy()
    {
       
        while (GM.canSpawn)
        {
            for (int i = 0; i < numberOfCSpawns; i++)
            {
                //print(0.8 - spawnInterval/10);
                //%30 percent chance (1 - 0.7 is 0.3)
                //Rethink this!
                if (Random.value > (0.9 - spawnInterval / 10))
                {
                    if (Random.value > 0.95)
                    {
                        newSpawn = GameObject.Instantiate(bonus);
                        newSpawn.transform.position = new Vector3(GenerateRandomStartPositionX(), spawnLocationY, 0f);
                    }
                    else
                    {
                        newSpawn = GameObject.Instantiate(life);
                        newSpawn.transform.position = new Vector3(GenerateRandomStartPositionX(), spawnLocationY, 0f);
                    }
                }
                else
                {
                    newSpawn = GameObject.Instantiate(enemy);
                    newSpawn.transform.position = new Vector3(GenerateRandomStartPositionX(), spawnLocationY, 0f);
                }
            }
           
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    /// <summary>
    /// Generate a random start position for Food
    /// </summary>
    /// <returns></returns>
    private float GenerateRandomStartPositionX() {
        float min = -8.5f;
        float max = 8.5f;
        return (Random.Range(min, max));
    }

    /// <summary>
    /// Destroy all spawned Food that are on the screen
    /// </summary>
    public void DestroyAll() {
        Destroy(newSpawn);
    }

    /// <summary>
    /// Sets the spawn interval
    /// </summary>
    /// <param name="newInterval">float</param>
    public void SetSpawnInterval(float newInterval) {
        spawnInterval = newInterval;
    }


}
