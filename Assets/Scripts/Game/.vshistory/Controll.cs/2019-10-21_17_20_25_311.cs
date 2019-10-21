using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

    /// <summary>
    /// Move player to touch position
    /// </summary>
public class Controll : MonoBehaviour
{
   
    /************************* VARIABLES ****************************/
    //PUBLIC
    public float smoothTime = 0.3F; //smooth the movin of the player on screen -> the smaller, the faster
                                    //could be use for a damageEnemy that makes you move slower?
    public GameObject _player; //well, player
    
    
    //PRIVATE
    private float ScreenWidth; //selfexplained
    private Vector3 velocity = Vector3.zero; //selfexplained
    private Vector3 playerPosScreen; //position of the player on the screen
    private Vector3 WORLD; //reference to Camera Screen To World Position
    private Player player;
    private ParticleSystem trail;
    Vector3 prevPos;

    /*********************** END OF VARIABLES ***********************/

    private void Awake()
    {
        trail = GameObject.Find("particleSystem").GetComponentInChildren<ParticleSystem>();

    }
    void Start()
    {
        ScreenWidth = Screen.width;

        WORLD = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, 0.0f));

        player = _player.GetComponent<Player>();
        player.GetHalfSize();

       
 
    }

   
    void Update()
    {
        
        if (Input.GetMouseButton(0) || Input.touchCount > 0)
        {

            Vector3 dir = (transform.position - prevPos);
            prevPos = transform.position;
            
            if (dir.x > 0) {
                trail.transform.localPosition = new Vector3(-0.3f, 0.02f, 1f);
                trail.transform.rotation = Quaternion.Euler(1f, -90f, 1f );
                
            }
            else if (dir.x < 0)
            {
                trail.transform.localPosition = new Vector3(0.3f, 0.02f, 1f);
                trail.transform.rotation = Quaternion.Euler(1f,90f, 1f);
                
            }
        
            if(dir.x != 0) trail.enableEmission = true;
            else trail.enableEmission = false;
            Follow();
            Clamp();
        }
        else
        {
            trail.enableEmission = false;
        }
    }

    /// <summary>
    /// Move player to touch position
   /// </summary>
    private void Follow() {
        Vector3 screenPos = Input.mousePosition;
        screenPos.z = 10.0f;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        Vector3 newPos = transform.position;
        newPos.x = worldPos.x;
        // Smoothly move the camera towards that target position
        transform.position = Vector3.SmoothDamp(transform.position, newPos, ref velocity, smoothTime);


    }

    /// <summary>
    /// Clamp the player in the ScreenWidth
    /// </summary>
    public void Clamp() {
        //Horizontal
        playerPosScreen = transform.position;
        if (playerPosScreen.x >= (WORLD.x - player.GetHalf_szX()))
        {
            playerPosScreen.x = WORLD.x - player.GetHalf_szX();
            transform.position = playerPosScreen;
        }
        if (playerPosScreen.x <= -(WORLD.x - player.GetHalf_szX()))
        {
            playerPosScreen.x = -(WORLD.x - player.GetHalf_szX());
            transform.position = playerPosScreen;
        }

      
        //Commented because it can not go down, and at the top will trigger the end game

        //Vertical
        /*
        print(playerPosScreen.y + " | " + (wrld.y - half_szY));
        if (playerPosScreen.y >= (wrld.y - half_szY))
        {
            playerPosScreen.y = wrld.y;
            transform.position = playerPosScreen;
        }
        if (playerPosScreen.y <= -(wrld.y + half_szY))
        {
            playerPosScreen.y = -wrld.y;
            transform.position = playerPosScreen;
        }*/
    }
}
