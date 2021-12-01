using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

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

      public override void CheckAssertions()
      {
        base.CheckAssertions ();
        
        Assert.IsFalse (blocks.HasNull ());
        Assert.IsTrue (count > 0);

        for (int i = 0; i < blocks.Count; i++)
        {
          blocks [i].CheckAssertions ();
        }

        Logger.LogList (
          _title: $"{name.Important ()} - check {blocks.Count.ToString ().Important ()} blocks",
          _message: $"{blocks.PrintMe ()}",
          this
        );
      }
       

      public BlockData GetRandomBlock ()
      {
        BlockData data = blocks [Random.Range (0, blocks.Count)];

        return data;
      }
    }
}
