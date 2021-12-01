using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Bee
{
  public class MainCamera : StateListener
  {
#region public variables
    public ShakeTransform shakeTransform;
#endregion

#region public functions
    public override void Awake ()
    {
      base.Awake ();

      GameGlobals.Instance.mainCamera = this;
    }
    
    public override void CheckAssertions()
    {
      base.CheckAssertions();

      Assert.IsNotNull (shakeTransform);
    }
#endregion

#region mono functions
    
#endregion
  }
}
