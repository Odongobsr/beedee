using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractPoolable : MonoBehaviour
{
  public DataObject data;
  
  /// <summary>
  /// What pool does this object belong to?
  /// </summary>
  public ObjectPool pool;

  void OnEnable ()
  {
    if (pool)
    {
      // return to active objects of pool when enabled
      pool.OnEnableObject (this);
    }
  }

  void OnDisable ()
  {
    if (pool)
    {
      // return to inactive objects of pool when disabled
      pool.OnDisableObject (this);
    }
  }
}
