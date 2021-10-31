using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (
  fileName ="BlockData",
  menuName = "Block Data"
)]
public class BlockData : AbstractScriptableObject
{
  public Block prefab;
}
