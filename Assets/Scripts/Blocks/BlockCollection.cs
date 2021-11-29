using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bee
{
  [CreateAssetMenu (
   fileName="Blocks - key",
   menuName="Blocks/Block Collection"
  )]
    public class BlockCollection : AbstractScriptableObject
    {
      public List<BlockData> blocks = new List<BlockData> ();
      public int count;

      public BlockData GetRandomBlock ()
      {
        BlockData data = blocks [Random.Range (0, blocks.Count)];

        return data;
      }
    }
}
