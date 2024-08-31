using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapManager : MonoBehaviour
{
    private int trapPairCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        trapPairCount = transform.childCount;
        for(int i = 0; i < trapPairCount; i++){
            transform.GetChild(i).GetComponent<TrapPair>().TrapType = Random.Range(0, 3); // set to random later
        }
        
    }
}
