using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Audio Script for sounds (should be improved - Audio Manager?)
/// </summary>
public class AudioScript : MonoBehaviour
{
    /************************* VARIABLES ****************************/
    //PUBLIC
    public AudioClip[] MusicClip;
    public AudioSource MusicSource;

    //PRIVATE
    /*********************** END OF VARIABLES ***********************/


    private void Start()
    {
        MusicSource.clip = MusicClip[0];
    }

    
}
