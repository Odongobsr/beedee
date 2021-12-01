using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

namespace Bee
{
  public class GameController : SceneController
  {
    [Header ("Configuration")]
    public float globalYPosition;
    public float flowersPollinated;

    [Header ("References")]
    public ObstacleManager obstacleManager;
    public FlowerManager flowerManager;
    public CoinManager coinManager;
    public Event_SwitchScene switchToMainMenu;

    public override void Awake()
    {
      base.Awake ();

      GameGlobals.Instance.gameController = this;

      // GameGlobals.Instance.fadeScreen.Deactivate (); // fade out
    }

    public override void Start ()
    {
      base.Start ();
      
      GameGlobals.Instance.audioManager.PlayMusic (
        _clip: GameGlobals.Instance.registry.audioRegistry.music_game
      );
    }


    public override void CheckAssertions ()
    {
      base.CheckAssertions ();

      Assert.IsNotNull (obstacleManager);    
      Assert.IsNotNull (flowerManager);    
      Assert.IsNotNull (coinManager);    
      Assert.IsNotNull (switchToMainMenu);     
    }
    
    public override void Activate ()
    {
      base.Activate ();

      StartCoroutine (StartGameCoroutine ());
    }


    public override void MyUpdate()
    {
      base.MyUpdate();

      if (Input.GetKeyDown (KeyCode.Escape))
      {
        GameGlobals.Instance.registry.sceneLoader.LoadMainMenuScene ();
        // switchToMainMenu.RunEvent (this);
      }
    }

    public override void MyFixedUpdate ()
    {
      base.MyFixedUpdate ();

      if (GameGlobals.Instance.player.alive)
      {
        globalYPosition += GameGlobals.Instance.registry.globalSpeedMultiplier * Time.fixedDeltaTime;
      }
    }

    public override void OnEnable()
    {
      base.OnEnable();
      
      Player.onPlayerDeath += PlayerHasDied;
    }

    public override void OnDisable ()
    {
      base.OnDisable ();

      Player.onPlayerDeath -= PlayerHasDied;
    }

    IEnumerator StartGameCoroutine ()
    {
      GameGlobals.Instance.playerButtonsUIScreen.Activate ();
      GameGlobals.Instance.statsScreen.Activate ();
      GameGlobals.Instance.getReadyScreen.Deactivate ();

      // reset variables
      GameGlobals.Instance.registry.score = 0;
      GameGlobals.Instance.registry.playerHealth.value = 1.2f;
      GameGlobals.Instance.registry.globalSpeedMultiplier = 
        GameGlobals.Instance.registry.minSpeedMultiplier;

      yield return new WaitForEndOfFrame ();

      // int introTime = GameGlobals.Instance.registry.introTime;

      // Logger.Log ($"Start game in {introTime} seconds");

      // yield return new WaitForSeconds (introTime);

      GameGlobals.Instance.player.alive = true;

      Logger.Log ("Start game");

      obstacleManager.StartSpawningObstacles ();
    }

    public void PlayerHasDied ()
    {
      StartCoroutine (DieCoroutine ());
    }

    IEnumerator DieCoroutine ()
    {
      if (GameGlobals.Instance.registry.worldState != WorldState.Complete)
      {
        yield return null;
      }

      GameGlobals.Instance.stateMachine.Pause ();

      GameGlobals.Instance.registry.SetWorldState (WorldState.Retired);

      FlowerManager.stepCount = 0;
      // globalYPosition = 0;

      Logger.Log ($"{GameGlobals.Instance.player.name.Important ()} has died!", this);
      GameGlobals.Instance.player.alive = false;
      
      GameGlobals.Instance.playerButtonsUIScreen.Deactivate ();
      GameGlobals.Instance.statsScreen.Deactivate ();

      GameGlobals.Instance.audioManager.StopMusic (
        _clip: GameGlobals.Instance.registry.audioRegistry.music_game
      );

      GameGlobals.Instance.audioManager.StopMusic (
        _clip: GameGlobals.Instance.registry.audioRegistry.music_bee
      );

      yield return new WaitForSeconds (GameGlobals.Instance.registry.deathTimeout);

      GameGlobals.Instance.gameOverScreen.Activate ();
    }
  }
}
