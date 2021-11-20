using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bee
{
  [CreateAssetMenu (
    fileName = "UI Style - name",
    menuName = "UI/UI Style"
  )]
  public class StyleAsset : AbstractScriptableObject
  {
    public StyleName styleName;

    public GUIStyle style;
  }
}