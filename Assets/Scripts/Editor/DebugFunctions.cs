using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;
using Bee;

namespace Bee
{
  public class DebugFunctions 
  {
    [MenuItem("Debug/Check Game Components",isValidateFunction: false,priority: 90)]
    static void CheckGameComponents()
    {
      GameGlobals.Instance.registry.CheckGameComponents ();
    }

    static string scenePath = "Assets/Scenes/";
    
    [MenuItem("Debug/Load Main Menu",isValidateFunction: false,priority: 100)]
    static void LoadMainMenu()
    {
      EditorSceneManager.OpenScene (scenePath + Scenes.MainMenu.ToString () + ".unity");
    }
    
    [MenuItem("Debug/Load Game Scene",isValidateFunction: false,priority: 100)]
    static void LoadGame()
    {
      EditorSceneManager.OpenScene (scenePath + Scenes.Game.ToString () + ".unity");
    }
  }
}