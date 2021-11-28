using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bee
{
    public class SceneController : StateListener
    {
      public override bool Enter ()
      {
        if (!base.Enter ()) return false;

        Activate ();

        return true;
      }
    }
}
