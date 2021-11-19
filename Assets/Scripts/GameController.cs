using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Bee
{
  public class GameController : StateListener
  {
    public bool gameStarted;

    [Header ("References")]
    public ObstacleManager obstacleManager;
    public FlowerManager flowerManager;

    public override void Awake()
    {
      base.Awake ();

      Assert.IsNotNull (obstacleManager);    
      Assert.IsNotNull (flowerManager);    
      GameGlobals.Instance.gameController = this;
    }

    public override bool Enter ()
    {
      if (!base.Enter ()) return false;

      StartCoroutine (StartGameCoroutine ());

      return true;
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
}
