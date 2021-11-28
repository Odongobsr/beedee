using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bee
{
  [CreateAssetMenu (
   fileName="UserDataReader",
   menuName="Data/User Data Reader"
  )]
  public class UserDataReader : AbstractScriptableObject
  {
#region public variables
    [Header ("Configuration")]
    public UserData defaultUserData = new UserData ();

    [Header ("Runtime Only")]
    public UserData userData = new UserData ();

#endregion

#region public functions
    public string GetUserDataFromPlayerPrefs ()
    {
      return GameGlobals.Instance.registry.playerPrefsReader.GetString (
        GameGlobals.Instance.registry.userDataKey
      );
    }

    [ContextMenu ("Load user data")]
    public UserData LoadUserData ()
    {
      string playerPrefsString = GetUserDataFromPlayerPrefs ();

      if (null == playerPrefsString || playerPrefsString.Length <= 0)
      {
        Logger.LogWarning (
          "User data in playerprefs is NULL!",
          this
        );

        ResetUserData ();

        return userData;
      }

      Logger.LogList (
        _title: $"Load userdata playerprefs JSON",
        _message: $"{playerPrefsString}",
        this
      );

      userData = JsonUtility.FromJson<UserData>(playerPrefsString);

      PrintUserData ("Loaded user data");

      return userData;
    }

    [ContextMenu ("Reset user data!", isValidateFunction: false, priority: -110)]
    public void ResetUserData ()
    {
      userData = new UserData ();
      SetUserDataToDefaultValues ();
    }

    [ContextMenu ("Print user data!", isValidateFunction: false, priority: -110)]
    public void PrintUserData (string _prefix = "User data")
    {
      Logger.LogList (
        _title: $"{_prefix}",
        _message: $"{userData.ToString ()}",
        this
      );
    }

    [ContextMenu ("Set user data to default values!", isValidateFunction: false, priority: -110)]
    public void SetUserDataToDefaultValues ()
    {
      userData.language = defaultUserData.language;
      userData.hasSelectedLanguage = defaultUserData.hasSelectedLanguage;
      userData.lastCompletedStage = defaultUserData.lastCompletedStage;
      userData.showDebugStats = defaultUserData.showDebugStats;
      userData.useSound = defaultUserData.useSound;

      PrintUserData ("Set user data to default");

      SaveUserData ();
    }

    [ContextMenu ("Save user data")]
    public void SaveUserData ()
    {
      string dataJSON = JsonUtility.ToJson(userData);
      
      Logger.LogList (
        _title: $"Saving user data",
        _message: dataJSON,
        this
      );

      GameGlobals.Instance.registry.playerPrefsReader.SetString (
        GameGlobals.Instance.registry.userDataKey,
        dataJSON
      );

      PrintUserData ("Saved user data");
    }

    public bool HasLanguage()
    {
      // check if language CSV loaded
      if (GameGlobals.Instance.registry.rosettaReader.rosettaList.Count == 0)
      {
        Logger.LogError (
          $"There are no languages in the CSV file!",
          this
        );
        return false;
      }

      if (GameGlobals.Instance.registry.rosettaReader.rosettaList [0].ContainsKey (userData.language))
      {
        return true;
      }

      Logger.LogWarningList (
        _title: $"Current language - {userData.language.Important ()} - is not contained in Rosetta file! ",
        _message: "Languages found: " + GameGlobals.Instance.registry.rosettaReader.rosettaList [0].PrintKeys (), 
        this
      );
      return false;
    }
#endregion
  }
}
