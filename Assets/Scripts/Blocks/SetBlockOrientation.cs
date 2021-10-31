using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class SetBlockOrientation : MonoBehaviour
{
  public Block block;

  void OnEnable()
  {
    Assert.IsNotNull (block);

    if (block && block.data)   
    {
      if (block.data.GetType () == typeof (BlockData))
      {
        BlockData data = (BlockData) block.data;

        SetOrientation (
          trans: block.transform, 
          orientation: data.orientation, 
          rotate: data.rotateToOrientation
        );
      }
      else
      {
        Logger.LogWarning($"{block.data} is not of type BlockData!", block.data);
      }
    }   
  }
    
  void SetOrientation (Transform trans, Orientation orientation, bool rotate = false)
  {
    Vector3 pos = trans.position;

    switch (orientation)
    {
      // move to left edge of screen
      case Orientation.Left:
        pos = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, 0));
        if (rotate)
        {
          trans.rotation = Quaternion.Euler (0, 0, -90);
        }
        break;
        
      // move to center of screen
      case Orientation.Center:
        pos = Camera.main.ViewportToWorldPoint (new Vector3 (0.5f, 0, 0));
        if (rotate)
        {
          trans.rotation = Quaternion.identity;
        }
        break;
        
      // move to right edge of screen
      case Orientation.Right:
        pos = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, 0));
        if (rotate)
        {
          trans.rotation = Quaternion.Euler (0, 0, 90);
        }
        break;
    }

    trans.position = new Vector3 (pos.x, trans.position.y, trans.position.z);
    // Logger.Log ($"Set {trans.name} orientation to {orientation}. Position {trans.position}", trans);
  }
}
