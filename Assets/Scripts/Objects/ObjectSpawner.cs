using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Bee
{
  public class ObjectSpawner : AbstractGameComponent
  {
    [Header ("Configuration")]
    /// <summary>
    /// How long to wait before spawning another object?
    /// </summary>
    public FloatVariable waitTime;
    public ObjectPattern objectPattern;


    [Header ("References")]
    public ObjectPatternGenerator objectPatternGenerator;
    public ObjectPool objectPool;

    public delegate void OnSpawnObject();
    public OnSpawnObject onSpawnObject;

    [Header ("Runtime Only")]
    // public List<AbstractPoolable> objects;
    /// <summary>
    /// Index of current object pattern
    /// </summary>
    public int patternIndex;
    /// <summary>
    /// How many objects in current pattern?
    /// </summary>
    public int patternCount;

    public override void CheckAssertions ()
    {
      base.CheckAssertions ();

      Assert.IsNotNull (objectPool);
      Assert.IsNotNull (objectPatternGenerator);
    }

    [ContextMenu ("Regenerate Pattern")]
    void RegeneratePattern ()
    {
      objectPattern = objectPatternGenerator.GeneratePattern ();
      patternIndex = 0;
      // Logger.Log (
      //   $"Regenerate pattern: {objectPattern.objects.Count}",
      //   this
      // );
    }

    public AbstractPoolable SpawnObject (Transform parent = null)
    {
      if (objectPool.inactiveObjects.Count == 0)
      {
        Logger.LogWarning ($"No inactive objects in pool {objectPool} !", this);
        return null;
      }

      if (patternIndex >= objectPattern.objects.Count)
      {
        RegeneratePattern ();
      }
      
      AbstractPoolable obj = objectPool.GetInactiveObject (objectPattern.objects [patternIndex]);

      if (null == obj)
      {
        Logger.LogWarning (
          $"Object is null - {objectPattern.objects [patternIndex].name.Important ()}", 
          this
        );
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

      // objects.Add (obj);

      Logger.Log ($"Spawn object {obj.name}", obj);

      patternIndex++;

      return obj;
    }
  }
}
