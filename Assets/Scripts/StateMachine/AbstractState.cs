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
      
      Logger.Log(
        _str: $"Initialise state {state}", 
        _context: this,
        _color: Color.magenta.ToString ()
      );
    }
    public virtual void Setup (List<StateListener> listeners) 
    {
      for (int l = 0; l < listeners.Count; l++)
      {
        listeners [l].Setup ();
      }

      Logger.Log(
        _str: $"Setup state {state}", 
        _context: this,
        _color: Color.magenta.ToString ()
      );
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
      Logger.Log(
        _str: $"Enter state {state}", 
        _context: this,
        _color: Color.magenta.ToString ()
      );
    }

    public virtual void Exit (List<StateListener> listeners) 
    {
      for (int l = 0; l < listeners.Count; l++)
      {
        listeners [l].Exit ();
      }  
      Logger.Log(
        _str: $"Exit state {state}", 
        _context: this,
        _color: "red"
      );
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
