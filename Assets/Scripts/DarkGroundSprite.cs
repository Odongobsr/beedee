using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Bee
{
  public class DarkGroundSprite : StateListener
  {
    public SpriteRendererController spriteRendererController;

    public override void CheckAssertions()
    {
      base.CheckAssertions();

      Assert.IsNotNull (spriteRendererController);
    }
    public override void Awake()
    {
      base.Awake ();

      GameGlobals.Instance.darkGroundSprite = spriteRendererController;     
    }
  }
}