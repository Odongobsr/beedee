using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Logger
{
  public static void Log (string message, Object context = null)
  {
    Debug.Log (message + GetTime (), context);
  }

  public static string GetTime ()
  {
    return $" <color=olive>[{Time.time.ToString ("0.00")}]</color>";
  }
}
