using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
   private void Start()
   {
      Cursor.visible = false;
      
   }

   private void Update()
   {

      if (Input.GetKeyDown(KeyCode.Escape))
      {
         Cursor.visible = true;
      }
      transform.position = Input.mousePosition;
   }
}
