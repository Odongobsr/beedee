using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PlayerCollisionDetector : MonoBehaviour
{
  public Player player;

  void Awake ()
  {
    Assert.IsNotNull (player);
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    if (player.alive)
    {
      // has player hit obstacle?
      if (other.CompareTag (GameGlobals.Instance.registry.obstacleTag))
      {
        // disable other collider2d
        other.enabled = false;
        Logger.Log ($"Player has hit {other.attachedRigidbody.tag} - {other.attachedRigidbody.name}", other.attachedRigidbody);
        player.Die ();
      }
    }
  }
}
