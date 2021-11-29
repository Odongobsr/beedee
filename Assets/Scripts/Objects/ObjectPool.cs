using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Bee
{
  [System.Serializable]
  public class ObjectPool : AbstractGameComponent
  {
    public List<BlockCollection> blockCollections;
    public Transform holder;
    public List<AbstractPoolable> inactiveObjects; // = new Stack<GameObject> ();  
    public List<AbstractPoolable> activeObjects; // = new Stack<GameObject> ();  

    public override void CheckAssertions()
    {
      base.CheckAssertions();

      Assert.IsNotNull (holder);
    }

    public void CreateObjects ()
    {
      if (null == holder)
      {
        Logger.LogWarning ("Object holder is null!", this);
        return;
      }

      for (int k = 0; k < blockCollections.Count; k++)
      {
        BlockCollection blockCollection = blockCollections [k];
        int count = blockCollection.count;

        for (int i = 0; i < blockCollection.blocks.Count; i++)
        {
          for (int j = 0; j < count; j++)
          {
            if (null == blockCollection.blocks [i])
            {
              Logger.LogWarning ($"Object is null at index {i}");
              continue;
            }

            AbstractPoolable obj = Instantiate (
              original: blockCollection.blocks [i].prefab,
              position: Vector3.zero,
              rotation: blockCollection.blocks [i].prefab.transform.rotation,
              parent:holder
            );
          
            obj.data = blockCollection.blocks [i];

            string name = blockCollection.blocks [i].name;

            obj.name = $"{name}_{j}";
            obj.pool = this;

            obj.gameObject.SetActive (false);
          }
        }
      }
    }

    public AbstractPoolable GetInactiveObject (DataObject data)
    {
      if (inactiveObjects.Count > 0)
      {
        return inactiveObjects.Find (x => x.data == data);
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
      // Logger.Log ($"Enable object {obj}", obj);
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
      // Logger.Log ($"Disable object {obj}", obj);
    }
  }
}