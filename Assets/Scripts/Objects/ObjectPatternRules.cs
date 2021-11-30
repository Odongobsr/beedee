using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
  }

  [CreateAssetMenu (
   fileName="Rules - key",
   menuName="Object Pattern Rules"
  )]
  public class ObjectPatternRules : AbstractScriptableObject
  {
    public List<PatternRuleSet> patternRules;
  }
}
