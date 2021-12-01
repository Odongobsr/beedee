using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Bee
{
  /// <summary>
  /// Controls main menu state of game
  /// </summary>
  public class MainMenuController : SceneController
  {
    [Header ("References")]
    public UIScreen menuUIScreen;
    public CutsceneController introCutscene;
    public SwitchToGameController switchToGameController;
    public LanguageSelector languageSelector;

    public override void CheckAssertions ()
    {
      base.CheckAssertions ();

      Assert.IsNotNull (introCutscene);
      Assert.IsNotNull (menuUIScreen);
      Assert.IsNotNull (switchToGameController);
      Assert.IsNotNull (languageSelector);
    }

    public override void Awake()
    {
      base.Awake();

      GameGlobals.Instance.mainMenuController = this;
      GameGlobals.Instance.registry.hasShownIntroCutscene = false;
    }

    public override void Start ()
    {
      base.Start ();
      
      GameGlobals.Instance.audioManager.PlayMusic (
        _clip: GameGlobals.Instance.registry.audioRegistry.music_mainmenu
      );
    }

    public override void Activate()
    { 
      // deactivate UI screens
      // introCutscene.UIScreen.Deactivate (0);
      // menuUIScreen.Deactivate (0);

      // check if user has selected language
      bool hasSelectedLanguage = GameGlobals.Instance.registry.userDataReader.userData.hasSelectedLanguage;

      if (!hasSelectedLanguage) // if not, activate language selector
      {
        languageSelector.Activate ();
        return;
      }

      // user has already selected language
      base.Activate ();

      languageSelector.languageSelectScreen.Deactivate ();

      // if intro cutscene has already been shown, activate main menu
      if (GameGlobals.Instance.registry.hasShownIntroCutscene)    
      {
        ShowMenu ();
      }
      else // if introcutscene has not been shown , show it 
      {
        GameGlobals.Instance.registry.hasShownIntroCutscene = true;
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
      menuUIScreen.Activate (_onCompleteAction: ActivateSwitchToGameController);
    }

    public void HideMenu ()
    {
      menuUIScreen.Deactivate ();
    }

    void ActivateSwitchToGameController ()
    {
      switchToGameController.Activate ();
    }
  }
}