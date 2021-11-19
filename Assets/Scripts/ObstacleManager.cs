using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Bee
{
  public class ObstacleManager : AbstractGameObject
  {
    [Header ("References")]
    public ObjectPool obstaclePool;
    public ObjectSpawner obstacleSpawner;

    [Header ("Runtime only")]
    public Stack<Block> inactiveObstacles = new Stack<Block> ();  
    public Stack<Block> activeObstacles = new Stack<Block> ();  

    void Awake ()
    {
      Assert.IsNotNull (obstaclePool.holder);
      Assert.IsNotNull (obstacleSpawner);
    }

    public override void Activate ()
    {
      base.Activate ();

      // create obstacle object pool
      obstaclePool.CreateObjects (
        objects: GameGlobals.Instance.registry.GetObstacleDataObjects (),
        count: GameGlobals.Instance.registry.obstaclePoolSize
      );
    }

    public void StartSpawningObstacles ()
    {
      obstacleSpawner.StartSpawningObjects (wait: GameGlobals.Instance.registry.obstacleWaitTime);
    }
  }
}
