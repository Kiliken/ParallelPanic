using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class DoorPair : MonoBehaviour
{
    GameObject DoorA;
    GameObject DoorB;
    public GameObject wallTrapPrefab;
    private bool trapDoor = false;
    public bool TrapDoor {get{
        return trapDoor;
    } set{
        if(value == true)
            SetWallTrap();
        trapDoor = value;
    }}


    private void Awake(){
        DoorA = gameObject.transform.GetChild(0).gameObject;
        DoorB = gameObject.transform.GetChild(1).gameObject;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void SetWallTrap(){
        Vector3 doorAPos = new Vector3(DoorA.transform.localPosition.x, DoorA.transform.localPosition.y - 0.5f, DoorA.transform.localPosition.z);
        Vector3 doorBPos = new Vector3(DoorB.transform.localPosition.x, DoorB.transform.localPosition.y - 0.5f, DoorB.transform.localPosition.z);
        Quaternion doorARot = DoorA.transform.rotation;
        Quaternion doorBRot = DoorB.transform.rotation;
        GameObject.Destroy(DoorA);
        GameObject.Destroy(DoorB);

        DoorA = Instantiate(wallTrapPrefab, doorAPos, doorARot);
        DoorB = Instantiate(wallTrapPrefab, doorBPos, doorBRot);
        DoorA.transform.parent = gameObject.transform;
        DoorB.transform.parent = gameObject.transform;
        DoorA.name = "WallTrapA";
        DoorB.name = "WallTrapB";

        DoorA.GetComponent<WallTrap>().otherTrap = DoorB.GetComponent<WallTrap>();
        DoorB.GetComponent<WallTrap>().otherTrap = DoorA.GetComponent<WallTrap>();
        if(Random.Range(0, 2) == 0){
            DoorA.GetComponent<WallTrap>().LowerWall();
            DoorB.GetComponent<WallTrap>().RaiseWall();
        }
        else{
            DoorB.GetComponent<WallTrap>().LowerWall();
            DoorA.GetComponent<WallTrap>().RaiseWall();
        }
    }
}
