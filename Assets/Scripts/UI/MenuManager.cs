using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private int currentIdx = 0;
    private int maxIdx = 2;
    public GameObject[] buttons;
    // Start is called before the first frame update
    void Start()
    {
        maxIdx = transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
