using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Bee
{
  public class InputHandler : MonoBehaviour
  {
    public bool moveLeft;
    public bool moveRight;

    void Update()
    { 
  // #if !UNITY_EDITOR
      // if (Application.platform != RuntimePlatform.Android)
      if (!GameGlobals.Instance.registry.useTouchInput)
      {
        float horizontalInput = Input.GetAxisRaw ("Horizontal");
        if (horizontalInput > 0)    
        {
          moveRight = true;
          moveLeft = false;
        }
        else if (horizontalInput < 0)
        {
          moveRight = false; 
          moveLeft = true; 
        }
        else
        {
          moveRight = false;
          moveLeft = false;
        }
        // Logger.Log ($"Horizontal Input: {horizontalInput}");
      }
  // #endif
    }

    public void MoveLeftDown ()
    {
      moveLeft = true;
    }

    public void MoveLeftUp ()
    {
      moveLeft = false;
    }

    public void MoveRightDown ()
    {
      moveRight = true;
    }
    
    public void MoveRightUp ()
    {
      moveRight = false;
    }
  }
}
