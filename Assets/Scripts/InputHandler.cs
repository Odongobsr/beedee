using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
{
  public bool moveLeft;
  public bool moveRight;

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
