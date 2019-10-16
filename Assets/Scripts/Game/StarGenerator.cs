using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Generate the stars
/// </summary>
public class StarGenerator : MonoBehaviour
{
    /************************* VARIABLES ****************************/
    //PUBLIC
    public GameObject star;
    public int maxNumberOfConcomitantSpawns;
    //PRIVATE
    private GameManager GM;
    private float spawnStarInterval = 0.5f;
    private IEnumerator spawnCorotine;
    /*********************** END OF VARIABLES ***********************/

    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();

        maxNumberOfConcomitantSpawns = 3;
        spawnCorotine = SpawnStar();
        StartCoroutine(spawnCorotine);
    }

    private IEnumerator SpawnStar()
    {
        while (GM.canSpawn)
        {
            int numberOfConcomitantSpawns = Random.Range(1, maxNumberOfConcomitantSpawns);
            for (int i = 0; i < numberOfConcomitantSpawns; i++)
            {
                GameObject newStar = GameObject.Instantiate(star);
                newStar.transform.parent = transform;
            }
            yield return new WaitForSeconds(spawnStarInterval);
        }
    }
}
