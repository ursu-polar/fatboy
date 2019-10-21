using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// The Player class
/// </summary>
public class Player : MonoBehaviour
{
    /************************* VARIABLES ****************************/
    //PUBLIC
    public float scaleFactor; //The base scale factor for eating Food
                              //The other scales (Enemy, Life) (except Bonus) are based on this
    public float scaleSpeed; //How fast the player will scale
    //PRIVATE
    private GameManager GM;
    private float half_szX; //gets the half size of the player to calculate clamping in Controll
    private float half_szY; //gets the half size of the player to calculate clamping in Controll
    private Controll controll; //reference to Controll class
    private int enemyPoints; //noumber of points awarded when player eats an food Enemy
    private int lifePoints; //noumber of points awarded when player eats an food Life
    //Maybe change the names? They are Tags to, so do it sooner than later
    private float lastGravity;
    private string NORMAL = "normal";
    private string PAUSE = "pause";
    private string SLOW = "slow";
    /*********************** END OF VARIABLES ***********************/

    private void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();

        controll = gameObject.GetComponent<Controll>();

        
        scaleSpeed = 1f;

        enemyPoints = 1;
        lifePoints = 10;

        SetFace();
    }

    /// <summary>
    /// Choose the face from the 4 faces
    /// </summary>
    private void SetFace() {
        //hide all the faces
        int children = transform.childCount;
        int choice = Random.Range(1, 4);
        for (int i = 0; i < children; ++i) {
            if (i != choice)
            {
                if(transform.GetChild(i).gameObject.tag != "particles") transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
    /// <summary>
    /// Player eats food. What to do?
    /// Here is the GameOver detection, if Death gameObj is touched
    /// </summary>
    /// <param name="other">GameObject with tags (Death,Enemy,Life,Bonus)</param>
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Death") //touched the GameOver object, call StopGame and exit
        {
            StopGame();
            return;
        }

        //Other Object is Food so destroy it
        if(other.gameObject.tag != "Floor")  Destroy(other.gameObject);

        //Set a random scale factor
        scaleFactor = (float)Random.Range(1, 5) / 10;
      
        //Depending on what it hits
        switch (other.gameObject.tag)
        {
            case "Enemy":
                EnemyHit();
                GM.IncreaseScore(enemyPoints); 
                break;
            case "Life":
                LifeHit();
                GM.IncreaseScore(lifePoints);
                break;
            case "Bonus":
                BonusHit();
                GM.DoubleScore();
                break;
        }
    }

    /// <summary>
    /// Enemy Food Hit
    /// </summary>
    private void EnemyHit()
    {
        transform.DOScale(new Vector3(transform.localScale.x + scaleFactor, transform.localScale.y + scaleFactor), scaleSpeed)
            .OnUpdate(() =>
            {
                GetHalfSize();
                controll.Clamp();
            });
    }

    /// <summary>
    /// Life Food Hit
    /// </summary>
    private void LifeHit()
    {
        SlowGravit();
        float scaleBonus = scaleFactor * Random.Range(4, 10) /10;
        float scaleX;
        float scaleY;
        if (transform.localScale.x - scaleFactor * scaleBonus < 1)
        {
            //The scale will be smaller than the minimum and initial 1 so set it to 1
            scaleX = scaleY = 1f;
        } else
        {
            scaleX = transform.localScale.x - scaleBonus;
            scaleY = transform.localScale.y - scaleBonus;
        }
        transform.DOScale(new Vector3(scaleX, scaleY), scaleSpeed)
            .OnUpdate(() =>
            {
                GetHalfSize();
                controll.Clamp();
            })
            .OnComplete(()=> {
              ResumeGame();
            });
    }

    /// <summary>
    /// Bonus Food hit
    /// </summary>
    private void BonusHit()
    {
        PauseGame();
        float scaleBonus = scaleFactor;
        float scaleX;
        float scaleY;
        if (transform.localScale.x / 2 < 1)
        {
            //The scale will be smaller than the minimum and initial 1 so set it to 1
            scaleX = scaleY = 1f;
        }
        else
        {
            scaleX = transform.localScale.x / 2;
            scaleY = transform.localScale.y / 2;
        }
        transform.DOScale(new Vector3(scaleX, scaleY), scaleSpeed)
            .OnUpdate(() =>
            {
                GetHalfSize();
                controll.Clamp();
            })
            .OnComplete(() => {
                ResumeGame();
            });
    }

    /// <summary>
    /// Get the halfSize of player, needed in Controll to clamp
    /// </summary>
    public void GetHalfSize()
    {
        half_szX = transform.GetChild(0).GetComponent<Renderer>().bounds.size.x / 2;
        half_szY = transform.GetChild(0).GetComponent<Renderer>().bounds.size.y / 2;
    }

    //why are public?
    public float GetHalf_szX() { return half_szX; }
    public float GetHalf_szY() { return half_szY; }

    /// <summary>
    /// Stop the game.
    /// </summary>
    private void StopGame() {
        GM.Gravity = 0;
        GM.GameOver();
    }


    private void SlowGravit() {
        GM.SetGravityState(SLOW);
        lastGravity = GM.Gravity;
        GM.Gravity = lastGravity / 2;
    }
    
    private void PauseGame()
    {
        GM.SetGravityState(PAUSE);
        lastGravity = GM.Gravity;
        GM.Gravity = 0;
    }

    private void ResumeGame()
    {
        GM.SetGravityState(NORMAL);
        GM.Gravity = lastGravity;
    }

}
