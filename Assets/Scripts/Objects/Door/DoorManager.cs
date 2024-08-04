using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random=UnityEngine.Random;


public class DoorManager : MonoBehaviour
{
    [SerializeField]private int trapNo = 3;
    [SerializeField] private int[] trapDoors;
    private int doorPairCount = 0;


    // Start is called before the first frame update
    void Start()
    {
        doorPairCount = transform.childCount;
        SetUpDoors();
    }

    private void SetUpDoors(){
        trapDoors = new int[trapNo];
        Array.Fill(trapDoors, -1);
        for(int i = 0; i < trapNo; i++){
            int td = Random.Range(0, doorPairCount);
            while(trapDoors.Contains(td)){
                td = Random.Range(0, doorPairCount);
            }
            trapDoors[i] = td;
            Debug.Log("trap door in " + td);
        }

        for(int i = 0; i < doorPairCount; i++){
            if(trapDoors.Contains(i)){
                transform.GetChild(i).GetComponent<DoorPair>().TrapDoor = true;
            }
        }
    }
}
