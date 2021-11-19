using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bee
{
  public abstract class AbstractVelocityModifier : StateListener
  {
    public virtual Vector2 ModifyVelocity (Block block)
    {
      return new Vector3 ();
    } 
  }
}