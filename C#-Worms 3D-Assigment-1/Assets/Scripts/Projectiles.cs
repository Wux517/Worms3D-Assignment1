using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    public int damage;

    private Rigidbody rb;

    private bool targetHit;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (targetHit)
        {

            return;
            

        }
        else
        {
            targetHit = true;
            
        }

        if (collision.gameObject.GetComponent<Enemy>() != null)
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            
            enemy.TakeDamage(damage);
            
            Destroy(gameObject);
        }

        rb.isKinematic = true;

        transform.SetParent(collision.transform);
    }


    // Update is called once per frame
    void Update()
    {
    }
}