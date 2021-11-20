using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Bee
{
  public class PlayerCollisionDetector : MonoBehaviour
  {
    public GameObject bump;
    public Player player;
    public AudioSource flowerSound;
    public AudioSource obstacleSound;

    void Awake ()
    {
      Assert.IsNotNull (player);
      Assert.IsNotNull (flowerSound);
      Assert.IsNotNull (obstacleSound);
      Assert.IsNotNull (bump);

      HideBump ();
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
          bump.gameObject.SetActive (true);
          bump.transform.position = player.transform.position;
          Invoke ("HideBump", 0.2f);
        }

        else if (other.CompareTag (GameGlobals.Instance.registry.flowerTag))
        {
          // other.enabled = false;
          // GameGlobals.Instance.registry.Pause ();
          flowerSound.Play ();
          GameGlobals.Instance.darkGroundSprite.ChangeAlpha (
            _diff: GameGlobals.Instance.registry.groundLightenValue,
            _time: GameGlobals.Instance.registry.groundLightenTime
          );
        }
        Logger.Log ($"Player has hit {other.attachedRigidbody.tag} - {other.attachedRigidbody.name}", other.attachedRigidbody);
      }
    }

    void HideBump ()
    {
      bump.gameObject.SetActive (false);
    }
  }
}
