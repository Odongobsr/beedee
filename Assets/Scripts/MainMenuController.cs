using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Bee
{
  /// <summary>
  /// Controls main menu state of game
  /// </summary>
  public class MainMenuController : MonoBehaviour
  {
    [Header ("References")]
    public SwitchToGameController switchToGameController;

    void Awake ()
    {
      Assert.IsNotNull (switchToGameController);
    }

    void OnEnable ()
    {
      Logger.LogDivider ();
      Logger.Log ("Enable main menu controller");
    }
  }
}