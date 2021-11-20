using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bee
{
  public class CoroutineRunner : MonoBehaviour
  {
    void Awake ()
    {
      GameGlobals.Instance.runner = this;
    }
  }
}