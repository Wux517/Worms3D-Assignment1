using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
   
   [SerializeField] private Camera playerAimCamera;

   private void Update()
   {
      Ray ray = playerAimCamera.ScreenPointToRay(Input.mousePosition);
      
      //Debug.DrawRay(transform.position, transform.forward * 50f, Color.green, 100f);

      if (Physics.Raycast(ray, out RaycastHit raycastHit, 100f))
      {
         transform.position = raycastHit.point;
       
      }
   }
}
