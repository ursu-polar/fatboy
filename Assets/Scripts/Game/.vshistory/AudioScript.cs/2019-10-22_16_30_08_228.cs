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

    private void Play()
    {
        MusicSource.Play();
    }

    IEnumerator AudioBonus()
    {
        yield return null;

        //1.Loop through each AudioClip
        for (int i = 0; i < adClips.Length; i++)
        {
            //2.Assign current AudioClip to audiosource
            adSource.clip = adClips[i];

            //3.Play Audio
            adSource.Play();

            //4.Wait for it to finish playing
            while (adSource.isPlaying)
            {
                yield return null;
            }

            //5. Go back to #2 and play the next audio in the adClips array
        }
    }


}
