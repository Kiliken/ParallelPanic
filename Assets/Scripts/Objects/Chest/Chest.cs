using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private bool collidingPlayer1 = false;
    private bool collidingPlayer2 = false;
    Player player;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetButtonDown("Player1Inter") && collidingPlayer1) || (Input.GetButtonDown("Player2Inter") && collidingPlayer2)){
            if(player.GetComponent<Player>().holdingKey == false){
                Debug.Log("Collected Key");
                player.GetComponent<Player>().holdingKey = true;
                Destroy(gameObject);
            }
        }
        
    }

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Player")){
            if(other.gameObject.name == "Player1"){
                collidingPlayer1 = true;
            }
            else{
                collidingPlayer2 = true;
            }
            player = other.gameObject.GetComponent<Player>();
            //Debug.Log("Player colliding");
        }
    }

    private void OnTriggerExit(Collider other){
        if(other.gameObject.CompareTag("Player")){
            collidingPlayer1 = false;
            collidingPlayer2 = false;
            player = null;
            //Debug.Log("Player exited");
        }
    }
}
