using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Food are the spawned items
/// </summary>
public class Food : MonoBehaviour
{
    /************************* VARIABLES ****************************/
    //PUBLIC


    //PRIVATE
    private GameObject gameManager; 
    private GameManager GM; 
    private float rotationsPerMinute = 10.0f; //speed of Food rotation
    /*********************** END OF VARIABLES ***********************/
    
    void Start()
    {
        //GameManager reference
        gameManager = GameObject.Find("GameManager");
        GM = gameManager.GetComponent<GameManager>();

        //Ignore Game Over Bar
        GameObject death = GameObject.Find("Death");
        Collider2D foodColider = GetComponent<Collider2D>();
        Collider2D deathColider = death.GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(foodColider, deathColider);
    }

    void FixedUpdate()
    {
        //Rotate the food
       GetComponent<Rigidbody2D>().gravityScale = GM.Gravity;
       transform.Rotate(0, 0, Random.Range(10f, 30f) * rotationsPerMinute * Time.deltaTime);
    }

    /// <summary>
    /// Destroy food if not eaten when hits the Bottom GameObj
    /// </summary>
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Bottom") {
            Destroy(gameObject);
        }        
    }
}
