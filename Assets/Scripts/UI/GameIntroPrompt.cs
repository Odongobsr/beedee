using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bee
{
  public class GameIntroPrompt : MonoBehaviour
  {
    public UIScreen UIScreen;

    void Awake()
    {
      GameGlobals.Instance.gameIntroPrompt = this;    
    }
  }
}