using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Bee
{
  public class AudioManager : StateListener
  {
#region public variables
    [Header ("References")]
    public Transform FXHolder;
    public Transform musicHolder;
    public List<AudioSource> audioSources_FX; 
    public List<AudioSource> audioSources_Music; 
    // public AudioSource musicSound;
    // public AudioSource flowerSound;
    // public AudioSource coinSound;
    // public AudioSource obstacleSound;
    // public AudioSource beeSound;
    #endregion

    #region mono functions
    public override void Awake ()
    {
      base.Awake ();

      GameGlobals.Instance.audioManager = this;
    }

    public override void Start() 
    {
      base.Start ();

      audioSources_FX = new List<AudioSource> (FXHolder.GetComponentsInChildren<AudioSource> ());  
      audioSources_Music = new List<AudioSource> (musicHolder.GetComponentsInChildren<AudioSource> ());  
    }
#endregion

#region public functions
    public override void CheckAssertions()
    {
      base.CheckAssertions ();

      Assert.IsNotNull (FXHolder);
      Assert.IsNotNull (musicHolder);

    //   Assert.IsFalse (audioSources_FX.HasNull ());
    //   Assert.IsFalse (audioSources_Music.HasNull ());
      
    //   // Assert.IsNotNull (musicSound);
    //   // Assert.IsNotNull (flowerSound);
    //   // Assert.IsNotNull (coinSound);
    //   // Assert.IsNotNull (obstacleSound);
    //   // Assert.IsNotNull (beeSound);
    }

    public void PlayFX (AudioClip _clip)
    {
      bool found = false;

      for (int i = 0; i < audioSources_FX.Count; i++)
      {
        if (audioSources_FX [i].isPlaying)
        {
          continue;
        }

        audioSources_FX [i].clip = _clip;
        audioSources_FX [i].Play ();
        found = true;

        // Logger.Log (
        //   $"{audioSources_FX [i].name.Important ()} - play FX {audioSources_FX [i].clip.name.Important ()}",
        //   audioSources_FX [i]
        // );

        break;
      }

      if (!found)
      {
        Logger.Log (
          $" Unable to find free FX audio source for {_clip.name.Important ()}",
          this
        );
      }
    }
    
    public void PlayMusic (AudioClip _clip)
    {
      bool found = false;

      for (int i = 0; i < audioSources_Music.Count; i++)
      {
        if (audioSources_Music [i].isPlaying)
        {
          continue;
        }

        audioSources_Music [i].clip = _clip;
        audioSources_Music [i].Play ();
        found = true;

        Logger.Log (
          $"{audioSources_Music [i].name.Important ()} - play Music {audioSources_Music [i].clip.name.Important ()}",
          audioSources_Music [i]
        );

        break;
      }
      
      if (!found)
      {
        Logger.Log (
          $" Unable to find free Music audio source for {_clip.name.Important ()}",
          this
        );
      }
    }

    internal void StopMusic(AudioClip _clip)
    {
      bool found = false;

      for (int i = 0; i < audioSources_Music.Count; i++)
      {
        if (!audioSources_Music [i].isPlaying)
        {
          continue;
        }

        if (audioSources_Music [i].clip == _clip)
        {
          audioSources_Music [i].Stop ();
          found = true;

          Logger.Log (
            $"{audioSources_Music [i].name.Important ()} - stop Music {audioSources_Music [i].clip.name.Important ()}",
            audioSources_Music [i]
          );

          break;
        }
      }
      
      if (!found)
      {
        Logger.Log (
          $" Unable to stop Music audio source: {_clip.name.Important ()}",
          this
        );
      }
    }
    #endregion
  }
}
