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

      for (int i = 0; i < currentRules.patternRules.Count; i++)
      {
        PatternRule rule = currentRules.patternRules [i];

        int count = Random.Range (rule.minCount, rule.maxCount);

        for (int j = 0; j < count; j++)
        {
          objectPattern.objects.Add (rule.blockCollection.GetRandomBlock ());
        }
      }

      return objectPattern;
    }
  }
}
