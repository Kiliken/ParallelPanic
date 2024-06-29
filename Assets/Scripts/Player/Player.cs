using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public bool holdingKey = false;
    public bool canInteract = false;

    [Header("UI")]
    public Image ButtonA;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canInteract)
            ButtonA.gameObject.SetActive(true);
        else
            ButtonA.gameObject.SetActive(false);
    }
}
