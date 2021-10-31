using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
  public float speed;
  public Player player;

  void Update()
  {
      if (player.inputHandler.moveLeft)
      {
        player.desiredVelocity = new Vector2(-speed, 0);
      }
      else if (player.inputHandler.moveRight)
      {
        player.desiredVelocity = new Vector2(speed, 0);
      }
      else
      {
        player.desiredVelocity = new Vector2();
      }
  }
}
