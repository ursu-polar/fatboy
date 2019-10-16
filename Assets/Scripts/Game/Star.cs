using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Star creator class. Set position, scale, lifespawn
/// </summary>
public class Star : MonoBehaviour
{
    /************************* VARIABLES ****************************/
    //PUBLIC

    //PRIVATE
    private float minX = -8.8f;
    private float maxX = 8.8f;
    private float _x;

    private float minY = 0f;
    private float maxY = 8.5f;
    private float _y;

    private float minScale = 1f;
    private float maxScale = 4f;
    private float scale;

    private float minLife = 0.3f;
    private float maxLife = 4f;
    private float life;

    private float bornTime;
    private bool growing;

    /*********************** END OF VARIABLES ***********************/

    void Start()
    {
        _x = Random.Range(minX, maxX);
        _y = Random.Range(minY, maxY);

        scale = Random.Range(minScale, maxScale);

        life = Random.Range(minLife, maxLife);

        bornTime = Time.time;
        growing = true;

        transform.position = new Vector3(_x, _y, 0f);
        transform.localScale = new Vector3(0f, 0f, 1f);
    }

    void Update()
    {
        float scaleSize = transform.localScale.y;

        if (scaleSize >= scale)
        {
            growing = false;
            bornTime = Time.time - 0.01f;
        }

        if (scaleSize <= 1f)
        {
            if(growing == false)
            {
                Destroy(gameObject);
                return;
            }
            growing = true;
            bornTime = Time.time - 0.01f;
        }

        if (growing)
            Grow();
        else
            Shrink();
    }

    /// <summary>
    /// Grown the star
    /// </summary>
    private void Grow()
    {
        float tranSition = (Time.time - bornTime) / life;
        transform.localScale = Vector3.Lerp(new Vector3(1f,1f,1f), new Vector3(scale, scale, scale), tranSition);
    }

    /// <summary>
    /// Shrink the star
    /// </summary>
    private void Shrink()
    {
        float tranSition = (Time.time - bornTime) / life;
        transform.localScale = Vector3.Lerp(new Vector3(scale, scale, scale), new Vector3(0f, 0f, 1f), tranSition);
    }
}
