using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bee
{
  public abstract class AbstractPoolable : StateListener
  {
    public DataObject data;
    
    /// <summary>
    /// What pool does this object belong to?
    /// </summary>
    public ObjectPool pool;

    public override void OnEnable ()
    {
      base.OnEnable ();

      if (pool)
      {
        // return to active objects of pool when enabled
        pool.OnEnableObject (this);
      }
    }

    public override void OnDisable ()
    {
      base.OnDisable ();
      
      if (pool)
      {
        // return to inactive objects of pool when disabled
        pool.OnDisableObject (this);
      }
    }
  }
}