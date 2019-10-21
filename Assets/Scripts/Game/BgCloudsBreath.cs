using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// make the background clouds breath
/// </summary>
public class BgCloudsBreath : MonoBehaviour
{
    /************************* VARIABLES ****************************/
    //PUBLIC

    //PRIVATE

    private float scale = 1.2f;

    private float bornTime;
    private bool growing;

    private float life  = 20f;

    /*********************** END OF VARIABLES ***********************/

    void Start()
    {
        bornTime = Time.time;
        growing = true;
     
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
            growing = true;
            bornTime = Time.time - 0.01f;
        }

        if (growing)
            Grow();
        else
            Shrink();
    }

    /// <summary>
    /// Grown the Clouds
    /// </summary>
    private void Grow()
    {
        float tranSition = (Time.time - bornTime) / life;
        transform.localScale = Vector3.Lerp(new Vector3(1f, 1f, 1f), new Vector3(scale, scale, scale), tranSition);
    }

    /// <summary>
    /// Shrink the Clouds
    /// </summary>
    private void Shrink()
    {
        float tranSition = (Time.time - bornTime) / life;
        transform.localScale = Vector3.Lerp(new Vector3(scale, scale, scale), new Vector3(1f, 1f, 1f), tranSition);
    }
}
