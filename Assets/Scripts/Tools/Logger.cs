using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Logger
{
  public static void Log (string message, Object context = null)
  {
    Debug.Log (message + GetTime (), context);
  }

  public static void LogWarning (string message, Object context = null)
  {
    Debug.LogWarning (message + GetTime (), context);
  }

  public static void LogError (string message, Object context = null)
  {
    Debug.LogError (message + GetTime (), context);
  }
  public static void LogAssertion (string message, Object context = null)
  {
    Debug.LogAssertion (message + GetTime (), context);
  }


  public static string GetTime ()
  {
    return $" <color=olive>[{Time.time.ToString ("0.00")}]</color>";
  }
}
