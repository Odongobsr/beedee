using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bee
{
  public class Flower : Block
  {
    public bool alive;

    public override void Start()
    {
      base.Start ();
      
      alive = true;
      // Logger.Log ($"{name} is alive!", this);
    }

    public void Die ()
    {
      if (alive)
      {
        Logger.Log ($"{name} has died!", this);
        alive = false;
      }
      else
      {
        Logger.LogWarning ($"{name} is already dead!", this);
      }
    }
  }
}
