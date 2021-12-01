using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bee
{
    public class SetAsGameOverScreen : MonoBehaviour
    {
      public UIScreen UIScreen;
      
      void Awake ()
      {
        GameGlobals.Instance.gameOverScreen = UIScreen; 
      }
    }
}
