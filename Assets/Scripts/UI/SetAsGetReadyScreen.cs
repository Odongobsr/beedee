using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bee
{
    public class SetAsGetReadyScreen : MonoBehaviour
    {
      public UIScreen UIScreen;
      
      void Awake ()
      {
        GameGlobals.Instance.getReadyScreen = UIScreen;
      }
    }
}
