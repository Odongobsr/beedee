using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bee
{
  public class BlockPlacer : StateListener
  {
    public BlockData data;
    public Block block;
    public Transform holder;

    public override void OnEnable()
    {
      if ( GameGlobals.Instance.registry.worldState != WorldState.Complete)
      {
        return;
      }

      if (null == holder)
      {
        holder = transform;
      }

      AbstractPoolable obj = GameGlobals.Instance.gameController.obstacleManager.objectSpawner.objectPool.GetInactiveObject ( data );

      // Logger.Log (
      //   $"Place object {obj}",
      //   obj
      // );

      block = obj.GetComponent<Block>();
      block.transform.position = holder.position;
      obj.gameObject.SetActive (true);
    }
  }
}
