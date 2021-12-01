using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bee
{
    public class SetAsFadeScreen : MonoBehaviour
    {
      public UIScreen UIScreen;
      
      void Awake ()
      {
        GameGlobals.Instance.fadeScreen = UIScreen;
      }
    }
}
