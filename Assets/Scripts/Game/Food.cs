using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{

    private GameObject gameManager;
    private GameManager GM;

    private float rotationsPerMinute = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0, 0, Random.Range(0f, 360f));

        //Ignore Game Over Bar
        GameObject death = GameObject.Find("Death");
        Collider2D foodColider = GetComponent<Collider2D>();
        Collider2D deathColider = death.GetComponent<Collider2D>();

        Physics2D.IgnoreCollision(foodColider, deathColider);
        gameManager = GameObject.Find("GameManager");
        GM = gameManager.GetComponent<GameManager>();
    }

   

    // Update is called once per frame
    void FixedUpdate()
    {
       GetComponent<Rigidbody2D>().gravityScale = GM.Gravity;
       transform.Rotate(0, 0, Random.Range(10f, 30f) * rotationsPerMinute * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag != "Player" && 
            other.gameObject.tag != "Enemy" && 
            other.gameObject.tag != "Life" &&
            other.gameObject.tag != "Bonus" &&
            other.gameObject.tag != "Death" ) {
            Destroy(gameObject);
        }        
    }
}
