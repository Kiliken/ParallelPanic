using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FloorTrap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerStay(Collider other){
        if(other.gameObject.CompareTag("Player")){
            PlayerController p = other.gameObject.GetComponent<PlayerController>();
            if(!p.moveSlowed){
                p.moveSlowed = true;
            }
        }
    }
}
