using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
   
   [SerializeField] private Camera playerAimCamera;
   [SerializeField] private LineRenderer lineRenderer;
   [SerializeField] private GameObject player;

   private void Update()
   {
      Ray ray = playerAimCamera.ScreenPointToRay(Input.mousePosition);
      
      //Debug.DrawRay(transform.position, transform.forward * 50f, Color.green, 100f);
      
      
      
      if (Physics.Raycast(ray, out RaycastHit raycastHit, 100f))
      {
         transform.position = raycastHit.point;
       
         //Linerenderer
         Vector3 start = transform.position;

         Vector3 end = player.transform.position;
      
         lineRenderer.SetPosition(0, start);
         lineRenderer.SetPosition(1, end);
      }
   }
}
