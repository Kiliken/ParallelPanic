using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainDoor : MonoBehaviour
{
    public Animator doorAnim;
    public Collider doorColl;
    bool open = false;
    bool unlocked;
    bool collidingPlayer1 = false;
    bool collidingPlayer2 = false;
    Player player;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }



    void Update()
    {
        if(!GameManager.gamePaused){
            if (((Input.GetButtonDown("Player1Inter") && collidingPlayer1) || (Input.GetButtonDown("Player2Inter") && collidingPlayer2)) && open == false)
            {
                if (player.holdingKey && !unlocked)
                {
                    doorAnim.SetBool("open", true);
                    doorColl.enabled = false;
                    open = true;
                    unlocked = true;
                    player.holdingKey = false;
                    if (SettingsMenu.sfx_on)
                        audioSource.Play();
                }
                
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.gameObject.name == "Player1")
            {
                collidingPlayer1 = true;

            }
            else
            {
                collidingPlayer2 = true;
            }
            player = other.gameObject.GetComponent<Player>();
            player.canInteract = true;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            collidingPlayer1 = false;
            collidingPlayer2 = false;
            player.canInteract = false;
        }
    }


}
