using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Bee
{
  /// <summary>
  /// A component that is part of a block
  /// </summary>
  public abstract class AbstractBlockDependent : AbstractGameComponent
  {
    public Block block;
  }
}