using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pickupEffect;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HealthUp(other);
        }
    }

    void HealthUp(Collider player)
    {
        Debug.Log("Health Boost");

        

        Enemy stats = player.GetComponent<Enemy>();
        stats.health = stats.health + 10;
        
        Destroy(gameObject);

        // spawn cool effect
        // apply effect

    }
}
