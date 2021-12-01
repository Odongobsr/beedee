using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Bee
{
  public class FlowerManager : AbstractGameComponent
  {
    public static int stepCount;

    public void PollinateFlower ()
    {
      // GameGlobals.Instance.audioManager.flowerSound.Play ();
      GameGlobals.Instance.audioManager.PlayFX (
        _clip: GameGlobals.Instance.registry.audioRegistry.fx_flower
      );

      GameGlobals.Instance.darkGroundSprite.ChangeAlpha (
        _diff: GameGlobals.Instance.registry.groundLightenValue,
        _time: GameGlobals.Instance.registry.groundLightenTime
      );
      GameGlobals.Instance.registry.playerHealth.value = 1.2f;
      GameGlobals.Instance.registry.IncreaseGlobalSpeed ();
      GameGlobals.Instance.gameController.flowersPollinated++;
    }
  }
}
