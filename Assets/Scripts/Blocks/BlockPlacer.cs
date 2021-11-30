using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bee
{
  public class BlockPlacer : MonoBehaviour
  {
    public BlockData data;
    public Block block;

    void OnEnable ()
    {
      if (GameGlobals.Instance.registry.worldState != WorldState.Complete)
      {
        return;
      }

      AbstractPoolable obj = GameGlobals.Instance.gameController.obstacleManager.objectSpawner.objectPool.GetInactiveObject ( data );

      // Logger.Log (
      //   $"Place object {obj}",
      //   obj
      // );

      block = obj.GetComponent<Block>();
      block.transform.position = transform.position;
      obj.gameObject.SetActive (true);
    }
  }
}
