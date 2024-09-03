using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour, ISelectHandler
{
    public AudioClip tickSFX;
    public AudioClip selectSFX;
    public AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSelect(BaseEventData eventData){
        audioSource.clip = tickSFX;
        if(SettingsMenu.sfx_on)
            audioSource.Play();
        //Debug.Log("pointer entered");
    }

    public void OnClick(){
        audioSource.clip = selectSFX;
        if(SettingsMenu.sfx_on)
            audioSource.Play();
        //Debug.Log("clicked");

    }
}
