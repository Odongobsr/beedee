using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace Bee
{
    public class ScoreText : StateListener
    {
      int lastScore = -1;
      public Text scoreText;

      public override void CheckAssertions()
      {
        base.CheckAssertions ();
        
        Assert.IsNotNull (scoreText);
      }

      public override void Start ()
      {
        base.Start ();
        
        lastScore = -1;
        string str = GameGlobals.Instance.registry.rosettaReader.GetKey (RosettaKey.score);
        scoreText.text = $"{str}: 0";
      }

      public override void MyLateUpdate ()
      {
        base.MyLateUpdate ();

        if (GameGlobals.Instance.registry.score != lastScore)
        {
          lastScore = GameGlobals.Instance.registry.score;
          string str = GameGlobals.Instance.registry.rosettaReader.GetKey (RosettaKey.score);
          scoreText.text = $"{str}: {lastScore}";
        }
      }
    }
}
