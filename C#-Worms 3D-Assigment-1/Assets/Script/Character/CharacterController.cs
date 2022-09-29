using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody characterBody;
    [SerializeField] private Camera playerAimCamera;
    
    [SerializeField] private float walkingTime;
    
    [SerializeField] private int playerIndex;

    public float maxSlopeAngle;
    private RaycastHit slopeHit;
    
    

    private float currentWalkTime;
    

    private void Awake()
    {
        playerAimCamera.depth = -1;
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void FixedUpdate()
    {


        if (TurnManager.GetInstance().IsItPlayerTurn(playerIndex))
        {


            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                currentWalkTime += Time.deltaTime;

                if (currentWalkTime <= walkingTime)
                {
                    MovePlayerRelativeToCamera();
                }
            }
            
        }

        if (TurnManager.GetInstance().currentTurnTime >= TurnManager.GetInstance().turnDuration)
        {

            currentWalkTime = 15;
        }



    }

    private void Update()
    {

        if (TurnManager.GetInstance().IsItPlayerTurn(playerIndex))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }

            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                playerAimCamera.depth = 2;
                Cursor.lockState = CursorLockMode.None;
            }

            if (Input.GetKeyUp(KeyCode.Mouse1))
            {
                playerAimCamera.depth = -1;
                Cursor.lockState = CursorLockMode.Locked;
            }

        }

    }

    // Update is called once per frame
    


    private void Jump()
    {
        if (IsTouchingGround())
        {
            characterBody.AddForce(Vector3.up * 300f);
        }
    }

   /* private bool OnSlope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, 1f))
        {
            float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle < maxSlopeAngle && angle != 0;
        }

        return false;
    }

    private Vector3 GetSlopeMoveDirection()
    {
        return Vector3.ProjectOnPlane(moveDirection, slopeHit.normal).normalized;
    } */

    private bool IsTouchingGround()
    {
        Vector3 position = transform.position + Vector3.down * 1f;
        RaycastHit hit;
        return Physics.SphereCast(transform.position, 0.15f, -transform.up, out hit, 1f);
    }

    void MovePlayerRelativeToCamera()
    {
        // Get player input
        float playerVerticalInput = Input.GetAxisRaw("Vertical");
        float playerHorizontalInput = Input.GetAxisRaw("Horizontal");


        Vector3 direction = new Vector3(playerHorizontalInput, 0f, playerVerticalInput).normalized;


        // Get Camera-Normalized Directional Vectors
        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;
        // Remove Y values to keep player grounded
        forward.y = 0;
        right.y = 0;
        forward = forward.normalized;
        right = right.normalized;

        if (direction != Vector3.zero)
        {
            transform.forward = forward;
            forward.y = 0;
        }


        // Create Direction relative Input Vectors
        Vector3 forwardRelativeVerticalInput = playerVerticalInput * forward;
        Vector3 rightRelativeVerticalInput = playerHorizontalInput * right;

        // Create Camera-Relative Movement
        Vector3 cameraRelativeMovement = forwardRelativeVerticalInput + rightRelativeVerticalInput;

        transform.Translate(cameraRelativeMovement * speed * Time.deltaTime, Space.World);
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "jumpPadLeft")
        {
            Debug.Log("Hover");

            characterBody.AddForce(Vector3.up * 40 + Vector3.forward * 20 + Vector3.right * 20);
        }
        if (other.gameObject.tag == "jumpPadLeftP2")
        {
            Debug.Log("Hover");

            characterBody.AddForce(Vector3.up * 40 + Vector3.forward * 20 + Vector3.left * 20);
        }
        
        if (other.gameObject.tag == "jumpPadRight")
        {
            Debug.Log("Hover");

            characterBody.AddForce(Vector3.up * 40 + Vector3.back * 20 + Vector3.right * 20);
        }
        if (other.gameObject.tag == "jumpPadRightP2")
        {
            Debug.Log("Hover");

            characterBody.AddForce(Vector3.up * 40 + Vector3.back * 20 + Vector3.left * 20);
        }
    }

    /*public void Shoot()
    {
       RaycastHit result;
        bool thereWasHit = Physics.Raycast(transform.position, transform.forward, out result, Mathf.Infinity);
        
        Debug.DrawRay(transform.position, transform.forward * 50f, Color.green, 100f);
       
       
        
        
    }*/
}