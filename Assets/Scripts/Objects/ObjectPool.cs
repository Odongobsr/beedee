using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectPool : AbstractGameComponent
{
  public Transform holder;
  public List<AbstractPoolable> inactiveObjects; // = new Stack<GameObject> ();  
  public List<AbstractPoolable> activeObjects; // = new Stack<GameObject> ();  

  public void CreateObjects (List<AbstractPoolable> objects, int count)
  {
    if (null == holder)
    {
      Logger.LogWarning ("Object holder is null!", this);
      return;
    }

    for (int i = 0; i < objects.Count; i++)
    {
      for (int j = 0; j < count; j++)
      {
        if (null == objects [i])
        {
          Logger.LogWarning ($"Object is null at index {i}");
          continue;
        }

        AbstractPoolable obj = Instantiate (
          original: objects [i],
          position: Vector3.zero,
          rotation: Quaternion.identity,
          parent:holder 
        );

        obj.name = $"{objects [i].name}_{j}";
        obj.pool = this;

        obj.gameObject.SetActive (false);

        // OnDisableObject (obj);
      }
    }
  }

  public AbstractPoolable GetInactiveObject ()
  {
    if (inactiveObjects.Count > 0)
    {
      return inactiveObjects [0];
    }
    else
    {
      return null;
    }
  }

  /// <summary>
  /// Called when one of this pool's objects is enabled
  /// </summary>
  public void OnEnableObject (AbstractPoolable obj)
  {
    // remove from inactive object pool
    if (inactiveObjects.Contains (obj))
    {
      inactiveObjects.Remove (obj);
    }
    // add to active object pool
    if (!activeObjects.Contains (obj))
    {
      activeObjects.Add (obj);
    }
    Logger.Log ($"Enable object {obj}", obj);
  }

  /// <summary>
  /// Called when one of this pool's objects is disabled
  /// </summary>
  public void OnDisableObject (AbstractPoolable obj)
  {
    // remove from active object pool
    if (activeObjects.Contains (obj))
    {
      activeObjects.Remove (obj);
    }
    // add to inactive object pool
    if (!inactiveObjects.Contains (obj))
    {
      inactiveObjects.Add (obj);
    }
    Logger.Log ($"Disable object {obj}", obj);
  }
}
