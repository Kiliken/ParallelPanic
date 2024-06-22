using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other){
        
        if(other.gameObject.CompareTag("Player")){
            if(other.GetComponent<Player>().holdingKey == false){
                Debug.Log("Player collected Key");
                other.GetComponent<Player>().holdingKey = true;
                Destroy(gameObject);
            }
        }
    }
}
