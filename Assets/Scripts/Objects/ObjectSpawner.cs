using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class ObjectSpawner : AbstractGameComponent
{
  [Header ("Configuration")]
  /// <summary>
  /// How long to wait before spawning another object?
  /// </summary>
  public FloatVariable waitTime;


  [Header ("References")]
  public ObjectPool objectPool;

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

  void SpawnObject ()
  {
    if (objectPool.inactiveObjects.Count == 0)
    {
      Logger.LogWarning ($"No inactive objects in pool {objectPool} !", this);
      return;
    }

    AbstractPoolable obj = objectPool.GetInactiveObject (random: true);

    if (null == obj)
    {
      Logger.LogWarning ("Object is null!", this);
      return;
    }
    
    // activate obstacle
    obj.gameObject.SetActive (true);

    // Logger.Log ($"Spawn object {obj.name}", obj);
  }
}
