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

      desiredVelocity -= 
        new Vector2 (0, GameGlobals.Instance.registry.globalSpeedMultiplier);
        // (Vector2) GameGlobals.Instance.registry.obstacleSpeed;

      return desiredVelocity;
    }
  }
}