using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace Bee
{
  public class LanguageSelector : AbstractGameComponent
  {
    [Header ("References")]
    public UIScreen languageSelectScreen;
    public ToggleGroup toggleGroup;
    public Button chooseLanguageButton;

    [Header ("Runtime Only")]
    public List<UIToggle> toggles;

    public override void CheckAssertions()
    {
      base.CheckAssertions ();
      
      Assert.IsNotNull (toggleGroup);
      Assert.IsNotNull (languageSelectScreen);
      Assert.IsNotNull (chooseLanguageButton);
    }

    public override bool Activate ()
    {
      if (!base.Activate ()) return false;

      Logger.Log (
        $"Activate language selector",
        this
      );

      chooseLanguageButton.onClick.AddListener (ActivateMainMenu);

      // destroy existing toggles
      for (int i = 0; i < toggleGroup.transform.childCount; i++)
      {
        Destroy (toggleGroup.transform.GetChild (i).gameObject);
      }

      toggles.Clear ();

      // create toggles
      foreach (var key in GameGlobals.Instance.registry.rosettaReader.rosettaList [0].Keys)
      {
        // skip 'name' column
        if (0 == string.Compare (key, "name"))
        {
          // Logger.Log (
          //   $"Skipping CSV column - {key.Important ()}",
          //   this
          // );
          continue;
        }

        // create toggle
        UIToggle toggle = Instantiate (
          GameGlobals.Instance.registry.togglePrefab,
          Vector3.zero,
          Quaternion.identity,
          toggleGroup.transform
        ) as UIToggle;

        // setup toggle. Activate oggle that represents current language
        string currentLanguage = GameGlobals.Instance.registry.userDataReader.userData.language;

        toggle.Setup (
          _value: key, 
          _response: ToggleSelect, 
          _group: toggleGroup, 
          _active: string.Equals (key, currentLanguage)
        );

        toggles.AddUnique (toggle);
      }

      // activate language selector UI screen
      languageSelectScreen.Activate ();

      return true;
    }

    /// <summary>
    /// Called when toggle is selected
    /// </summary>
    public void ToggleSelect (string value)
    {
      GameGlobals.Instance.registry.userDataReader.userData.language = value;
      GameGlobals.Instance.registry.userDataReader.userData.hasSelectedLanguage = true;
      GameGlobals.Instance.registry.userDataReader.SaveUserData ();

      GameGlobals.Instance.registry.rosettaReader.UpdateLanguage ();
    }

    public void ActivateMainMenu ()
    {
      chooseLanguageButton.onClick.RemoveAllListeners ();

      GameGlobals.Instance.mainMenuController.Activate ();
    }
  }
}
