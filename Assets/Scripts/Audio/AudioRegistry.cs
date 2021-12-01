using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Bee
{
  [CreateAssetMenu (
   fileName="Audio Registry",
   menuName="Audio Registry"
  )]
    public class AudioRegistry : AbstractScriptableObject
    {
      public AudioClip music_game;
      public AudioClip music_mainmenu;
      public AudioClip music_bee;

      public AudioClip fx_coin;
      public AudioClip fx_click;
      public AudioClip fx_obstacle;
      public AudioClip fx_gameover;
      public AudioClip fx_flower;
      public AudioClip fx_select;

      public override void CheckAssertions()
      {
        base.CheckAssertions ();
        
        Assert.IsNotNull (music_bee);
        Assert.IsNotNull (music_mainmenu);
        Assert.IsNotNull (music_game);

        Assert.IsNotNull (fx_coin);
        Assert.IsNotNull (fx_click);
        Assert.IsNotNull (fx_flower);
        Assert.IsNotNull (fx_obstacle);
        Assert.IsNotNull (fx_gameover);
        Assert.IsNotNull (fx_select);
      }
       
    }
}
