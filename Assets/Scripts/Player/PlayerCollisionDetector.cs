using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Bee
{
  public class PlayerCollisionDetector : AbstractGameComponent
  {
    [Header ("References")]
    /// <summary>
    /// Shown when player collides with an obstacle
    /// </summary>
    public GameObject bump;
    public Player player;
    public AudioSource flowerSound;
    public AudioSource coinSound;
    public AudioSource obstacleSound;

    public override void CheckAssertions ()
    {
      base.CheckAssertions ();

      Assert.IsNotNull (player);
      Assert.IsNotNull (flowerSound);
      Assert.IsNotNull (coinSound);
      Assert.IsNotNull (obstacleSound);
      Assert.IsNotNull (bump);
    }

    public override void Awake()
    {
      base.Awake();

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
        
        if (!other.CompareTag ("Untagged"))
        {
          Logger.Log (
            $"Player has hit {other.attachedRigidbody.tag} - {other.attachedRigidbody.name}", 
            other.attachedRigidbody
          );
        }

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
        else if (other.CompareTag (GameGlobals.Instance.registry.coinTag))
        {
          other.gameObject.SetActive (false);
          coinSound.Play ();
          GameGlobals.Instance.registry.score += 1;
          Logger.Log (
            $"Add score: {other.name}",
            other
          ); 
        }
      }
    }

    void HideBump ()
    {
      bump.gameObject.SetActive (false);
    }
  }
}
