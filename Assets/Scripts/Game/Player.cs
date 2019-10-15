using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Player : MonoBehaviour
{
    public GameObject gameManager;
    private GameManager GM;

    public float scaleFactor;
    public float scaleSpeed = 1f;

    private float half_szX;
    private float half_szY;

    private Controll controll;

    

    private void Start()
    {
        controll = gameObject.GetComponent<Controll>();
        GM = gameManager.GetComponent<GameManager>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if(other.gameObject.tag == "Death")
        {
            print("game over");
            StopGame();
            return;
        }

        Destroy(other.gameObject);

        switch (other.gameObject.tag)
        {
            case "Enemy":
                EnemyHit();
                GM.IncreaseScore(1);
                break;
            case "Life":
                LifeHit();
                GM.IncreaseScore(5);
                break;
            case "Bonus":
                BonusHit();
                GM.DoubleScore();
                break;

        }

 
        //Scor.text = scor.ToString();

    }

    private void EnemyHit()
    {
        transform.DOScale(new Vector3(transform.localScale.x + scaleFactor, transform.localScale.y + scaleFactor), scaleSpeed)
            .OnUpdate(() =>
            {
                GetHalfSize();
                controll.Clamp();
            });
    }

    private void LifeHit()
    {
        float scaleBonus = scaleFactor * Random.Range(4, 10) /10;
        float scaleX;
        float scaleY;
        if (transform.localScale.x - scaleFactor * scaleBonus < 1)
        {
            scaleX = scaleY = 1f;
        } else
        {
            scaleX = transform.localScale.x - scaleBonus;
            scaleY = transform.localScale.y - scaleBonus;
        }
        transform.DOScale(new Vector3(scaleX, scaleY), scaleSpeed)
            .OnUpdate(() => {
                GetHalfSize();
                controll.Clamp();
            });
    }

    private void BonusHit()
    {
        transform.DOScale(new Vector3(1f, 1f), scaleSpeed)
            .OnUpdate(() => {
                GetHalfSize();
                controll.Clamp();
            });
    }


    public void GetHalfSize()
    {
        half_szX = transform.GetChild(0).GetComponent<Renderer>().bounds.size.x / 2;
        half_szY = transform.GetChild(0).GetComponent<Renderer>().bounds.size.y / 2;
    }

    public float GetHalf_szX() { return half_szX; }
    public float GetHalf_szY() { return half_szY; }

    private void StopGame() {
        GM.Gravity = 0;
        GM.canSpawn = false;
        GM.GameOver();
    }


}
