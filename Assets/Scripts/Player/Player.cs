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

    public InputHandler inputHandler;

    public override void Awake ()
    {
      base.Awake ();
      
      GameGlobals.Instance.player = this;
    }
    
    public override void Start()
    {
      base.Start ();

      alive = true;
      Logger.Log ($"{name} is alive!", this);
    }

    public void Die ()
    {
      if (alive)
      {
        StartCoroutine (DieCoroutine ());
      }
      else
      {
        Logger.LogWarning ($"{name} is already dead!", this);
      }
    }

    IEnumerator DieCoroutine ()
    {
      GameGlobals.Instance.registry.Pause ();

      Logger.Log ($"{name} has died!", this);
      alive = false;

      yield return new WaitForSeconds (GameGlobals.Instance.registry.deathTimeout);

      onPlayerDeath?.Invoke ();
    }
  }
}
