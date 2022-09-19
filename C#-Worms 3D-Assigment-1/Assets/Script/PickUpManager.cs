using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;

public class PickUpManager : MonoBehaviour

{
   private static PickUpManager instance;
   [SerializeField] GameObject pickUpPrefab;

   private void Awake()
   {
      if (instance == null)
      {
         instance = this;
      }

      else
      {
         Destroy(gameObject);
      }
   }

   public static PickUpManager GetInstance()
   {
      return instance;
   }

   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.E))
      {
         GameObject newPickUp = Instantiate(pickUpPrefab);
         newPickUp.transform.position = new Vector3(Random.Range(-11f, 28f), 2f, Random.Range(-11f, 28f));
      }
   }
}
