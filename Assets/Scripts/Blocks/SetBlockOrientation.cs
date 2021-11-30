using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Bee
{
  public class SetBlockOrientation : AbstractGameComponent
  {
    public bool dontSetOrientation;
    public Block block;

    float left = -2;
    float center = 0;
    float right = 2;

    public override void OnEnable ()
    {
      base.OnEnable ();

      Assert.IsNotNull (block);

      if (dontSetOrientation) return;

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
          // pos = Camera.main.ViewportToWorldPoint (new Vector3 (left, 0, 0));
          pos.x = left;
          break;
          
        // move to center of screen
        case Orientation.Center:
          // pos = Camera.main.ViewportToWorldPoint (new Vector3 (center, 0, 0));
          pos.x = center;
          break;
          
        // move to right edge of screen
        case Orientation.Right:
          // pos = Camera.main.ViewportToWorldPoint (new Vector3 (right, 0, 0));
          pos.x = right;
          break;

        case Orientation.Random:
          Vector3 vec = Vector3.zero;
          if (Random.value < .33f)
          {
            pos.x = left; // left
          }
          else if (Random.value < .66f)
          {
            pos.x = center; // center
          }
          else
          {
            pos.x = right; // right
          }
          // pos = Camera.main.ViewportToWorldPoint (vec);
          break;
      }

      trans.position = pos;
      // Logger.Log ($"Set {trans.name} orientation to {orientation}. Position {trans.position}", trans);
    }
  }
}
