using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PlayerCollisionDetector : MonoBehaviour
{
  public Player player;
  public AudioSource flowerSound;
  public AudioSource obstacleSound;

  void Awake ()
  {
    Assert.IsNotNull (player);
    Assert.IsNotNull (flowerSound);
    Assert.IsNotNull (obstacleSound);
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
      // has player hit obstacle?
      if (other.CompareTag (GameGlobals.Instance.registry.obstacleTag))
      {
        // disable other collider2d
        other.enabled = false;
        player.Die ();
        obstacleSound.Play ();
      }

      else if (other.CompareTag (GameGlobals.Instance.registry.flowerTag))
      {
        other.enabled = false;
        GameGlobals.Instance.registry.Pause ();
        flowerSound.Play ();
      }
      Logger.Log ($"Player has hit {other.attachedRigidbody.tag} - {other.attachedRigidbody.name}", other.attachedRigidbody);
    }
  }
}
