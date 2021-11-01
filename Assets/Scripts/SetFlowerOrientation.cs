using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class SetFlowerOrientation : MonoBehaviour
{
  public Orientation orientation;
  public Flower flower;

  void OnEnable()
  {
    Assert.IsNotNull (flower);

    float r = Random.value;
    if (r < 0.5f)
    {
      orientation = Orientation.Left;
    }
    else
    {
      orientation = Orientation.Right;
    }

    // Logger.Log ("R: " + r);
    SetOrientation (
      trans: flower.transform, 
      orientation: orientation
    );
  }
    
  void SetOrientation (Transform trans, Orientation orientation, bool rotate = false)
  {
    Vector3 pos = trans.position;

    switch (orientation)
    {
      // move to left edge of screen
      case Orientation.Left:
        pos = Camera.main.ViewportToWorldPoint (new Vector3 (0.15f, 0, 0));
        break;
        
      // move to center of screen
      case Orientation.Center:
        pos = Camera.main.ViewportToWorldPoint (new Vector3 (0.5f, 0, 0));
        break;
        
      // move to right edge of screen
      case Orientation.Right:
        pos = Camera.main.ViewportToWorldPoint (new Vector3 (0.85f, 0, 0));
        break;
    }

    trans.position = new Vector3 (pos.x, trans.position.y, trans.position.z);
    // Logger.Log ($"Set {trans.name} orientation to {orientation}. Position {trans.position}", trans);
  }
}
