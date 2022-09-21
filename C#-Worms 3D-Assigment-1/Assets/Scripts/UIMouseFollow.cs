using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMouseFollow : MonoBehaviour
{

  

  
  private void Start()
  {
   
    Cursor.visible = false;
  }

  private void Update()
  {

    this.transform.position = Input.mousePosition;
  }
  
  
}
