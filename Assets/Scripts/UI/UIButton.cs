using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace Bee
{
  public class UIButton : StateListener
  {
    public Button button;

    public override void CheckAssertions()
    {
      base.CheckAssertions ();
      
      Assert.IsNotNull (button);
    }
  }
}
