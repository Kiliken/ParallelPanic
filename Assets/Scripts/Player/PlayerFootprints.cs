using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootprints : MonoBehaviour
{
    public bool isNegative = false;
    public Transform reflector;

    public Transform playerSprite;
    Vector3 posReflect = Vector3.zero;
    float side = 1f;
    float distance;
    void Start()
    {
        if (isNegative)
            side = -1f;
    }

    // Update is called once per frame
    void Update()
    {
        distance = playerSprite.position.x - reflector.position.x;
        transform.position = reflector.position + (new Vector3(distance * side,playerSprite.position.y,playerSprite.position.z));
        transform.rotation = new Quaternion(playerSprite.rotation.x , playerSprite.rotation.y * -1f, playerSprite.rotation.z, playerSprite.rotation.w);
    }
}
