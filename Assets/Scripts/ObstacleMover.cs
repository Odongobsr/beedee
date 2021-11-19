using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bee
{
  public class ObstacleMover : AbstractVelocityModifier
  {
    public override Vector2 ModifyVelocity (Block block)
    {
      Vector2 desiredVelocity = new Vector2 ();

      desiredVelocity += 
        (Vector2) GameGlobals.Instance.registry.obstacleSpeed;

      return desiredVelocity;
    }
  }
}