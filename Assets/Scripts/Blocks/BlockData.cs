using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bee
{
  [CreateAssetMenu (
    fileName ="BlockData",
    menuName = "Block Data"
  )]
  public class BlockData : DataObject
  {
    // public Block block;
    public Orientation orientation;
    /// <summary>
    /// Should this block be rotated based on its orientation?
    /// </summary>
    public bool rotateToOrientation;
  }
}