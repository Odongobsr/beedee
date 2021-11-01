using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractVelocityModifier : MonoBehaviour
{
  public virtual Vector2 ModifyVelocity (Block block)
  {
    return new Vector3 ();
  } 
}
