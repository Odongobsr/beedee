using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bee
{
  public class BlockPlacer : StateListener
  {
    public BlockData data;
    public Block block;

    public override bool Enter ()
    {
      if (!base.Enter ()) return false;

      AbstractPoolable obj = GameGlobals.Instance.gameController.obstacleManager.objectSpawner.objectPool.GetInactiveObject ( data );

      Logger.Log (
        $"Place object {obj}",
        obj
      );

      block = obj.GetComponent<Block>();
      block.transform.position = transform.position;
      obj.gameObject.SetActive (true);

      return true;
    }
  }
}
