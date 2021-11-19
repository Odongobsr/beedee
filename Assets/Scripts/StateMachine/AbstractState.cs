using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bee
{
  [CreateAssetMenu (
    fileName = "State",
    menuName = "State"
  )]
  public class AbstractState : AbstractScriptableObject
  {
    public State state;
    public float introTime;
    public float exitTime;
    protected StateMachine stateMachine;

    public virtual void Initialise (List<StateListener> listeners) 
    {
      for (int l = 0; l < listeners.Count; l++)
      {
        listeners [l].Initialise ();
      }
    }
    public virtual void Setup (List<StateListener> listeners) 
    {
      for (int l = 0; l < listeners.Count; l++)
      {
        listeners [l].Setup ();
      }
    }
    
    public virtual void Pause (List<StateListener> listeners) 
    {
      for (int l = 0; l < listeners.Count; l++)
      {
        listeners [l].Pause ();
      }
    }
    
    public virtual void UnPause (List<StateListener> listeners) 
    {
      for (int l = 0; l < listeners.Count; l++)
      {
        listeners [l].UnPause ();
      }
    }

    public virtual void Enter (List<StateListener> listeners) 
    {
      for (int l = 0; l < listeners.Count; l++)
      {
        listeners [l].Enter ();
      }
    }

    public virtual void Exit (List<StateListener> listeners) 
    {
      for (int l = 0; l < listeners.Count; l++)
      {
        listeners [l].Exit ();
      }
    }
    public virtual void MyUpdate (List<StateListener> listeners) 
    {
      for (int l = 0; l < listeners.Count; l++)
      {
        listeners [l].MyUpdate ();
      }
    }
    public virtual void MyFixedUpdate (List<StateListener> listeners) 
    {
      for (int l = 0; l < listeners.Count; l++)
      {
        listeners [l].MyFixedUpdate ();
      }
    }
    public virtual void MyLateUpdate (List<StateListener> listeners) 
    {
      for (int l = 0; l < listeners.Count; l++)
      {
        listeners [l].MyLateUpdate ();
      }
    }
  }
}
