using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WallTrap : MonoBehaviour
{
    public GameObject wall;
    public GameObject playerPos1;
    public GameObject playerPos2;
    public WallTrap otherTrap;
    public Material activeMat;
    public Material inactiveMat;
    GameObject player;
    private bool collidingPlayer1 = false;
    private bool collidingPlayer2 = false;
    public bool mainTrap = true; // set false for P2 room
    private bool wallRaised = true;
    private bool wallRising = false;
    private bool wallLowering = false;
    private float wallMoveSpeed = 5f;
    private float wallRaisedHeight = 0.5f;
    private float wallLoweredHeight = -0.6f;
    private bool canLowerWall = false;
    private float lowerTime = 5f;
    private float lowerTimer = 0f;


    // Start is called before the first frame update
    void Start()
    {
        if(mainTrap){
            setRandom();
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(wallRaised && !canLowerWall){
            if(lowerTimer < lowerTime){
                lowerTimer += Time.deltaTime;
            }
            else{
                wall.GetComponent<MeshRenderer>().material = activeMat;
                canLowerWall = true;
                lowerTimer = 0;
            }
        }
        if((Input.GetButtonDown("Player1Inter") && collidingPlayer1) || (Input.GetButtonDown("Player2Inter") && collidingPlayer2)){
            if(wallRaised && canLowerWall){
                LowerWall();
                otherTrap.RaiseWall();
            }
        }
    }


    private void FixedUpdate(){
        if(wallRising){
            if(wall.transform.localPosition.y < wallRaisedHeight){
                wall.transform.localPosition += new Vector3(0, wallMoveSpeed * Time.deltaTime, 0);
            }
            else{
                wall.GetComponent<MeshRenderer>().material = inactiveMat;
                wallRaised = true;
                wallRising = false;
            }
        }
        else if(wallLowering){
            if(wall.transform.localPosition.y > wallLoweredHeight){
                wall.transform.localPosition -= new Vector3(0, wallMoveSpeed * Time.deltaTime, 0);
            }
            else{
                wallLowering = false;
            }
        }
    }


    public void RaiseWall(){
        wallRising = true;
        if(player != null){
            if(Vector3.Distance(player.transform.position, playerPos1.transform.position) < Vector3.Distance(player.transform.position, playerPos2.transform.position)){
                player.transform.position = playerPos1.transform.position;
            }
            else{
                player.transform.position = playerPos2.transform.position;
            }
        }
    }

    public void LowerWall(){
        wallLowering = true;
        wallRaised = false;
        canLowerWall = false;
    }


    private void setRandom(){
        if(Random.Range(0, 2) == 0){
            LowerWall();
            otherTrap.RaiseWall();
        }
        else{
            RaiseWall();
            otherTrap.LowerWall();
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
            player = other.gameObject;
            other.gameObject.GetComponent<Player>().canInteract = true;
        }
    }

    private void OnTriggerExit(Collider other){
        if(other.gameObject.CompareTag("Player")){
            collidingPlayer1 = false;
            collidingPlayer2 = false;
            player = null;
            other.gameObject.GetComponent<Player>().canInteract = false;
        }
    }
}
