using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    public int damage;
    public int objectDamage;

    private Rigidbody rb;

    [SerializeField] private GameObject projectile;

    private float projectileLifetime = 10;
    private float currentLifetime;
    
    private bool targetHit;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentLifetime = 0;
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
            Debug.Log("Has Destroyed PROJ ENEMY");
            
        }
        
        if (collision.gameObject.GetComponent<DestructableWall>() != null)
        {
            DestructableWall enemy = collision.gameObject.GetComponent<DestructableWall>();
            
            enemy.TakeObjectDamage(objectDamage);
            
            
            Destroy(gameObject);
            Debug.Log("Has Destroyed PROJ WALL");
            
        }

        rb.isKinematic = true;

        transform.SetParent(collision.transform);
    }


    // Update is called once per frame
    void Update()
    {
        currentLifetime += 1 * Time.deltaTime;

        if (currentLifetime >= projectileLifetime)
        {
            Destroy(projectile);
            Debug.Log("Has Destroyed PROJ TIMER");
        }

    }
}