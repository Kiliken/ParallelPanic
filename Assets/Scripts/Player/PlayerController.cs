using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public Transform orientation;
    public float moveSpeed;
    public float groundDrag;
    public float rotationSpeed;
    

    Rigidbody rb;
    float horizontalInput;
    float verticalInput;

    public GameObject playerSprite;

    Vector3 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    
    void Update()
    {
        PlayerInput();
        SpeedControl();

    }

    private void FixedUpdate()
    {
        MovePlayer();
        if (moveDirection != Vector3.zero)
        {
            RotatePlayer();
        }
    }

    private void PlayerInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");


    }

    private void MovePlayer() 
    { 
        moveDirection = orientation.forward* verticalInput + orientation.right * horizontalInput;

        rb.AddForce(moveDirection.normalized * moveSpeed *10f, ForceMode.Force);

    }

    private void SpeedControl()
    {
        Vector3 flatVet = new Vector3(rb.velocity.x, 0f,rb.velocity.z);

        if (flatVet.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVet.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void RotatePlayer()
    {
        float angle = Mathf.Atan2(horizontalInput, verticalInput);
        angle = angle * Mathf.Rad2Deg;
        playerSprite.transform.eulerAngles = new Vector3(0, angle, 0);
    }

}
