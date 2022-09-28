using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAttach : MonoBehaviour
{
   public GameObject player1;
   public GameObject player2;

   private void OnTriggerEnter(Collider other)
   {
      if(other.gameObject == player1)
      {
         player1.transform.parent = transform;
         
      }
      if(other.gameObject == player2)
      {
         player2.transform.parent = transform;
         
      }
   }
   
   

   private void OnTriggerExit(Collider other)
   {
      if(other.gameObject == player1)
      {
         player1.transform.parent = null;
         
      } 
      if(other.gameObject == player2)
      {
         player2.transform.parent = null;
         
      }
   }
}
