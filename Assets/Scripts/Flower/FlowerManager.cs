using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class FlowerManager : AbstractGameObject
{
  public static int stepCount;

  [Header ("References")]
  public ObjectPool flowerPool;
  public ObjectSpawner objectSpawner;

  [Header ("Runtime only")]
  public Stack<Block> inactiveFlowers = new Stack<Block> ();  
  public Stack<Block> activeFlowers = new Stack<Block> ();  

  void Awake ()
  {
    Assert.IsNotNull (flowerPool.holder);
  }

  public override void Activate ()
  {
    base.Activate ();

    // create flower object pool
    flowerPool.CreateObjects (
      objects: GameGlobals.Instance.registry.GetFlowerDataObjects (),
      count: GameGlobals.Instance.registry.flowerPoolSize
    );
  }
  
  void Start()
  {
    GameGlobals.Instance.gameController.obstacleManager.obstacleSpawner.onSpawnObject += IncrementStepCount;
  }

  void OnDestroy()
  {
    GameGlobals.Instance.gameController.obstacleManager.obstacleSpawner.onSpawnObject -= IncrementStepCount;
  }

  void IncrementStepCount ()
  {
    stepCount++;
    // Logger.Log ("Increase step count: " + stepCount);
  }
  
}
