using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Note that is visible in ispector
/// </summary>
public class EditorNote : MonoBehaviour
{
  [TextArea (3, 15)]
  public string text;
}
