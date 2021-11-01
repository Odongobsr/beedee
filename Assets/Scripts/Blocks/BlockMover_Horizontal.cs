using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMover_Horizontal : AbstractVelocityModifier
{
  public float speed;
  public bool bounce;

  public override Vector2 ModifyVelocity(Block block)
  {
    Vector2 desiredVelocity = new Vector2 ();
    desiredVelocity.x = speed * block.xDir;

    if (bounce)
    {
      Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

      if (block.xDir > 0)
      {
        if (pos.x > 1.0)
        {
         block.desiredVelocity.x *= -1;
         desiredVelocity.x *= -1;
        }
      }
      else if (block.xDir < 0)
      {
        if (pos.x < 0)
        {
          block.desiredVelocity.x *= -1;
          desiredVelocity.x *= -1;
        }
      }
    }

    return desiredVelocity;
  }
}
