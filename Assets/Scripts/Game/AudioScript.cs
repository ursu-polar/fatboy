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
        BonusClips.Add(MusicClip[2]); //Bonus sound
        BonusClips.Add(MusicClip[1]); //Shrink sound
    }

    public void AudioEat()
    {
        MusicSource.clip = MusicClip[0];
        Play();
    }

    private void Play()
    {
        MusicSource.Play();
    }

    public void AudioBonus()
    {
        StartCoroutine(AudioBonusStack());
    }

    IEnumerator AudioBonusStack()
    {
        yield return null;
        for (int i = 0; i < BonusClips.Count; i++)
        {
            MusicSource.clip = BonusClips[i];
            MusicSource.Play();
            while (MusicSource.isPlaying)
            {
                yield return null;
            }
        }
    }


}
