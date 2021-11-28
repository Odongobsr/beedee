using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bee
{
  [CreateAssetMenu (
   fileName="PlayerPrefsReader",
   menuName="Data/PlayerPrefsReader"
  )]
  public class PlayerPrefsReader : AbstractScriptableObject
  {
#region public functions
    public string GetString (string key)
    {
      // if key exists, get it
      if (PlayerPrefs.HasKey (key))
      {
        string str = PlayerPrefs.GetString (key);

        Logger.LogList (
          _title: $"Get player prefs string: key: {key.Important ()}",
          _message: $"value: {str.Important ().Print ()}",
          this
        );
        return str;
      }

      // otherwise return empty string
      return "";
    }

    internal void SetString(string key, string value)
    {
      PlayerPrefs.SetString (key: key, value: value);

      Logger.LogList (
        _title: $"Set player prefs string - key: {key.Important ()}",
        _message: $"value: {value}",
        this
      );
    }
    #endregion
  }
}