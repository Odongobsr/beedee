using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Bee;

public static class Logger
{
  public static StringBuilder sb = new StringBuilder ();
  public static string newline = System.Environment.NewLine;

  public static void Log (string _str, Object _context = null, string _color = "", bool _showTime = true)
  {
    StringBuilder sb = new StringBuilder ();

    sb.Clear ();

    // add color
    if (_color.Length > 0)
    {
      _str = $"<color={_color.Replace(' ','0')}>{_str}</color>";
    }

    sb.Append (_str);

    if (_showTime)
    {
      sb.Append (GetTime ());
    }

    Debug.Log (sb.ToString (), _context);
  }

  /// <summary>
  /// Show the begining of something
  /// </summary>
  public static void LogBegin (string _str, Object _context = null)
  {
    StringBuilder sb = new StringBuilder ();

    sb.Clear ();

    sb.Append ("BEGIN - ");
    sb.Append (_str);

    Log (_str: sb.ToString (), _context: _context, _color: "yellow");
  }

  /// <summary>
  /// Show the end of something
  /// </summary>
  public static void LogEnd (string _str, Object _context = null)
  {
    StringBuilder sb = new StringBuilder ();
    
    sb.Clear ();

    sb.Append ("END - ");
    sb.Append (_str);

    Log (_str: sb.ToString (), _context: _context, _color: "yellow");
  }
  public static void LogList (string _title, string _message, Object _context = null, string _color = "")
  {
    StringBuilder sb = new StringBuilder ();
    
    sb.Clear ();
    
    // add color
    if (_color.Length > 0)
    {
      _title = $"<color={_color.Replace(' ','0')}>{_title}</color>";
    }

    sb.Append (_title);
    sb.Append (":");
    sb.Append (GetTime ());
    sb.Append (newline);
    sb.Append (newline);
    sb.Append (_message);
    sb.Append (newline);
    sb.Append (newline);

    Log (_str: sb.ToString (), _context: _context, _showTime: false);
  }
  
  public static void LogWarning (string _str, Object _context = null)
  {
    StringBuilder sb = new StringBuilder ();
    
    sb.Clear ();
    sb.Append ($"<color=white>{_str}</color>)");
    sb.Append (GetTime ());

    Debug.LogWarning (sb.ToString (), _context);
  }

  public static void LogWarningList (string _title, string _message, Object _context = null)
  {
    StringBuilder sb = new StringBuilder ();
    
    sb.Clear ();
    sb.Append ($"<color=white>{_title}</color>)");
    sb.Append (GetTime ());
    sb.Append (newline);
    sb.Append (newline);
    sb.Append (_message);
    sb.Append (newline);
    sb.Append (newline);

    Debug.LogWarning (sb.ToString (), _context);
  }
  
  public static void LogError (string _str, Object _context = null)
  {
    StringBuilder sb = new StringBuilder ();
    
    sb.Clear ();
    sb.Append (_str);
    sb.Append (GetTime ());

    Debug.LogError (sb.ToString (), _context);
  }

  public static void LogErrorList (string _title, string _message, Object _context = null)
  {
    StringBuilder sb = new StringBuilder ();
    
    sb.Clear ();
    sb.Append (_title);
    sb.Append (GetTime ());
    sb.Append (newline);
    sb.Append (newline);
    sb.Append (_message);
    sb.Append (newline);
    sb.Append (newline);

    Debug.LogError (sb.ToString (), _context);
  }

    public static void ChangeValue<T> (string key, T value)
    {
      Logger.Log (
        $"Change {key.Important ()} to {value.ToString ().Important ()}",
        null
      );
    }

  public static string GetTime ()
  {
#if UNITY_EDITOR
    if (!Application.isPlaying)
    {
      return $"<color=olive>  [{Time.realtimeSinceStartup}]</color>";
    }
#endif

    return $"<color=olive>  [{GameGlobals.time}]</color>";
  }

  public static void LogDivider ()
  {
    Debug.Log ("----------------------");
  }
}
