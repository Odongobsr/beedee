using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Assertions;
using UnityEngine.Events;

namespace Bee
{
  [CreateAssetMenu (
    fileName="Rosetta Reader",
    menuName="Language/Rosetta Reader"
  )]
  public class RosettaReader : AbstractScriptableObject
  {
    [Header ("References")]
    public TextAsset rosettaCSV;
    // Dictionary<string, string> rosettaDict =
        // new Dictionary<string, string>();

    [Header ("Runtime Only")]
    public DataCollection rosetta;

    public List<Dictionary<string, string>> rosettaList;

    public static UnityAction onChangeLanguage;

    void OnEnable ()
    {
      rosetta = new DataCollection ();;
      rosettaList = new List<Dictionary<string, string>> ();
    }
    
    public override void CheckAssertions()
    {
      base.CheckAssertions();

      Assert.IsNotNull (rosettaCSV);
    }

    [ContextMenu ("Load")]
    public bool Load()
    {
      string language = GameGlobals.Instance.registry.userDataReader.userData.language;

      Logger.Log (
        $"Load rosetta CSV",
        this
      );

      rosettaList = new List<Dictionary<string, string>>();

      rosettaList = CSVReader.Read(rosettaCSV);

      return true;
    }

    public bool UpdateLanguage ()
    {
      // check if currently selected language is valid
      if (!GameGlobals.Instance.registry.userDataReader.HasLanguage ())
      {
        // choose first column as default language
        ChooseDefaultLanguage ();
        // return false;
      }

      Logger.Log (
        $"Selected language - {GameGlobals.Instance.registry.userDataReader.userData.language.Important ()}",
        GameGlobals.Instance.registry.userDataReader
      );

      // Debug.Log (rosettaCSV);
      rosetta.Clear ();

      for (int i = 0; i < rosettaList.Count; i++)
      {
        rosetta.Add(
                _key: rosettaList[i]["name"],
                _value: rosettaList[i][GameGlobals.Instance.registry.userDataReader.userData.language]
            );
      }

      onChangeLanguage?.Invoke ();

      return true;
    }

    public string GetKey (string key) 
    {
      if (!rosetta.ContainsKey (key)) {
        Logger.LogWarning ($"{key.Important ()} not found in rosetta file");
        return "";
      }

      return rosetta.GetValue (key);
    } 

    public string GetKey (RosettaKey key) 
    {
      return GetKey (key.ToString ());
    }

    public RosettaKey GetRosettaKey (string key)
    {
      Array keys = System.Enum.GetValues (typeof (RosettaKey));

      for (int i = 0; i < keys.Length; i++)
      {
        string str = keys.GetValue (i).ToString ();
        // Logger.Log (
        //   $"Check key {str.Important()}",
        //   this
        // );
        if (0 == string.Compare (str, key))
        {
          return (RosettaKey) keys.GetValue (i);
        }
      }

      return RosettaKey.NULL;
    }
    
    /// <summary>
    /// Choose first column and set it as language
    /// </summary>
    void ChooseDefaultLanguage ()
    {
      foreach (var key in GameGlobals.Instance.registry.rosettaReader.rosettaList [0].Keys)
      {
        // skip name column
        if (0 == string.Compare (key, "name"))
        {
          // Logger.Log (
          //   $"Skipping CSV column - {key.Important ()}",
          //   this
          // );
          continue;
        }

        GameGlobals.Instance.registry.userDataReader.userData.language = key;

        Logger.Log (
          $"Default language: {GameGlobals.Instance.registry.userDataReader.userData.language.Important ()}",
          this
        );
        break;
      }
    }
  }
}