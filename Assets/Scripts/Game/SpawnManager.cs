using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject enemy;
    public GameObject life;
    public GameObject bonus;

    public float spawnInterval;
    public float spawnLocationY;

    public GameObject gameManager;
    private GameManager GM;

    private GameObject newSpawn;

    private IEnumerator coroutine;

    private void Awake()
    {
        
        GM = gameManager.GetComponent<GameManager>();
    }

    public void StartSpawning()
    {
        coroutine = SpawnEnemy();
        StartCoroutine(coroutine);
    }

    private IEnumerator SpawnEnemy()
    {
        while (GM.canSpawn)
        {
            //%30 percent chance (1 - 0.7 is 0.3)
            if (Random.value > 0.7) {
                if (Random.value > 0.85) {
                    newSpawn = GameObject.Instantiate(bonus);
                    newSpawn.transform.position = new Vector3(GenerateRandomStartPositionX(), spawnLocationY, 0f);
                }
                else
                {
                    newSpawn = GameObject.Instantiate(life);
                    newSpawn.transform.position = new Vector3(GenerateRandomStartPositionX(), spawnLocationY, 0f);
                }
            } else
            {
                newSpawn = GameObject.Instantiate(enemy);
                newSpawn.transform.position = new Vector3(GenerateRandomStartPositionX(), spawnLocationY, 0f);
            }
         
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private float GenerateRandomStartPositionX() {
        float min = -8.5f;
        float max = 8.5f;
        return (Random.Range(min, max));
    }

    public void DestroyAll() {
        Destroy(newSpawn);
    }


}
