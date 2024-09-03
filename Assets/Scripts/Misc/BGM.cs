using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    public void PlayMusic(){
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void PauseMusic(){
        if (!audioSource.isPlaying)
        {
            audioSource.Pause();
        }
    }

    public void UnpauseMusic(){
        if (!audioSource.isPlaying)
        {
            audioSource.UnPause();
        }
    }


    public void StopMusic(){
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

}
