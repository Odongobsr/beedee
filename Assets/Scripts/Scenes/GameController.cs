using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Bee
{
  public class GameController : SceneController
  {
    public bool gameStarted;

    [Header ("References")]
    public ObstacleManager obstacleManager;
    public FlowerManager flowerManager;
    public Event_SwitchScene switchToMainMenu;

    public override void Awake()
    {
      base.Awake ();

      GameGlobals.Instance.gameController = this;
    }


    public override void CheckAssertions ()
    {
      base.CheckAssertions ();

      Assert.IsNotNull (obstacleManager);    
      Assert.IsNotNull (flowerManager);    
      Assert.IsNotNull (switchToMainMenu);     
    }
    
    public override bool Activate ()
    {
      if (!base.Activate ()) return false;

      GameGlobals.Instance.playerButtonsUIScreen.Deactivate (0);
      StartCoroutine (StartGameCoroutine ());

      return true;
    }


    public override void MyUpdate()
    {
      base.MyUpdate();

      if (Input.GetKeyDown (KeyCode.Escape))
      {
        switchToMainMenu.RunEvent (this);
      }
    }

    public override void OnEnable()
    {
      base.OnEnable();

      // Logger.LogDivider ();
      // Logger.Log ("Enable game controller");
    }

    IEnumerator StartGameCoroutine ()
    {
      GameGlobals.Instance.playerButtonsUIScreen.Activate ();

      // GameGlobals.Instance.registry.UnPause ();
      gameStarted = true;
      // flowerManager.Activate ();
      // obstacleManager.Activate ();

      int introTime = GameGlobals.Instance.registry.introTime;

      Logger.Log ($"Start game in {introTime} seconds");

      yield return new WaitForSeconds (introTime);

      Logger.Log ("Start game");

      obstacleManager.StartSpawningObstacles ();
    }
  }
}
