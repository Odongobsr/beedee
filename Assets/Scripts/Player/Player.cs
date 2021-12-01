using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bee
{
  public class Player : Block
  {
    public bool alive;
    public static Action onPlayerDeath;
    public static Action onPlayerWin;

    public InputHandler inputHandler;
    
    /// <summary>
    /// Shown when player collides with an obstacle
    /// </summary>
    public GameObject bump;

    public override void Awake ()
    {
      base.Awake ();
      
      GameGlobals.Instance.player = this;
    }
    
    public override void Start()
    {
      base.Start ();

      // GameGlobals.Instance.audioManager.beeSound.Play ();
      GameGlobals.Instance.audioManager.PlayMusic (
        _clip: GameGlobals.Instance.registry.audioRegistry.music_bee
      );
      HideBump ();
      
      // Logger.Log ($"{name} is alive!", this);
    }

    public override void MyUpdate()
    {
      base.MyUpdate();

      if (GameGlobals.Instance.registry.worldState != WorldState.Complete)
      {
        return;
      }

      GameGlobals.Instance.registry.playerHealth.value -=  
        Time.deltaTime / GameGlobals.Instance.registry.playerHealthTime;

      if (GameGlobals.Instance.registry.playerHealth.value <= 0)
      {
        Logger.Log (
          $"Player has run out of energy",
          this
        );
        Die ();
      }
    }

    public void Die ()
    {
      if (alive)
      {
        onPlayerDeath?.Invoke ();
      }
      else
      {
        Logger.LogWarning ($"{name} is already dead!", this);
      }
    }

    internal void HitObstacle(Collider2D other)
    {
      other.enabled = false;
      // GameGlobals.Instance.audioManager.obstacleSound.Play ();
      GameGlobals.Instance.audioManager.PlayFX (
        _clip: GameGlobals.Instance.registry.audioRegistry.fx_obstacle
      );
      GameGlobals.Instance.audioManager.PlayFX (
        _clip: GameGlobals.Instance.registry.audioRegistry.fx_gameover
      );

      // shake camera
      GameGlobals.Instance.mainCamera.shakeTransform.Shake (
        _shakeX: true,
        _shakeY: true,
        _strength: 1
      );

      bump.gameObject.SetActive (true);
      bump.transform.position = transform.position;
      Invoke ("HideBump", 0.2f);
      
      Die ();
      // throw new NotImplementedException();
    }

    void HideBump ()
    {
      bump.gameObject.SetActive (false);
    }
  }
}
