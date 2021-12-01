using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

namespace Bee
{
  [CreateAssetMenu (
   fileName="Scene Loader",
   menuName="Scene Loader"
  )]
    public class SceneLoader : AbstractScriptableObject
    {
      public bool loading;
      public AudioClip audioClip;

      void OnEnable()
      {
          loading = false;
      }

      public override void CheckAssertions ()
      {
        base.CheckAssertions ();

        Assert.IsNotNull (audioClip);
      }
      
      public void LoadGameScene ()
      {
        if (loading)
        {
          Logger.LogWarning (
            $"Scene loader is alredy active! Returning!",
            this
          );
          return;
        }
        loading = true;
        GameGlobals.Instance.audioManager.PlayFX (audioClip);
        // audioSource.Play ();
        GameGlobals.Instance.fadeScreen.Activate (_onCompleteAction: LoadGame);
      }

      void LoadGame ()
      {
        SceneManager.LoadScene (Scenes.Game.ToString ());
        loading = false;
      }

      public void LoadMainMenuScene ()
      {
        if (loading)
        {
          return;
        }
        loading = true;
        GameGlobals.Instance.audioManager.PlayFX (audioClip);
        // audioSource.Play ();
        GameGlobals.Instance.fadeScreen.Activate (_onCompleteAction: LoadMainMenu);
      }

      void LoadMainMenu ()
      {
        SceneManager.LoadScene (Scenes.MainMenu.ToString ());
        loading = false;
      }
    }
}
