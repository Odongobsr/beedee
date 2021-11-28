using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Bee
{
  public class FlowerManager : AbstractGameComponent
  {
    public static int stepCount;

    [Header ("References")]
    public ObjectSpawner objectSpawner;

    [Header ("Runtime only")]
    public Stack<Block> inactiveFlowers = new Stack<Block> ();  
    public Stack<Block> activeFlowers = new Stack<Block> ();  

    public override void CheckAssertions()
    {
      base.CheckAssertions();

      Assert.IsNotNull (objectSpawner);
    }

    public override bool Activate ()
    {
      if (!base.Activate ()) return false;

      // create flower object pool
      objectSpawner.objectPool.CreateObjects (
        objects: GameGlobals.Instance.registry.GetFlowerDataObjects (),
        count: GameGlobals.Instance.registry.flowerPoolSize
      );

      return true;
    }
    
    public override void Start ()
    {
      base.Start ();
      
      GameGlobals.Instance.gameController.obstacleManager.objectSpawner.onSpawnObject += IncrementStepCount;
    }

    public override void OnDestroy()
    {
      base.OnDestroy();

      GameGlobals.Instance.gameController.obstacleManager.objectSpawner.onSpawnObject -= IncrementStepCount;
    }

    void IncrementStepCount ()
    {
      stepCount++;
      // Logger.Log ("Increase step count: " + stepCount);
    }
  }
}
