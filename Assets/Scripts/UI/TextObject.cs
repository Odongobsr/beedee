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
    public RosettaKey key;
    public StyleName styleName;
    public bool useColor;

    [Header ("References")]
    public Text text;

    [Header ("Runtime Only")]
    public StyleAsset style;

    public override void CheckAssertions ()
    {
      base.CheckAssertions ();

      Assert.IsNotNull (text);
    }

    public override void OnEnable()
    {
      base.OnEnable();

      RosettaReader.onChangeLanguage += OnChangeLanguage;
    }

    public override void OnDisable()
    {
      base.OnDisable();

      RosettaReader.onChangeLanguage -= OnChangeLanguage;
    }

    [ContextMenu ("Setup")]
    public override bool Setup ()
    {
      base.Setup ();

      style = GameGlobals.Instance.registry.GetStyle (styleName);

      text.font = style.style.font;

      if (useColor)
      {
        text.color = style.style.normal.textColor;
      }

      UpdateText ();

      // text.fontSize = style.style.fontSize;

      // Logger.Log (
      //   $"Set {text.name} style to {style.styleName}",
      //   text
      // );

      return true;
    }

    void OnChangeLanguage ()
    {
      UpdateText ();
    }

    public void UpdateText ()
    {
      if (key == RosettaKey.NULL)
      {
        Logger.LogWarning (
          $"{name.Important ()} Rosetta Key is NULL. Ignoring",
          this
        );
        return;
      }

      text.text = GameGlobals.Instance.registry.rosettaReader.GetKey (key);
    }
  }
}