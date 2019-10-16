using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public GameObject planet;

    public float radius; //Radius of the planets circle collider
    public float radius2;
    public float angle = 90f; // The Initial starting angle
    public float speed = 11f; // Number Of Pixels moved Per second

    private float radians;

    private float orbiterX; // X-Position of the orbiting player
    private float orbiterY; // Y-Position of the orbiting player

    public float rotationSpeed = 11f; // Speed of the players rotation
    private float orbitAngle; // Target angle of the orbiting object
    private Vector3 direction;

    private float planetRotationOld; //Rotation of the planet in the last frame
    private float planetRotationNew;
    private float planetRotationDiff;

    private Vector3 playerPosScreen;
    private Vector3 velocity = Vector3.zero;
    public float smoothTime = 0.3F;

    private float half_szX; //gets the half size of the player to calculate clamping in Controll
    private float half_szY; //gets the half size of the player to calculate clamping in Controll
    private Vector3 WORLD; //reference to Camera Screen To World Position
    void Start()
    {
    
        WORLD = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, 0.0f));
    }

    void Update()
    {
      
        if (Input.GetMouseButton(0) || Input.touchCount > 0)
        {
            Follow();
            Clamp();
        }
    }

    void Movement(Vector3 newpos)
    {
        float move = -newpos.x;
        angle += 1 * speed * Time.deltaTime;

        radians = angle * Mathf.Deg2Rad;
        orbiterX = planet.transform.position.x + radius * Mathf.Cos(radians); // Position The Player Along x-axis
        orbiterY = planet.transform.position.y + radius2 * Mathf.Sin(radians); // Position The Player Along y-axis
        this.transform.position = new Vector2(orbiterX, orbiterY); // Makes the player orbit
        newpos.y = orbiterY;
        transform.position = Vector3.SmoothDamp(transform.position, newpos, ref velocity, smoothTime);
        // ROTATION STUFF
        direction = (this.transform.position - planet.transform.position);
        //direction = planet.transform.InverseTransformDirection(direction);
        orbitAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;

        Quaternion q = Quaternion.AngleAxis(orbitAngle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotationSpeed);
        Clamp();
    }

    private void Follow()
    {
        Vector3 screenPos = Input.mousePosition;
        screenPos.z = 10.0f;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        Vector3 newPos = transform.position;
        newPos.x = worldPos.x;
        // Smoothly move the camera towards that target position
       
        Quaternion q = Quaternion.AngleAxis(0, Vector3.forward);
        if (transform.position.x > -6 && transform.position.x <6)
        {
           // newPos.y = 0;
        } else
        {
            q = Quaternion.AngleAxis(-newPos.x * 4, Vector3.forward);
            
        }
        angle += 1 * speed * Time.deltaTime;
        print(angle);
        radians = angle * Mathf.Deg2Rad;

       /// newPos.y = planet.transform.position.y + radius * Mathf.Sin(radians);
       //transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 1);
        //transform.position = new Vector3(newPos, ref velocity, smoothTime);
        //print(newPos.x);
    }

    public void Clamp()
    {
        //Horizontal
        playerPosScreen = transform.position;
        if (playerPosScreen.x >= (WORLD.x - half_szX))
        {
            playerPosScreen.x = WORLD.x - half_szX;
            transform.position = playerPosScreen;
        }
        if (playerPosScreen.x <= -(WORLD.x - half_szX))
        {
            playerPosScreen.x = -(WORLD.x - half_szX);
            transform.position = playerPosScreen;
        }


        
        
    }

    public void GetHalfSize()
    {
        half_szX = transform.GetComponent<Renderer>().bounds.size.x / 2;
        half_szY = transform.GetComponent<Renderer>().bounds.size.y / 2;
    }
}
