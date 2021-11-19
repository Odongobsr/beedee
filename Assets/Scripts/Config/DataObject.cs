using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bee
{
  [CreateAssetMenu (
    fileName ="Data Object",
    menuName = "Data Object"
  )]
  public class DataObject : AbstractScriptableObject
  {
    public AbstractPoolable prefab;

    [ContextMenu ("Assign data to prefab")]
    public override void OnValidate()
    {
      base.OnValidate();

      if (prefab && null == prefab.data)
      {
        prefab.data = this;
      }
    }
  }
}