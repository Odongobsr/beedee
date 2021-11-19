using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Bee
{
  public class PauseStateMachine : StateListener
  {
#region public functions
    public override void Awake ()
    {
      base.Awake ();

      List<State> activeStates = new List<State> ();
      activeStates.AddUnique (State.Gameplay);
      SetActiveStates (activeStates);
    }

    /// <summary>
    /// It needs to listen to Unit's LateUpdate call otherwise it'll get paused with the rest of the state listeners
    /// </summary>
    void LateUpdate ()
    {
      if (Input.GetKeyDown (KeyCode.P))
      {
        GameGlobals.Instance.stateMachine.TogglePause ();
      }
    }
#endregion
  }
}
