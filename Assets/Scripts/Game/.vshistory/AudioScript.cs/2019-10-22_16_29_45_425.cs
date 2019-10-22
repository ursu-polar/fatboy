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
    List<AudioClip> BonusClips = new List<AudioClip>();
    /*********************** END OF VARIABLES ***********************/

    private void Start()
    {
        BonusClips.Add(MusicClip[2]);
        BonusClips.Add(MusicClip[1]);
    }

    public void AudioEat()
    {
        MusicSource.clip = MusicClip[0];
        Play();
    }

    public void AudioShrink()
    {
        MusicSource.clip = MusicClip[1];
        Play();
    }

    public void AudioBonus()
    {
        MusicSource.clip = MusicClip[2];
        Play();
    }

    private void Play()
    {
        MusicSource.Play();
    }

    
}
