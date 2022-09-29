using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerWeaponPickup : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject projectilePrefab;
    public GameObject projectilePrefabAxe;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PowerWeaponUp(other);
        }
    }

    void PowerWeaponUp(Collider player)
    {
        Debug.Log("Power Weapon");

        

        Throwing stats = player.GetComponent<Throwing>();
        stats.throwForce = stats.throwForce = 50;
        stats.throwUpwardForce = stats.throwUpwardForce = 5;
        stats.totalThrows = 2;

        stats.objectToThrow = Instantiate(projectilePrefab);

        if (stats.totalThrows == 0 )
        {
            stats.objectToThrow = Instantiate(projectilePrefabAxe);
            stats.totalThrows = 2;
        }
        
        Destroy(gameObject);

        // spawn cool effect
        // apply effect

    }
}
