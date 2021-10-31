using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractGameObject : MonoBehaviour
{
  public List<AbstractGameComponent> components;
  
  public bool active;

  public virtual void Activate ()
  {
    active = true;
  }
  public virtual void Deactivate ()
  {
    active = false;
  }
}
