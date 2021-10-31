using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class ObstacleManager : AbstractGameObject
{
  [Header ("References")]
  public Transform obstacleHolder;

  [Header ("Runtime only")]
  public Stack<Block> inactiveObstacles = new Stack<Block> ();  
  public Stack<Block> activeObstacles = new Stack<Block> ();  

  void Awake ()
  {
    Assert.IsNotNull (obstacleHolder);
  }

  public override void Activate ()
  {
    base.Activate ();

    for (int i = 0; i < GameGlobals.Instance.registry.obstacleDataList.Count; i++)
    {
      for (int j = 0; j < GameGlobals.Instance.registry.obstaclePoolSize; j++)
      {
        BlockData data = GameGlobals.Instance.registry.obstacleDataList [i];

        if (null == data || null == data.prefab)
        {
          Logger.LogWarning ($"Obstacle is null at index {i}");
          continue;
        }

        Block block = Instantiate (
          original: data.prefab,
          position: Vector3.zero,
          rotation: Quaternion.identity,
          parent:obstacleHolder 
        ) as Block;

        block.gameObject.SetActive (false);

        inactiveObstacles.Push (block);
      }
    }

    StartCoroutine (CreateObstacleCoroutine ());
  }

  IEnumerator CreateObstacleCoroutine ()
  {
    Logger.Log ("Start creating obstacles", this);

    while (active)
    {
      CreateObstacle ();
      yield return new WaitForSeconds (GameGlobals.Instance.registry.GetObstacleWaitTime ());
    }
  }

  void CreateObstacle ()
  {
    if (inactiveObstacles.Count == 0)
    {
      Logger.LogError ("No obstacles!");
      return;
    }

    Block obstacle = inactiveObstacles.Pop ();

    if (null == obstacle)
    {
      Logger.LogWarning ("Obstacle is null!");
      return;
    }
    
    // activate obstacle
    obstacle.gameObject.SetActive (true);

    activeObstacles.Push (obstacle);

    Logger.Log ($"Create obstacle {obstacle.name}", obstacle);
  }
}
