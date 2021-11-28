using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bee
{
  [System.Serializable]
  public class DataCollection 
  {
    public List<DataValue> values;

    public string GetValue (string _key)
    {
      for (int i = 0; i < values.Count; i++)
      {
        if (0 == string.Compare (_key, values [i].key))
        {
          return values [i].value;
        }
      }

      return "";
    }

    public void Add (string _key, string _value)
    {
      if (ContainsKey (_key))
      {
        Logger.LogWarning (
          $"Could not add key: {_key.Important ()}. Value already exists: {_value.Important ()}",
          null
        );
      }

      // Logger.Log (
      //   $"Add key: {_key.Important ()}. Value: {_value.Important ()}",
      //   null
      // );
      values.Add (new DataValue { key = _key, value = _value });
    }

    public bool ContainsKey (string _key)
    {
     for (int i = 0; i < values.Count; i++)
      {
        if (0 == string.Compare (_key, values [i].key))
        {
          return true;
        }
      }

      return false;
    }

    public void Clear()
    {
      values = new List<DataValue> ();
    }
  }
}
