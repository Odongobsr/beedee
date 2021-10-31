using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Block
{
  public bool alive;
  public static Action onPlayerDeath;

  public InputHandler inputHandler;

  void Start()
  {
    alive = true;
    Logger.Log ($"{name} is alive!", this);
  }

  public void Die ()
  {
    if (alive)
    {
      Logger.Log ($"{name} has died!", this);
      alive = false;
      onPlayerDeath?.Invoke ();
    }
    else
    {
      Logger.LogWarning ($"{name} is already dead!", this);
    }
  }
}
