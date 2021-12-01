using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Bee
{
    [System.Serializable]
  public class PatternRuleSet
  {
    public List<PatternRule> patternRules;

    public int count;
  }

  [System.Serializable]
  public class PatternRule
  {
    public BlockCollection blockCollection;

    public int minCount;
    public int maxCount;

    public void CheckAssertions ()
    {
      Assert.IsTrue (minCount >= 0);
      Assert.IsTrue (maxCount >= minCount);
    }
  }

  [CreateAssetMenu (
   fileName="Rules - key",
   menuName="Object Pattern Rules"
  )]
  public class ObjectPatternRules : AbstractScriptableObject
  {
    public List<PatternRuleSet> patternRules;

    public override void CheckAssertions()
    {
      base.CheckAssertions ();

      Logger.Log (
        $"Check {name.Important ()}",
        this
      );

      List<BlockCollection> collections = new List<BlockCollection> ();
      
      for (int i = 0; i < patternRules.Count; i++)
      {
        Assert.IsTrue (patternRules [i].count > 0);

        for (int j = 0; j < patternRules [i].patternRules.Count; j++)
        {
          patternRules [i].patternRules [j].CheckAssertions ();

          collections.AddUnique (patternRules [i].patternRules [j].blockCollection);
        }
      }

      for (int i = 0; i < collections.Count; i++)
      {
        collections [i].CheckAssertions ();
      }
    }
  }
}
