using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Bee
{
  public class ObjectSpawner : AbstractGameComponent
  {
    [Header ("Configuration")]
    /// <summary>
    /// How long to wait before spawning another object?
    /// </summary>
    public FloatVariable waitTime;


    [Header ("References")]
    public ObjectPool objectPool;

    public delegate void OnSpawnObject();
    public OnSpawnObject onSpawnObject;

    [Header ("Runtime Only")]
    public List<AbstractPoolable> objects;

    void Awake ()
    {
      Assert.IsNotNull (objectPool);
    }

    public void StartSpawningObjects (FloatVariable wait)
    {
      waitTime = wait;
      StartCoroutine (SpawnObjectCoroutine ());
    }

    IEnumerator SpawnObjectCoroutine ()
    {
      Logger.Log ("Start spawning objects", this);

      while (true)
      {
        SpawnObject ();

        yield return new WaitForSeconds (waitTime.value);
      }
    }

    public AbstractPoolable SpawnObject (Transform parent = null)
    {
      if (GameGlobals.Instance.registry.paused)
      {
        return null;
      }
      
      if (objectPool.inactiveObjects.Count == 0)
      {
        Logger.LogWarning ($"No inactive objects in pool {objectPool} !", this);
        return null;
      }

      AbstractPoolable obj = objectPool.GetInactiveObject (random: true);

      if (null == obj)
      {
        Logger.LogWarning ("Object is null!", this);
        return null;
      }
      
      // activate obstacle
      if (null != parent)
      {
        // obj.transform.parent = parent;
        obj.transform.position = parent.position;
      }
      obj.gameObject.SetActive (true);
      onSpawnObject?.Invoke ();

      objects.Add (obj);

      // Logger.Log ($"Spawn object {obj.name}", obj);
      return obj;
    }
  }
}
