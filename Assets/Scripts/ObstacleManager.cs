using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Bee
{
  public class ObstacleManager : StateListener
  {
    [Header ("Configuration")]
    public ObjectPatternGenerator objectPatternGenerator;

    [Header ("References")]
    public ObjectSpawner objectSpawner;

    [Header ("Runtime only")]
    public Stack<Block> inactiveObstacles = new Stack<Block> ();  
    public Stack<Block> activeObstacles = new Stack<Block> ();  

    public override void CheckAssertions ()
    {
      base.CheckAssertions ();

      Assert.IsNotNull (objectSpawner);
    }

    public override bool Enter ()
    {
      if (!base.Enter ()) return false;

      // create obstacle object pool
       objectSpawner.objectPool.CreateObjects ();

      return true;
    }

    public void StartSpawningObstacles ()
    {
      objectSpawner.StartSpawningObjects (wait: GameGlobals.Instance.registry.obstacleWaitTime);
    }
  }
}
