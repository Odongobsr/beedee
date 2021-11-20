using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Bee
{
  public class PlayerButtonsUIScreen : StateListener
  {
    public UIScreen UIScreen;

    public override void CheckAssertions()
    {
      base.CheckAssertions();

      Assert.IsNotNull (UIScreen);
    }

    public override void Start()
    {
      base.Start();

      GameGlobals.Instance.playerButtonsUIScreen = UIScreen;
    }

  }
}