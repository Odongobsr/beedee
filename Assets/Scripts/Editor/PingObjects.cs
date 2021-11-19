// SOURCE: file:///C:/Program%20Files/Unity/Hub/Editor/2019.2.16f1/Editor/Data/Documentation/en/ScriptReference/EditorGUIUtility.PingObject.html
// Pings the currently selected Object
using UnityEditor;
using UnityEngine;

namespace Bee
{
  public class PingObjects
  {
    [MenuItem("Ping/Registry",isValidateFunction: false,priority: 100)]
    static void PingRegistry()
    {
      EditorGUIUtility.PingObject(GameGlobals.Instance.registry);
    }
  }
}