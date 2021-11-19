using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Assertions;

public static class DictionaryExtensionMethods
{
  static StringBuilder sb = new StringBuilder ();

  /// <summary>
  /// Return formatted string of dictionary keys
  /// Example: "- one"
  ///          "- two"
  ///          "- three"
  /// </summary>
  public static string PrintKeys<T, T2> (this Dictionary<T, T2> dict, bool verbose = false)
  {
    if (dict.Keys.Count == 0)
    {
      return "No keys found! \n";
    };

    sb.Clear ();
    string newLine = Environment.NewLine;
    
    foreach (var key in dict.Keys)
    {
      sb.Append (newLine);
      sb.Append ("- ");
      sb.Append (key.ToString ());
    }

    sb.Append (newLine);
    sb.Append ("-------");
    sb.Append (newLine);

    return sb.ToString ();
  }
}
