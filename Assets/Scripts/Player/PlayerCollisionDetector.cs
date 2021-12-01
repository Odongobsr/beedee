using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Bee
{
  public class PlayerCollisionDetector : AbstractGameComponent
  {
    [Header ("References")]
    public Player player;

    public override void CheckAssertions ()
    {
      base.CheckAssertions ();

      Assert.IsNotNull (player);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
  #if UNITY_EDITOR
      if (GameGlobals.Instance.registry.debugMode)
      {
        return;
      }
  #endif

      if (player.alive)
      {
        
        if (!other.CompareTag ("Untagged"))
        {
          Logger.Log (
            $"Player has hit {other.attachedRigidbody.tag.Important ()} - {other.attachedRigidbody.name.Important ()}", 
            other.attachedRigidbody
          );
        }

        // has player hit obstacle?
        if (other.CompareTag (GameGlobals.Instance.registry.obstacleTag))
        {
          // disable other collider2d
          GameGlobals.Instance.player.HitObstacle (other);
        }

        else if (other.CompareTag (GameGlobals.Instance.registry.flowerTag))
        {
          // other.enabled = false;
          // GameGlobals.Instance.registry.Pause ();
          GameGlobals.Instance.gameController.flowerManager.PollinateFlower ();
        }
        else if (other.CompareTag (GameGlobals.Instance.registry.coinTag))
        {
          GameGlobals.Instance.gameController.coinManager.CollectCoin (other.gameObject);
          // Logger.Log (
          //   $"Add score: {other.name}",
          //   other
          // ); 
        }
      }
    }
  }
}
