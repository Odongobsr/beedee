using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Bee
{
  [System.Serializable]
  public class StateListener : AbstractGameComponent
  {
    [Header ("State")]
    public bool isSetup;
    // public bool isSetup;
    public bool isActive;

    public List<State> activeStates;
    public List<StateListener> listeners;

    /// <summary>
    /// if state listener needs to set isSetup state it should do so here
    /// </summary>
    public override void Awake ()
    {
      base.Awake ();

      if (null != transform.parent)
      {
        StateListener parentListener = transform.parent.GetComponent<StateListener> ();

        if (null != parentListener)
        {
          // register with parent state listener
          parentListener.listeners.AddUnique (this);
          // Logger.Log ($"Add {name} to parent state listener", this);
        }
      }
    }

    public override void Start ()
    {
      base.Start ();

      if (null == transform.parent || null == transform.parent.GetComponent<StateListener> ())
      {
      // if (GameGlobals.Instance.stateMachine.active)
      // {
        // register with state machine directly
        for (int s = 0; s < activeStates.Count; s++)
        {
          GameGlobals.Instance.stateMachine.AddListener (listener: this, state: activeStates[s]);
          // Logger.Log ($"Add {name} to state {activeStates[s]}", this);
        } 
      // }

        switch (GameGlobals.Instance.registry.worldState)
        {
          case WorldState.SettingUp:
            Setup ();
            // Initialise ();
            break;

          case WorldState.Complete:
          case WorldState.Retired:
            Setup ();
            // Initialise ();
            // enter if game world is already set up
            Enter ();
            break;
        }
      }
    }

    public override void OnDestroy()
    {
      base.OnDestroy ();

      for (int s = 0; s < activeStates.Count; s++)
      {
        GameGlobals.Instance.stateMachine.RemoveListener (listener: this, state: activeStates[s]);
        // Logger.Log ($"Add {name} to state {activeStates[s]}", this);
      } 
    }

    public virtual void SetActiveStates (List<State> states)
    {
      activeStates = states;
    }
    
    /// <summary>
    /// Equivalent to Unity's awake function
    /// </summary>
    public virtual bool Setup ()
    {
      if (isSetup)
      {
        // Logger.Log ($"{name} is already setup", this);
        return false;
      }

      isSetup = true;

      // Logger.Log ($"Setup {name}", this);
      for (int a = 0; a < listeners.Count; a++)
      {
        listeners [a].SetActiveStates (activeStates);
        listeners [a].Setup ();
      }

      return true;
    }

    // public virtual bool Initialise ()
    // {
    //   if (isSetup)
    //   {
    //     // Logger.Log ($"{name} is already initialised", this);
    //     return false;
    //   }
      
    //   isSetup = true;

    //   // Logger.Log ($"Initialise {name}", this);
    //   // initalise listeners
    //   for (int a = 0; a < listeners.Count; a++)
    //   {
    //     listeners [a].Initialise ();
    //   }

    //   return true;
    // }
    
    public virtual void Pause ()
    {
      // initalise listeners
      for (int a = 0; a < listeners.Count; a++)
      {
        listeners [a].Pause ();
      }
    }
    
    public virtual void UnPause ()
    {
      // initalise listeners
      for (int a = 0; a < listeners.Count; a++)
      {
        listeners [a].UnPause ();
      }
    }

    public virtual void MyReset()
    {
      // reset listeners
      for (int a = 0; a < listeners.Count; a++)
      {
        listeners [a].MyReset ();
      } 
    }

    public virtual bool Enter ()
    {
      if (isActive)
      {
        return false;
      }
      
      if (!activeStates.Contains (GameGlobals.Instance.stateMachine.currentState.state))
      {
        string currentState = GameGlobals.Instance.stateMachine.currentState.state.ToString ().Important ();

        Logger.LogList (
          _title: $"{name.Important ()} - tate machine is not in active state: {currentState}",
          _message: $"Active states: {activeStates.PrintMe ()}",
          this
        );
        return false;
      }

      isActive = true;
      
      // initalise listeners
      for (int a = 0; a < listeners.Count; a++)
      {
        listeners [a].Enter ();
      }

      return true;
    }

    public virtual void Exit ()
    {
      isActive = false;
      isSetup = false;
      isSetup = false;
      
      // initalise listeners
      for (int a = 0; a < listeners.Count; a++)
      {
        listeners [a].Exit ();
      }
    }

    public virtual void MyUpdate ()
    {
      if (!isSetup)
      {
        return;
      }
      for (int a = 0; a < listeners.Count; a++)
      {
        listeners [a].MyUpdate ();
      }
    }
    
    public virtual void MyFixedUpdate ()
    {
      if (!isSetup)
      {
        return;
      }
      for (int a = 0; a < listeners.Count; a++)
      {
        listeners [a].MyFixedUpdate ();
      }
    }
    
    public virtual void MyLateUpdate()
    {
      if (!isSetup)
      {
        return;
      }
      for (int a = 0; a < listeners.Count; a++)
      {
        listeners [a].MyLateUpdate ();
      }
    }

    public virtual void MyOnTriggerEnter2D (Collider2D other)
    {
      if (!isSetup)
      {
        return;
      }
      for (int a = 0; a < listeners.Count; a++)
      {
        listeners [a].MyOnTriggerEnter2D (other);
      }
    }

    public virtual void MyOnTriggerExit2D(Collider2D other) 
    {
      if (!isSetup)
      {
        return;
      }
      for (int a = 0; a < listeners.Count; a++)
      {
        listeners [a].MyOnTriggerExit2D (other);
      }
    }

    public virtual void MyOnCollisionEnter2D (Collision2D collision)
    {
      if (!isSetup)
      {
        return;
      }
      for (int a = 0; a < listeners.Count; a++)
      {
        listeners [a].MyOnCollisionEnter2D (collision);
      }
    }

    public virtual void MyOnCollisionExit2D(Collision2D collision) 
    {
      if (!isSetup)
      {
        return;
      }
      for (int a = 0; a < listeners.Count; a++)
      {
        listeners [a].MyOnCollisionExit2D (collision);
      }
    }
  }
}
