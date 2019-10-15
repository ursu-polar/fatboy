using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Controll : MonoBehaviour
{
    public float smoothTime = 0.3F;
    

    private float ScreenWidth;   
    private Vector3 velocity = Vector3.zero;
    private Vector3 playerPosScreen;
    private Vector3 wrld;

    public Player player;

 

    // Start is called before the first frame update
    void Start()
    {
        ScreenWidth = Screen.width;
        //playerBody = player.GetComponent<Rigidbody2D>();

        wrld = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, 0.0f));

        player.GetHalfSize();
    }

   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) || Input.touchCount > 0)
        {
            Follow();
            Clamp();


        }
    }

    private void Follow() {
        Vector3 screenPos = Input.mousePosition;
        screenPos.z = 10.0f;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        Vector3 newPos = transform.position;
        newPos.x = worldPos.x;
        // Smoothly move the camera towards that target position
        transform.position = Vector3.SmoothDamp(transform.position, newPos, ref velocity, smoothTime);
    }

    public void Clamp() {
        //Bound

        //Horizontal
        playerPosScreen = transform.position;
        if (playerPosScreen.x >= (wrld.x - player.GetHalf_szX()))
        {
            playerPosScreen.x = wrld.x - player.GetHalf_szX();
            transform.position = playerPosScreen;
        }
        if (playerPosScreen.x <= -(wrld.x - player.GetHalf_szX()))
        {
            playerPosScreen.x = -(wrld.x - player.GetHalf_szX());
            transform.position = playerPosScreen;
        }

        //Vertical
        //print(playerPosScreen.y + " | " + (wrld.y - half_szY));
        //if (playerPosScreen.y >= (wrld.y - half_szY))
        //{
        //    playerPosScreen.y = wrld.y;
        //    transform.position = playerPosScreen;
        //}
        //if (playerPosScreen.y <= -(wrld.y + half_szY))
        //{
        //    playerPosScreen.y = -wrld.y;
        //    transform.position = playerPosScreen;
        //}
    }
}
