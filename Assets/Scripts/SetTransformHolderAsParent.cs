using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bee
{
  public class SetTransformHolderAsParent : MonoBehaviour
  {
    void Start()
    {
      transform.SetParent (GameGlobals.Instance.transformHolder);
    }
  }
}
