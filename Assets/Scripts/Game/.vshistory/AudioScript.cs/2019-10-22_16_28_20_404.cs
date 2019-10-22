﻿using System.Collections;
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
    private AudioClip[] BonusClips;
    /*********************** END OF VARIABLES ***********************/


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