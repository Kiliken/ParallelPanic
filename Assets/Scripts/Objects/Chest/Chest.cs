using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public Mesh openMesh;
    // 0 = empty, 1 = key, 2 = trap
    public int chestType = 0;
    private bool opened = false;
    private bool collidingPlayer1 = false;
    private bool collidingPlayer2 = false;
    Player player;
    GameObject key;
    private float showObjTime = 3f;
    private float showObjTimer = 0f;
    private bool objShown = false;


    // Start is called before the first frame update
    void Start()
    {
        if(chestType == 1){
            key = gameObject.transform.GetChild(1).gameObject;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!opened){
            if((Input.GetButtonDown("Player1Inter") && collidingPlayer1) || (Input.GetButtonDown("Player2Inter") && collidingPlayer2)){
                gameObject.transform.GetChild(0).gameObject.GetComponent<MeshFilter>().mesh = openMesh;
                if(chestType == 1){
                    if(player.GetComponent<Player>().holdingKey == false){
                        Debug.Log("Collected Key");
                        player.GetComponent<Player>().holdingKey = true;
                        //Destroy(gameObject);
                        key.SetActive(true);
                    }
                }
                player.canInteract = false;
                opened = true;
            }
        }
        else{
            if (chestType == 1 && !objShown){
                if(showObjTimer < showObjTime){
                    showObjTimer += Time.deltaTime;
                    key.transform.Rotate(0f,0f, 120f * Time.deltaTime, Space.Self);
                }
                else{
                    key.SetActive(false);
                    objShown = true;
                }
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

        private void OnTriggerStay(Collider other){
        if(other.gameObject.CompareTag("Player")){
            if(!opened){
                player.canInteract = true;
            }
        }
    }

    private void OnTriggerExit(Collider other){
        if(other.gameObject.CompareTag("Player")){
            collidingPlayer1 = false;
            collidingPlayer2 = false;
            player.canInteract = false;
            player = null;
            //Debug.Log("Player exited");
        }
    }
}
