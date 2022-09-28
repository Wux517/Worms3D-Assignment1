using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerDeath : MonoBehaviour
{
   [SerializeField] private GameObject player1;
   [SerializeField] private GameObject player2;

   private void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag("Player"))
      {
         Destroy(player1);
         Destroy(player2);
         
         Debug.Log("Has Destroyed TRIGGER");
      }
      
   }
}
