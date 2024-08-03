using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPair : MonoBehaviour
{
    GameObject posA;
    GameObject posB;
    public GameObject slowTrapPrefab;
    public GameObject alarmTrapPrefab;
    public GameObject darkTrapPrefab;
    public GameObject trapA;
    public GameObject trapB;
    // 0 = slow trap, 1 = alarm trap, 2 = dark trap
    private int trapType = 0;
    public int TrapType {get{
        return trapType;
    } set{
        switch(value){
            case 0:
                SetSlowTrap();
                break;
            case 1:
                SetAlarmTrap();
                break;
            case 2:
                SetDarkTrap();
                break;
        }
        trapType = value;
    }}


    private void Awake(){
        posA = gameObject.transform.GetChild(0).gameObject;
        posB = gameObject.transform.GetChild(1).gameObject;
    }


    // Start is called before the first frame update
    void Start()
    {
        //SetSlowTrap();
    }


    private void SetSlowTrap(){
        trapA = Instantiate(slowTrapPrefab, posA.transform.localPosition, Quaternion.identity);
        trapA.transform.parent = posA.transform;
        trapB = Instantiate(slowTrapPrefab, posB.transform.localPosition, Quaternion.identity);
        trapB.transform.parent = posB.transform;

        trapA.GetComponent<FloorTrapTrigger>().otherTrap = trapB.GetComponent<FloorTrapTrigger>();
        trapB.GetComponent<FloorTrapTrigger>().otherTrap = trapA.GetComponent<FloorTrapTrigger>();

        if(Random.Range(0, 2) == 0){
            trapA.GetComponent<FloorTrapTrigger>().LowerTrap();
            trapB.GetComponent<FloorTrapTrigger>().RaiseTrap();
        }
        else{
            trapB.GetComponent<FloorTrapTrigger>().LowerTrap();
            trapA.GetComponent<FloorTrapTrigger>().RaiseTrap();
        }
    }

    private void SetAlarmTrap(){

    }

    private void SetDarkTrap(){

    }
}
