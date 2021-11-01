using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class GameController : MonoBehaviour
{
  public bool gameStarted;

  [Header ("References")]
  public ObstacleManager obstacleManager;
  public FlowerManager flowerManager;

  void Awake()
  {
    Assert.IsNotNull (obstacleManager);    
    Assert.IsNotNull (flowerManager);    
    GameGlobals.Instance.gameController = this;
  }

  public void Start ()
  {
    StartCoroutine (StartGameCoroutine ());
  }

  void OnEnable ()
  {
    Logger.LogDivider ();
    Logger.Log ("Enable game controller");
  }

  IEnumerator StartGameCoroutine ()
  {
    GameGlobals.Instance.registry.UnPause ();
    gameStarted = true;
    flowerManager.Activate ();
    obstacleManager.Activate ();

    int introTime = GameGlobals.Instance.registry.introTime;

    Logger.Log ($"Start game in {introTime} seconds");

    yield return new WaitForSeconds (introTime);

    Logger.Log ("Start game");

    obstacleManager.StartSpawningObstacles ();
  }
}
