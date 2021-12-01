using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Bee
{
  public class EnergyBar : StateListener
  {
    public Image image;

    public override void MyUpdate()
    {
      base.MyUpdate();

      image.transform.localScale = new Vector3 (
        x: GameGlobals.Instance.registry.playerHealth.value,
        y: 1,
        z: 1
      );
    }
  }
}
