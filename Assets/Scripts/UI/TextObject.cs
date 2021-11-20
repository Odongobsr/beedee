using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace Bee
{
  public class TextObject : StateListener
  {
    [Header ("Configuration")]
    public StyleName styleName;

    [Header ("References")]
    public Text text;

    [Header ("Runtime Only")]
    public StyleAsset style;

    public override void CheckAssertions ()
    {
      base.CheckAssertions ();

      Assert.IsNotNull (text);
    }

    [ContextMenu ("Setup")]
    public override bool Setup ()
    {
      base.Setup ();

      style = GameGlobals.Instance.registry.GetStyle (styleName);

      text.font = style.style.font;
      // text.fontSize = style.style.fontSize;

      // Logger.Log (
      //   $"Set {text.name} style to {style.styleName}",
      //   text
      // );

      return true;
    }
  }
}