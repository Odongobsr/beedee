using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class GameController : MonoBehaviour
{
  [Header ("References")]
  public ObstacleManager obstacleManager;

  void Awake()
  {
    Assert.IsNotNull (obstacleManager);    
  }

  void Start ()
  {
    StartCoroutine (StartGameCoroutine ());
  }

  IEnumerator StartGameCoroutine ()
  {
    obstacleManager.Activate ();

    int introTime = GameGlobals.Instance.registry.introTime;

    Logger.Log ($"Start game in {introTime} seconds");

    yield return new WaitForSeconds (introTime);

    Logger.Log ("Start game");

    obstacleManager.StartSpawningObstacles ();
  }
}
