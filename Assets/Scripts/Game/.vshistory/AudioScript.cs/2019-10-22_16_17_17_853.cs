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


    public void AudioEat()
    {
        MusicSource.clip = MusicClip[0];
        Player();
    }

    private void Play()
    {

    }

    
}
