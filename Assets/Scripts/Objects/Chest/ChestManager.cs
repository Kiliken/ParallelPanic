using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random=UnityEngine.Random;

public class ChestManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> chestPairs;
    [SerializeField] private int trapNo = 3; 
    [SerializeField] private int[] trapChests;
    [SerializeField] private int keyChest;


    // Start is called before the first frame update
    void Start()
    {
        SetUpChests();
        
    }


    // set up chests in the game
    public void SetUpChests(){
        // key not in first chest
        keyChest = Random.Range(1, chestPairs.Count);
        Debug.Log("key in " + keyChest);

        trapChests = new int[trapNo];
        Array.Fill(trapChests, -1);
        for(int i = 0; i < trapNo; i++){
            int tc = Random.Range(0, chestPairs.Count);
            while(trapChests.Contains(tc) || tc == keyChest){
                tc = Random.Range(0, chestPairs.Count);
            }
            trapChests[i] = tc;
            Debug.Log("trap in " + tc);
        }

        for(int i = 0; i < chestPairs.Count; i++){
            int ct = 0;
            if(i == keyChest){
                ct = 1;
            }
            else if(trapChests.Contains(i)){
                ct = 2;
            }

            chestPairs[i].gameObject.transform.GetChild(0).gameObject.GetComponent<Chest>().ChestType = ct;
            chestPairs[i].gameObject.transform.GetChild(1).gameObject.GetComponent<Chest>().ChestType = ct;
        }
    }
}
