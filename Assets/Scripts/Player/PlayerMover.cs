using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : AbstractVelocityModifier
{
  public float speed;
  public Player player;

  public override Vector2 ModifyVelocity (Block block)
  {
    Vector2 desiredVelocity = new Vector2 ();

    if (player.alive)
    {
      if (player.inputHandler.moveLeft)
      {
        desiredVelocity = new Vector2(-GameGlobals.Instance.registry.playerMoveSpeed, 0);
      }
      else if (player.inputHandler.moveRight)
      {
        desiredVelocity = new Vector2(GameGlobals.Instance.registry.playerMoveSpeed, 0);
      }
    }

    return desiredVelocity;
  }
}
