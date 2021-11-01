using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerSpawner : MonoBehaviour
{
  void OnEnable()
  {
    if (FlowerManager.stepCount == 0)
    {
      return;
    }

    int modulo = FlowerManager.stepCount % GameGlobals.Instance.registry.flowerInterval;
    // Logger.Log ($"Module: {modulo}", gameObject);
    if (modulo == 0)
    {
      AbstractPoolable flower = GameGlobals.Instance.gameController.flowerManager.objectSpawner.SpawnObject (transform);
    }
  }
}
