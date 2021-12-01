using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bee
{
  public class SetAsStatsScreen : MonoBehaviour
  {
    public UIScreen UIScreen;

    public void Awake ()
    {
      GameGlobals.Instance.statsScreen = UIScreen;
    }
  }
}
