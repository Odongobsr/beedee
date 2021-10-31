using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractScriptableObject : ScriptableObject
{
  public AbstractScriptableObject me;

  public virtual void OnValidate()
  {
    if (null == me)
    {
      me = this;    
    }
  }
}
