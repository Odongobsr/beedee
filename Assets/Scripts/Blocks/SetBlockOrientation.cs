using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Bee
{
  public class SetBlockOrientation : AbstractGameComponent
  {
    public Block block;

    public override void OnEnable ()
    {
      base.OnEnable ();

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
          pos = Camera.main.ViewportToWorldPoint (new Vector3 (.25f, 0, 0));
          break;
          
        // move to center of screen
        case Orientation.Center:
          pos = Camera.main.ViewportToWorldPoint (new Vector3 (0.5f, 0, 0));
          break;
          
        // move to right edge of screen
        case Orientation.Right:
          pos = Camera.main.ViewportToWorldPoint (new Vector3 (.75f, 0, 0));
          break;

        case Orientation.Random:
          Vector3 vec = Vector3.zero;
          if (Random.value < .33f)
          {
            vec.x = .25f; // left
          }
          else if (Random.value < .66f)
          {
            vec.x = 0.5f; // center
          }
          else
          {
            vec.x = .75f; // right
          }
          pos = Camera.main.ViewportToWorldPoint (vec);
          break;
      }

      trans.position = new Vector3 (pos.x, trans.position.y, trans.position.z);
      // Logger.Log ($"Set {trans.name} orientation to {orientation}. Position {trans.position}", trans);
    }
  }
}
