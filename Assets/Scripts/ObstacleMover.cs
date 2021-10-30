using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : AbstractBlockDependent
{
  void FixedUpdate()
  {
    block.desiredVelocity += GameGlobals.Instance.registry.obstacleSpeed;;
  }
}
