using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Bee
{
  public class ActivateUIScreen : StateListener
  {
    public bool activate;
    public UIScreen UIScreen;

    public override void CheckAssertions()
    {
      base.CheckAssertions();

      Assert.IsNotNull (UIScreen);
    }

    public override bool Enter()
    {
      if (!base.Enter()) return false;

      if (activate)
      {
        UIScreen.Activate ();
      }
      else
      {
        UIScreen.Deactivate ();
      }

      return true;
    }
  }
}