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
    private GameManager GM;
    const string NORMAL = "normal";
    const string PAUSE = "pause";
    const string SLOW = "slow";
    const string RESUME = "resume";
    private Vector2 lastVelocity;
    /*********************** END OF VARIABLES ***********************/

    void Start()
    {
        //GameManager reference
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();

        //Ignore Game Over Bar
        GameObject death = GameObject.Find("Death");
        Collider2D foodColider = GetComponent<Collider2D>();
        Collider2D deathColider = death.GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(foodColider, deathColider);

        transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        SetRandomFace();
    }

    void FixedUpdate()
    {
        //GetComponent<Rigidbody2D>().gravityScale = GM.Gravity; 
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, -GM.Gravity));

        switch (GM.GravityState) {
            case NORMAL:
                GetComponent<Rigidbody2D>().velocity = lastVelocity;
                break;

            case RESUME:
                GetComponent<Rigidbody2D>().velocity = lastVelocity;
                lastVelocity = Vector2.zero;
                GM.SetGravityState(NORMAL);
                break;

            case PAUSE:
                
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                GetComponent<Rigidbody2D>().angularVelocity = 0f;
                break;

            case SLOW:
                if(lastVelocity == Vector2.zero) lastVelocity = GetComponent<Rigidbody2D>().velocity;
                GetComponent<Rigidbody2D>().velocity = new Vector2(0f,-0.5f);
                GetComponent<Rigidbody2D>().angularVelocity = 0.5f;
                break;
        }
    }

    /// <summary>
    /// Destroy food if not eaten when hits the Bottom GameObj
    /// </summary>
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "bottom") {
            Destroy(gameObject);
        }        
    }

    /// <summary>
    /// Sets a random face for each food
    /// </summary>
    private void SetRandomFace() {
        //hide all the faces
        GameObject body = this.transform.Find("body").gameObject;
        GameObject mouth = this.transform.Find("mouth").gameObject;
        GameObject eyes = this.transform.Find("eyes").gameObject;

        List<GameObject> bodyParts = new List<GameObject>();
        bodyParts.Add(body);
        bodyParts.Add(mouth);
        bodyParts.Add(eyes);

        foreach (GameObject part in bodyParts)
        {
            int childrenLength = part.transform.childCount;
            int choice = Random.Range(1, childrenLength);
            for (int i = 0; i < childrenLength; ++i)
            {
                if (i != choice) part.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
