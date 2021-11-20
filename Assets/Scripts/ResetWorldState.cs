using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bee
{
  public class ResetWorldState : MonoBehaviour
  {
    void Awake ()
    {
      GameGlobals.Instance.registry.worldState = WorldState.Null;
    }
  }
}