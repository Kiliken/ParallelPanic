using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public Transform orientation;
    public float moveSpeed;
    public float groundDrag;
    public float rotationSpeed;
    public string horizontalAxis;
    public string verticalAxis;
    

    Rigidbody rb;
    float horizontalInput = 0f;
    float verticalInput = 0f;

    public GameObject playerSprite;

    Vector3 moveDirection;

    private bool _moveSlowed = false;
    public bool moveSlowed { get{
        return _moveSlowed;
    } set{
        _moveSlowed = value;
        if(_moveSlowed == true){
            moveSpeed = moveSpeedSlow;
        }
        else{
            moveSpeed = moveSpeedNormal;
        }
    }}
    public float moveSlowedTime = 5f;
    private float moveSlowedTimer = 0f;
    public float moveSpeedNormal = 5f;
    public float moveSpeedSlow = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    
    void Update()
    {
        if(moveSlowed){
            if(moveSlowedTimer < moveSlowedTime){
                moveSlowedTimer += Time.deltaTime;
            }
            else{
                moveSlowed = false;
                moveSlowedTimer = 0;
            }
        }
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
        horizontalInput = Input.GetAxisRaw(horizontalAxis);
        verticalInput = Input.GetAxisRaw(verticalAxis);

        





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
