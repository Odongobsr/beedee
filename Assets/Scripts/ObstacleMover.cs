using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
  public Block block;

  void FixedUpdate()
  {
      block.desiredVelocity += GameGlobals.Instance.registry.obstacleSpeed;;
  }
}
