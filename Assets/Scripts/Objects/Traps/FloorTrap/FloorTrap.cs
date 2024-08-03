using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FloorTrap : MonoBehaviour
{
    private void OnTriggerStay(Collider other){
        if(other.gameObject.CompareTag("Player")){
            PlayerController p = other.gameObject.GetComponent<PlayerController>();
            if(!p.moveSlowed){
                p.moveSlowed = true;
            }
        }
    }

    private void OnTriggerExit(Collider other){
        if(other.gameObject.CompareTag("Player")){
            PlayerController p = other.gameObject.GetComponent<PlayerController>();
            p.moveSlowed = false;
        }
    }
}
