using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random=UnityEngine.Random;

public class ChestManager : MonoBehaviour
{
    [SerializeField] private int trapNo = 3; 
    [SerializeField] private int[] trapChests;
    [SerializeField] private int keyChest;
    private int chestPairCount = 0;


    // Start is called before the first frame update
    void Start()
    {
        chestPairCount = transform.childCount;
        SetUpChests();
    }


    // set up chests in the game
    public void SetUpChests(){
        // key not in first chest
        keyChest = Random.Range(1, chestPairCount);
        Debug.Log("key in " + keyChest);

        trapChests = new int[trapNo];
        Array.Fill(trapChests, -1);
        for(int i = 0; i < trapNo; i++){
            int tc = Random.Range(0, chestPairCount);
            while(trapChests.Contains(tc) || tc == keyChest){
                tc = Random.Range(0, chestPairCount);
            }
            trapChests[i] = tc;
            Debug.Log("trap in " + tc);
        }

        for(int i = 0; i < chestPairCount; i++){
            int ct = 0;
            if(i == keyChest){
                ct = 1;
            }
            else if(trapChests.Contains(i)){
                ct = 2;
            }

            transform.GetChild(i).gameObject.transform.GetChild(0).gameObject.GetComponent<Chest>().ChestType = ct;
            transform.GetChild(i).gameObject.transform.GetChild(1).gameObject.GetComponent<Chest>().ChestType = ct;
        }
    }
}
