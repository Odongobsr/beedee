using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Bee;

namespace Bee
{
  public static class UserDataFunctions
  {
    
    [MenuItem ("Debug/User data/Print user data")]
    static void PrintUserData ()
    {
      GameGlobals.Instance.registry.userDataReader.PrintUserData ();
    }

    [MenuItem ("Debug/User data/Load user data")]
    static void LoadUserData ()
    {
      GameGlobals.Instance.registry.userDataReader.LoadUserData ();
    }
    
    [MenuItem ("Debug/User data/Reset user data")]
    static void ResetUserData ()
    {
      // Logger.LogDivider ();
      GameGlobals.Instance.registry.userDataReader.ResetUserData();
    }

    [MenuItem ("Debug/User data/Clear all PlayerPrefs")]
    static void ClearPlayerPrefs ()
    {
      PlayerPrefs.DeleteAll ();

      Logger.LogWarning (
        $"PlayerPrefs cleared!",
        null
      );
    }
  }    
}