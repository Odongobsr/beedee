using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Bee
{
  /// <summary>
  /// Sets initial state of statemachine when a new scene is entered
  /// </summary>
  public class ResetStateMachine : MonoBehaviour
  {
    public Scene scene;
    public State initialState;

    void Start ()
    {
      Logger.LogDivider ();

      Logger.Log (
        $"Reset state machine to {initialState.ToString ().Important ()}",
        this
      );
      GameGlobals.Instance.stateMachine.ChangeState (initialState);
    }
  }
}