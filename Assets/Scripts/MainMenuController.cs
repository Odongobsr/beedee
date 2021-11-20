using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Bee
{
  /// <summary>
  /// Controls main menu state of game
  /// </summary>
  public class MainMenuController : MonoBehaviour
  {
    [Header ("References")]
    public UIScreen menuUIScreen;
    public CutsceneController introCutscene;
    public SwitchToGameController switchToGameController;

    void Awake ()
    {
      Assert.IsNotNull (introCutscene);
      Assert.IsNotNull (menuUIScreen);
      Assert.IsNotNull (switchToGameController);
    }

    void OnEnable ()
    {
      Logger.LogDivider ();
      Logger.Log ("Enable main menu controller");
    }

    void Start()
    {
      introCutscene.UIScreen.Deactivate (0);
      menuUIScreen.Deactivate (0);

      if (GameGlobals.Instance.registry.hasShownIntroCutscene)    
      {
        menuUIScreen.Activate ();
      }
      else
      {
        introCutscene.StartCutscene (ShowMenu);
      }
    }

    void Update()
    {
      if (Input.GetKeyDown (KeyCode.Escape))
      {
        Application.Quit ();
      }
    }

    public void ShowMenu ()
    {
      menuUIScreen.Activate ();
    }
  }
}