using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Throwing : MonoBehaviour
{
    [SerializeField] private Camera playerAimCamera;
    public Transform cam;
    public Transform attackPoint;
    public GameObject objectToThrow;
    

    public int totalThrows;
    public float throwCooldown;

    public KeyCode throwKey = KeyCode.F;
    public float throwForce;
    public float throwUpwardForce;

    bool readyToThrow;

    private void Start()
    {
       
        
            readyToThrow = true;

        
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(throwKey) && readyToThrow && totalThrows > 0)
        {
            Throw();
        }
    }

    private void Throw()
    {
        readyToThrow = false;

        GameObject projectile = Instantiate(objectToThrow, attackPoint.position, cam.rotation);

        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        

        Vector3 forceDirection = cam.forward;
        
        Ray ray = playerAimCamera.ScreenPointToRay(Input.mousePosition);
        

        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            //Direction Point A -> B = B - A

            forceDirection = (raycastHit.point - attackPoint.position).normalized;
        }
        
        Vector3 forceToAdd = forceDirection * throwForce + transform.up * throwUpwardForce;

        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);
        
        totalThrows--;

        Invoke(nameof(ResetThrow), throwCooldown);
    }

    private void ResetThrow()
    {
        readyToThrow = true;
    }

    

}