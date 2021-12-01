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

  public static void SetXPosition (this Transform _trans, float _x)
  {
    _trans.position = new Vector3 (
      x: _x,
      y: _trans.position.y,
      z: _trans.position.z
    );
  }
  
  public static void SetYPosition (this Transform _trans, float _y)
  {
    _trans.position = new Vector3 (
      x: _trans.position.x,
      y: _y,
      z: _trans.position.z
    );
  }
  
  public static void SetXYPosition (this Transform _trans, Vector2 _pos)
  {
    _trans.position = new Vector3 (
      x: _pos.x,
      y: _pos.y,
      z: _trans.position.z
    );
  }

  
}
