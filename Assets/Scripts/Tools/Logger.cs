using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public static class Logger
{
  public static StringBuilder sb = new StringBuilder ();

  public static void Log (string _str, Object _context = null, string _color = "")
  {
    sb.Clear ();

    // add color
    if (_color.Length > 0)
    {
      _str = $"<color={_color}>{_str}</color>";
    }

    sb.Append (_str);
    sb.Append (GetTime ());

    Debug.Log (sb.ToString (), _context);
  }

  public static void LogList (string _title, string _message, Object _context = null, string _color = null)
  {
    sb.Clear ();
    
    // add color
    if (_color.Length > 0)
    {
      _title = $"<color={_color}>{_title}</color>";
    }

    sb.Append (_title);
    sb.Append (System.Environment.NewLine);
    sb.Append (_message);
    // sb.Append (GetTime ());

    Log (_str: sb.ToString (), _context: _context);
  }
  
  public static void LogWarning (string _str, Object _context = null)
  {
    sb.Clear ();
    sb.Append (_str);
    sb.Append (GetTime ());

    Debug.LogWarning (sb.ToString (), _context);
  }

  public static void LogWarningList (string _title, string _message, Object _context = null)
  {
    sb.Clear ();
    sb.Append (_title);
    sb.Append (System.Environment.NewLine);
    sb.Append (_message);
    sb.Append (GetTime ());

    Debug.LogWarning (sb.ToString (), _context);
  }
  
  public static void LogError (string _str, Object _context = null)
  {
    sb.Clear ();
    sb.Append (_str);
    sb.Append (GetTime ());

    Debug.LogError (sb.ToString (), _context);
  }

  public static void LogErrorList (string _title, string _message, Object _context = null)
  {
    sb.Clear ();
    sb.Append (_title);
    sb.Append (System.Environment.NewLine);
    sb.Append (_message);
    sb.Append (GetTime ());

    Debug.LogError (sb.ToString (), _context);
  }

  public static string GetTime ()
  {
    return $"<color=olive> [{Time.realtimeSinceStartup.ToString ("0.00")}]</color>";
  }

  public static void LogDivider ()
  {
    Debug.Log ("----");
  }
}
