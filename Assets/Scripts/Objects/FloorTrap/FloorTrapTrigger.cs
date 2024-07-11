using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTrapTrigger : MonoBehaviour
{
    public GameObject floorTrap;
    public FloorTrapTrigger otherTrap;
    public Mesh activeMesh;
    public Mesh inactiveMesh;
    GameObject player;
    private bool collidingPlayer1 = false;
    private bool collidingPlayer2 = false;
    public bool mainTrap = true;
    private bool trapRaised = true;
    private bool trapRising = false;
    private bool trapLowering = false;
    private float trapMoveSpeed = 5f;
    private float trapRaisedHeight = 0f;
    private float trapLoweredHeight = -0.03f;
    private bool canLowerTrap = false;
    private float lowerTime = 5f;
    private float lowerTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(trapRaised && !canLowerTrap){
            if(lowerTimer < lowerTime){
                lowerTimer += Time.deltaTime;
            }
            else{
                floorTrap.GetComponent<MeshFilter>().mesh = activeMesh;
                canLowerTrap = true;
                lowerTimer = 0;
            }
        }
        if((Input.GetButtonDown("Player1Inter") && collidingPlayer1) || (Input.GetButtonDown("Player2Inter") && collidingPlayer2)){
            if(trapRaised && canLowerTrap){
                LowerTrap();
                otherTrap.RaiseTrap();
            }
        }
        
    }

        private void FixedUpdate(){
        if(trapRising){
            if(floorTrap.transform.localPosition.y < trapRaisedHeight){
                floorTrap.transform.localPosition += new Vector3(0, trapMoveSpeed * Time.deltaTime, 0);
            }
            else{
                floorTrap.GetComponent<MeshFilter>().mesh = inactiveMesh;
                trapRaised = true;
                trapRising = false;
            }
        }
        else if(trapLowering){
            if(floorTrap.transform.localPosition.y > trapLoweredHeight){
                floorTrap.transform.localPosition -= new Vector3(0, trapMoveSpeed * Time.deltaTime, 0);
            }
            else{
                trapLowering = false;
            }
        }
    }


    public void RaiseTrap(){
        trapRising = true;
    }

    public void LowerTrap(){
        trapLowering = true;
        trapRaised = false;
        canLowerTrap = false;
    }


    private void setRandom(){
        if(Random.Range(0, 2) == 0){
            LowerTrap();
            otherTrap.RaiseTrap();
        }
        else{
            RaiseTrap();
            otherTrap.LowerTrap();
        }
    }
}
