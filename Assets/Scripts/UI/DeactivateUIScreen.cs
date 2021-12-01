using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bee
{
    public class DeactivateUIScreen : MonoBehaviour
    {
      public UIScreen UIScreen;

      void Awake ()
      {
        UIScreen = GetComponent<UIScreen> ();

        if (UIScreen)
        {
          UIScreen.Deactivate ();
        }
      }
    }
}
