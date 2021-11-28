using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public abstract class AbstractGameComponent : MonoBehaviour
{ 
  public bool active;

  public virtual void CheckAssertions ()
  {

  }

  // public void Assert.IsNotNull (Object _object)
  // {
  //   // Assert.IsNotNull (_object);
  //   Assert.IsNotNull (_object, transform.PrintParents (_ping: true));
  // }

  // public void Assert.IsTrue (bool _condition)
  // {
  //   Assert.IsTrue (_condition, transform.PrintParents (_ping: true));
  // }

  // public void Assert.IsFalse (bool _condition)
  // {
  //   Assert.IsFalse (_condition, transform.PrintParents (_ping: true));
  // }

  public virtual void Awake()
  {
      
  }

  public virtual void Start ()
  {
    
  }

  public virtual void OnEnable()
  {
      
  }

  public virtual void OnDisable()
  {
      
  }

  public virtual void OnDestroy ()
  {

  }

  public virtual bool Activate ()
  {
    if (active)
    {
      Logger.LogWarning (
        $"{name.Important ()} is already activated!",
        this
      );
      return false;
    }

    active = true;
    return true;
  }

  public virtual bool Deactivate ()
  {
    if (!active)
    {
      Logger.LogWarning (
        $"{name.Important ()} is not activated!",
        this
      );
      return false;
    }

    active = false;
    return true;
  }
}
