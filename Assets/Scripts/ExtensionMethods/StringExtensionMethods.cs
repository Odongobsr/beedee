using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StringExtensionMethods
{
  /// <summary>
  /// Returns IMPORTANT string
  /// </summary>
  public static string Important (this string _str, bool _shout = false)
  {
    return $"<b>{_str}</b>";
  }

  /// <summary>
  /// Print string (shows if string is null)
  /// </summary>
  public static string Print (this string _str, string _empty = "NULL")
  {
    return _str.Length > 0 ? _str : _empty;
  }
}
