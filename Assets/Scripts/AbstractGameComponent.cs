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

  public virtual void Activate ()
  {
    active = true;
  }

  public virtual void Deactivate ()
  {
    active = false;
  }
}
