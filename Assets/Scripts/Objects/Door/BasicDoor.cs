using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicDoor : MonoBehaviour
{
    public Animator doorAnim;
    public Collider doorColl;
    bool open = false;
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
        if (((Input.GetButtonDown("Player1Inter") && collidingPlayer1) || (Input.GetButtonDown("Player2Inter") && collidingPlayer2)) && open == true)
        {
            //Close Door
            doorAnim.SetBool("open", false);
            //doorColl.enabled = true;
            open = false;
            // door sfx
            audioSource.Play();
        }
        else if (((Input.GetButtonDown("Player1Inter") && collidingPlayer1) || (Input.GetButtonDown("Player2Inter") && collidingPlayer2)) && open == false)
        {
            //Open Door
            doorAnim.SetBool("open", true);
            //doorColl.enabled = false;
            open = true;
            // door sfx
            audioSource.Play();
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
            other.gameObject.GetComponent<Player>().canInteract = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            collidingPlayer1 = false;
            collidingPlayer2 = false;
            other.gameObject.GetComponent<Player>().canInteract = false;
        }
    }

}
