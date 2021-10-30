using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractGameComponent : MonoBehaviour
{
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
