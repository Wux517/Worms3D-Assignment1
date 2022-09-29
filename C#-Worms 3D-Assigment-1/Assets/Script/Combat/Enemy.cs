using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   public float health = 10;

   public void TakeDamage(int damage)
   {
      health -= damage;

      if (health <= 0)
      {
         Destroy(gameObject);
         Debug.Log("Has Destroyed ENEMEMY");
         
         
      }
   }
}
