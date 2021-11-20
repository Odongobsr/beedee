using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bee
{
  [CreateAssetMenu (
    fileName = "Cutscene frame",
    menuName = "Cutscenes/Frame"
  )]
  public class CutsceneFrame : AbstractScriptableObject
  {
    public Sprite sprite;
    [TextArea (3, 10)]
    public string text;
  }
}