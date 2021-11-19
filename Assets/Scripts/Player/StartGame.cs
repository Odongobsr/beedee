using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bee
{
  public class StartGame : MonoBehaviour
  {
    public void StartTheGame ()
    {
      if (GameGlobals.Instance.registry.paused)
      {
        GameGlobals.Instance.registry.UnPause ();
      }
    }
  }
}