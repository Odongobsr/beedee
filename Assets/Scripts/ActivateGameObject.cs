using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bee
{
  public class ActivateGameObject : StateListener
  {
    public bool activate;
    public GameObject obj;

    public override bool Enter ()
    {
      if (!base.Enter ()) return false;

      if (obj)
      {
        obj.SetActive (activate);
      }

      return true;
    }
  }
}