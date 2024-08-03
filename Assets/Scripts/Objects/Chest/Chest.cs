using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public Mesh openMesh;
    public Transform playerSpawnPos;
    // 0 = empty, 1 = key, 2 = trap
    [SerializeField] private int chestType = 0;
    public int ChestType {get{
        return chestType;
    } set{
        switch(value){
            case 1:
                key = gameObject.transform.GetChild(1).gameObject;
                break;
            case 2:
                activeTime = 0.5f;
                if(gameObject.name == "ChestA"){
                    playerSpawnPos = GameObject.Find("PlayerSpawn1").transform;
                }
                else if(gameObject.name == "ChestB"){
                    playerSpawnPos = GameObject.Find("PlayerSpawn2").transform;
                }
                break;
        }
        chestType = value;
    }}
    private bool opened = false;
    private bool collidingPlayer1 = false;
    private bool collidingPlayer2 = false;
    Player player;
    [SerializeField] GameObject key;
    private float activeTime = 3f;
    private float activeTimer = 0f;
    private bool activated = false;


    // Start is called before the first frame update
    void Start()
    {
        // if(chestType == 1){
        //     key = gameObject.transform.GetChild(1).gameObject;
        // }
        // else if(chestType == 2){
        //     activeTime = 0.5f;
        // }
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
            if(!activated){
                if(activeTimer < activeTime){
                    activeTimer += Time.deltaTime;
                    if(chestType == 1){
                        key.transform.Rotate(0f,0f, 120f * Time.deltaTime, Space.Self);
                    }
                }
                else{
                    if(chestType == 1){
                        key.SetActive(false);
                    }
                    else if(chestType == 2){
                        player.gameObject.transform.position = playerSpawnPos.transform.position;
                    }
                    activated = true;
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
