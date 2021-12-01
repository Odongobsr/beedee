using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Bee
{
  public class ObstacleManager : StateListener
  {
    [Header ("Configuration")]
    public bool isSpawning;

    [Header ("References")]
    public ObjectSpawner objectSpawner;

    [Header ("Runtime only")]
    // public float lastSpawnPosition;
    public float nextSpawnPosition;

    public override void CheckAssertions ()
    {
      base.CheckAssertions ();

      Assert.IsNotNull (objectSpawner);
    }

    public override bool Enter ()
    {
      if (!base.Enter ()) return false;

      // create obstacle object pool
       objectSpawner.RegeneratePattern ();
       objectSpawner.objectPool.CreateObjects ();

      return true;
    }

    public override void MyFixedUpdate()
    {
      base.MyFixedUpdate();

      if (isSpawning)
      {
        if (GameGlobals.Instance.gameController.globalYPosition >= nextSpawnPosition)
        {
          objectSpawner.SpawnObject ();
          UpdateSpawnPosition ();
        }
      }
    }

    public void StartSpawningObstacles ()
    {
      UpdateSpawnPosition ();
      isSpawning = true;
      Logger.Log (
        $"Start spawning obstacles",
        this
      );
    }

    void UpdateSpawnPosition ()
    {
      nextSpawnPosition = 
        GameGlobals.Instance.gameController.globalYPosition + 
        GameGlobals.Instance.registry.spawnDistance;
    }
  }
}
