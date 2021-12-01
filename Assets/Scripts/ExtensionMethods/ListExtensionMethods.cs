using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Assertions;

public static class ListExtensionMethods
{
  static StringBuilder sb = new StringBuilder ();

  /// <summary>
  /// use unityEngine.Assertions to check that 
  /// no items in the list are null (if any)
  /// </summary>
  public static bool AddUnique<T> (this List<T> list, T item)
  {
    if (null == item)
    {
      // Logger.LogWarning (
      //   list.GetType () + " cannot add NULL item!",
      //   null,
      //   HelperPriority.Normal
      // );
      return false;
    }

    if (!list.Contains (item))
    {
      list.Add (item);
      return true;
    }

    // Debug.LogWarning (
    //   list.GetType () + " already contains " + item,
    //   null
    // );
    return false;
  }

  /// <summary>
  /// use unityEngine.Assertions to check that 
  /// no items in the list are null (if any)
  /// </summary>
  public static bool AddUniqueRange<T> (this List<T> list, List<T> range)
  {
    int value = 0;

    for (int r = 0; r < range.Count; r++)
    {
      if (!list.Contains (range [r]))
      {
        list.Add (range [r]);
        value++;
      }
      else
      {
        Debug.LogWarning (
          list.GetType () + " already contains " + range [r],
          null
        );
      }
    }

    if (value > 0)
    {
      Debug.LogWarning (
        list.GetType () + " " + value + " new items added!",
        null
      );
      return true;
    }
    else
    {
      Debug.LogWarning (
        list.GetType () + " no new items added!",
        null
      );
      return false;
    }
  }

  /// <summary>
  /// use unityEngine.Assertions to check that 
  /// no items in the list are null (if any)
  /// </summary>
  public static bool HasNull<T> (this List<T> list)
  {
    for (int c = 0; c < list.Count; c++)
    {
      bool isNull = null == list [c];

      // Assert.IsFalse (isNull);

      if (isNull)
      {
        return true;
      }
    }

    return false;
  }
  
  /// <summary>
  /// Return formatted string of list count
  /// Example: "[0]"
  /// </summary>
  public static string GetCount<T> (this List<T> list)
  {
    sb.Clear ();

    sb.Append ("[");
    sb.Append (list.Count);
    sb.Append ("]");

    return sb.ToString ();
  }


  /// <summary>
  /// Return formatted string of list contents
  /// Example: "- one"
  ///          "- two"
  ///          "- three"
  ///          "-------"
  /// </summary>
  public static string PrintMe<T> (this List<T> list, bool verbose = false)
  {
    if (list.Count <= 0)
    {
      return "NULL";
    }

    sb.Clear ();
    string newLine = Environment.NewLine;
    
    for (int p = 0; p < list.Count; p++)
    {
      sb.Append (newLine);
      sb.Append ("[");
      sb.Append (p);
      sb.Append ("] ");
      sb.Append (list [p].ToString ());
    }

    sb.Append (newLine);
    sb.Append ("-------");
    sb.Append (newLine);

    return sb.ToString ();
  }

  public static void RunActionOnAllItems<T> (this List<T> list, Action<T> action)
  {
    for (int t = 0; t < list.Count; t++)
    {
      action.Invoke (list [t]);
    }
  }
  
  /// <summary>
  /// Sort the contents of a list alphabetically (A - Z), or reverse (Z - A)
  /// </summary>
  public static void SortByName<T> (this List<T> list, bool reverse = false)
  {
    if (reverse)
    {        
      list.Sort ((x, y) => 
              string.Compare (
                y.ToString (),
                x.ToString () 
              ));
    }
    else
    {
      list.Sort ((x, y) => 
              string.Compare (
                x.ToString (), 
                y.ToString ()
              ));
    }
      
  }
}
