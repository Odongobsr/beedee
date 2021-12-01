using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ObjectExtensionMethods
{
  public static string GetName (this Object obj)
  {
    return obj.name.Important ();
  }
}
