using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicDoor : MonoBehaviour
{
    public Animator doorAnim;
    public Collider doorColl;
    bool open = false;
    bool collidingPlayer1 = false;
    bool collidingPlayer2 = false;

    void Start()
    {
        
    }



    void Update()
    {
        if (((Input.GetButtonDown("Player1Inter") && collidingPlayer1) || (Input.GetButtonDown("Player2Inter") && collidingPlayer2)) && open == true)
        {
            //Close Door
            doorAnim.SetBool("open", false);
            doorColl.enabled = true;
            open = false;
        }
        else if (((Input.GetButtonDown("Player1Inter") && collidingPlayer1) || (Input.GetButtonDown("Player2Inter") && collidingPlayer2)) && open == false)
        {
            //Open Door
            doorAnim.SetBool("open", true);
            doorColl.enabled = false;
            Debug.Log("Open");
            open = true;
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
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            collidingPlayer1 = false;
            collidingPlayer2 = false;
        }
    }


}
