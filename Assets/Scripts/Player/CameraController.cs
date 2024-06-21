using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerPos;

    void Update()
    {
        transform.position = playerPos.transform.position;
    }
}
