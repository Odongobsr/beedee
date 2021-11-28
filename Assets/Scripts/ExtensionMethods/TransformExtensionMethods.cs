using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public static class TransformExtensionMethods
{
  public static string PrintParents (this Transform _trans, bool _ping = false)
  {
    string str = _trans.name;
    Transform parent = _trans.parent;

    while (true)
    {
      if (parent)
      {
        str = $"{parent.name} - {str}";
        parent = parent.parent;
      }
      else
      {
        break;
      }
    }

// #if UNITY_EDITOR
//     if (_ping)
//     {
//       EditorGUIUtility.PingObject (_trans);
//     }
// #endif

    return str;
  }
}
