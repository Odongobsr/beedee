using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Bee
{
  [CreateAssetMenu (
    fileName = "Cutscene frame",
    menuName = "Cutscenes/Frame"
  )]
  public class CutsceneFrame : AbstractScriptableObject
  {
    public Sprite sprite;
    public RosettaKey text;

    public override void CheckAssertions()
    {
      base.CheckAssertions();

      Assert.IsNotNull (sprite);
      Assert.IsTrue (text != RosettaKey.NULL);
    }
  }
}