using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

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
}
