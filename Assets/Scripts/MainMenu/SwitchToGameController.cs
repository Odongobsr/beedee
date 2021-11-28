using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Bee
{
  public class SwitchToGameController : AbstractGameComponent
  {
    [Header ("References")]
    public GameObject switcher;
    public AudioSource audioSource;
    public MainMenuController mainMenuController;
    
    [Header ("Runtime only")]
    public bool switchingToGameScene;

    public override void CheckAssertions()
    {
      base.CheckAssertions ();

      Assert.IsNotNull (switcher);    
      Assert.IsNotNull (audioSource);    
      Assert.IsNotNull (audioSource.clip);    
    }

    public override void Start()
    {
      base.Start ();

      switcher.gameObject.SetActive (false);
    }

    void Update()
    {
      if (active && !switchingToGameScene)
      {
        // detect user input
        if (Input.GetMouseButtonDown (0) || Input.GetKeyDown (KeyCode.Space))    
        {
          if (mainMenuController.introCutscene.isPlaying)
          {
            mainMenuController.introCutscene.StopCutscene ();
          }
          else
          {
            SwitchToGameScene ();
          }
        }
      }
    }

    void SwitchToGameScene ()
    {
      Logger.Log ("Try switch to game scene");
      switchingToGameScene = true;

      switcher.gameObject.SetActive (true);
      audioSource.Play ();
    }
  }
}