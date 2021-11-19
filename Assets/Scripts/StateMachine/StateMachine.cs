using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bee
{
  public class StateMachine : MonoBehaviour
  {
    public bool active;
    public bool paused;
    Dictionary<State, List<StateListener>> listenerDict = new Dictionary<State, List<StateListener>> ();
    public AbstractState currentState;
    // public List<AbstractState> states = new List<AbstractState> ();

    public void AddListener (StateListener listener, State state)
    {
      if (listenerDict.ContainsKey (state))
      {
        listenerDict [state].AddUnique (item: listener);
      }
      else
      {
        listenerDict.Add (key: state, value: new List<StateListener> ());
        listenerDict [state].AddUnique (item: listener);
        Logger.Log ($"Add state listener key - {state}", null);
      }
      Logger.Log ($"Add state listener to {state} - {listener.name}", listener);
    }

    public void RemoveListener (StateListener listener, State state)
    {
      if (listenerDict.ContainsKey (state))
      {
        if (listenerDict [state].Contains (item: listener))
        {
          listenerDict [state].Remove (item: listener);
          Logger.Log ($"Remove state listener from {state} - {listener.name}", listener);
        }
      }
    }

    void Awake()
    {
      GameGlobals.Instance.stateMachine = this;
      active = true;

      GameGlobals.Instance.registry.worldState = WorldState.Null;

      for (int i = 0; i < GameGlobals.Instance.registry.states.Count; i++)
      {
        State state = GameGlobals.Instance.registry.states [i].state;
        listenerDict.Add (key: state, value: new List<StateListener> ());
        Logger.Log ($"Add state listener key - {state}", null);
      }
    }

    void Start ()
    {
      // states = GameGlobals.Instance.registry.states;
      // currentState = GetInitialState();

      StartCoroutine (ChangeStateCoroutine (GetInitialState().state));
    }

    void Setup()
    {
      if (currentState != null && listenerDict.ContainsKey (currentState.state))
      {
        Logger.Log($"Setup {currentState.state}", currentState);
        currentState.Setup(listeners: listenerDict [currentState.state]);
      }
    }

    void Initialise()
    {
      if (currentState != null && listenerDict.ContainsKey (currentState.state))
      {
        Logger.Log($"Initialise {currentState.state}", currentState);
        currentState.Initialise(listeners: listenerDict [currentState.state]);
      }
    }

    void Enter ()
    {
      if (currentState != null && listenerDict.ContainsKey (currentState.state))
      {
        Logger.Log($"Enter {currentState.state}", currentState);
        currentState.Enter(listeners: listenerDict [currentState.state]);
      }
    }

    private void Update()
    {
      if (paused)
      {
        // Logger.Log ($"Game is paused! {currentState.state}");
        return;
      }
      if (active && currentState != null && listenerDict.ContainsKey (currentState.state))
      {
        currentState.MyUpdate(listeners: listenerDict [currentState.state]);
        // Logger.Log($"Update {currentState.state}", currentState);
      }
    }

    private void FixedUpdate()
    {
      if (paused)
      {
        // Logger.Log ($"Game is paused! {currentState.state}");
        return;
      }
      if (active && currentState != null && listenerDict.ContainsKey (currentState.state))
      {
        currentState.MyFixedUpdate(listeners: listenerDict [currentState.state]);
        // Logger.Log($"FixedUpdate {currentState.state}", currentState);
      }
    }

    private void LateUpdate()
    {
      if (paused)
      {
        // Logger.Log ($"Game is paused! {currentState.state}");
        return;
      }
      if (active && currentState != null && listenerDict.ContainsKey (currentState.state))
      {
        currentState.MyLateUpdate(listeners: listenerDict [currentState.state]);
        // Logger.Log($"LateUpdate {currentState.state}", currentState);
      }
    }

    public IEnumerator ChangeStateCoroutine (State newState)
    {
      if (!listenerDict.ContainsKey (newState)) // check if newState in keys
      {
        Logger.LogWarningList (
          _title: $"{newState} not found in list of states",
          _message: listenerDict.PrintKeys (),
          this
        );
        yield return null;
      }

      if (currentState)
      {
        currentState.Exit(listeners: listenerDict [currentState.state]);
        yield return new WaitForSeconds (currentState.exitTime);
        GameGlobals.Instance.registry.SetWorldState (WorldState.Retired);
      }

      GameGlobals.Instance.registry.SetWorldState (WorldState.SettingUp);

      currentState = GetState (newState);

      yield return new WaitForSeconds (currentState.introTime / 2);

      currentState.Setup(listeners: listenerDict [currentState.state]);
      Logger.Log($"Setup state {currentState.state}", currentState);

      yield return new WaitForEndOfFrame ();
      
      currentState.Initialise(listeners: listenerDict [currentState.state]);
      Logger.Log($"Initialise state {currentState.state}", currentState);

      yield return new WaitForSeconds (currentState.introTime / 2);

      GameGlobals.Instance.registry.SetWorldState (WorldState.Complete);

      currentState.Enter(listeners: listenerDict [currentState.state]);
      Logger.Log($"Enter state {currentState.state}", currentState);
    }

    public AbstractState GetState (State state)
    {
      return GameGlobals.Instance.registry.GetState (state);
    }

    private AbstractState GetInitialState()
    {
      return GameGlobals.Instance.registry.GetState (GameGlobals.Instance.registry.initialState);
    }

    public void TogglePause ()
    {
      if (!active)
      {
        Logger.LogWarning ("State machine is not yet active!");
        return;
      }
      paused = !paused;

      if (paused)
      {
        currentState.Pause(listeners: listenerDict [currentState.state]);
      }
      else
      {
        currentState.UnPause(listeners: listenerDict [currentState.state]);   
      }
    }

    private void OnGUI()
    {
        string content = currentState != null ? currentState.name : "(no current state)";
        content += $"\nWorld state: {GameGlobals.Instance.registry.worldState}";

        GUILayout.Label($"<color='white'><size=40>{content}</size></color>");
    }
  }
}
