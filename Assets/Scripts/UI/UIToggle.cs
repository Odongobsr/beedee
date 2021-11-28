using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.Assertions;

namespace Bee
{
  public class UIToggle : StateListener
  {
    [Header ("References")]
    public TextObject text;
    public Toggle toggle;

    public string toggleValue;
    UnityAction<string> responseAction;

    public override void CheckAssertions()
    {
      base.CheckAssertions ();
      
      Assert.IsNotNull (toggle);
      Assert.IsNotNull (text);
    }

    public void Setup (UnityAction<string> _response, ToggleGroup _group = null, bool _active = false, string _value = "")
    {
      // update label
      RosettaKey key = GameGlobals.Instance.registry.rosettaReader.GetRosettaKey (_value);
      toggleValue = key.ToString ();
      text.key = key;
      text.UpdateText ();

      toggle.name = "Toggle-" + toggleValue;

      // assignAction
      toggle.isOn = _active;

      // add to toggle group
      if (_group) { toggle.group = _group; }

      responseAction = _response;
      toggle.onValueChanged.AddListener (OnValueChanged);

      Logger.Log (
        $"Create toggle - {_value.Important ()}. Active: {toggle.isOn.ToString ().Important ()}",
        this
      );
    }

    public override void OnDestroy()
    {
      base.OnDestroy();

      toggle.onValueChanged.RemoveAllListeners ();
    }

    void OnValueChanged (bool value)
    {
      if (toggle.isOn)
      {
        responseAction?.Invoke (toggleValue);
      }
    }
  }
}
