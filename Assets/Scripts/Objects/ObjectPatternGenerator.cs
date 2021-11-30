using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Bee
{
  public class ObjectPatternGenerator : AbstractGameComponent
  {
    [Header ("References")]
    public ObjectPatternRules currentRules;

    [Header ("Runtime Only")]
    public ObjectPattern objectPattern;

    public override void CheckAssertions()
    {
      base.CheckAssertions ();
      
      Assert.IsNotNull (currentRules);
    }

    [ContextMenu ("Generate Pattern")]
    public ObjectPattern GeneratePattern ()
    {
      objectPattern = new ObjectPattern();
      objectPattern.objects = new List<DataObject> ();

      for (int k = 0; k < currentRules.patternRules.Count; k++) // how many sets?
      {
        for (int i = 0; i < currentRules.patternRules [k].count; i++) // how many times do we repeat rules in set?
        {
          for (int l = 0; l < currentRules.patternRules [k].patternRules.Count; l++) // how many rules in set?
          {
            PatternRule rule = currentRules.patternRules [k].patternRules [l];

            int count = Random.Range (rule.minCount, rule.maxCount);

            for (int j = 0; j < count; j++) // how many object in rule?
            {
              objectPattern.objects.Add (rule.blockCollection.GetRandomBlock ());
            }
          }
        }
      }

      return objectPattern;
    }
  }
}
