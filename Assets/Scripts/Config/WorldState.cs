using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Bee
{
  /// <summary>
  /// State of the game world
  /// </summary>
  public enum WorldState 
  {
    /// <summary>
    /// Game world does not exist
    /// </summary>
    Null = 0,
    /// <summary>
    /// Game world is setting up
    /// </summary>
    SettingUp = 1,
    /// <summary>
    /// game world is complete
    /// </summary>
    Complete = 2,
    /// <summary>
    /// Gameplay session is finished (game over, finished level)
    /// </summary>
    Retired = 3
  }
}
