using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public abstract class AbstractScriptableObject : ScriptableObject
{
  public AbstractScriptableObject me;

  public virtual void Setup ()
  {
    
  }

  public virtual void CheckAssertions ()
  {

  }

  public virtual void OnValidate()
  {
    if (null == me)
    {
      me = this;    
    }
  }
}
