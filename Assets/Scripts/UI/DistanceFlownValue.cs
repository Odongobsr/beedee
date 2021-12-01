using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Bee
{
  public class DistanceFlownValue : MonoBehaviour
  {
    public Text text;

    void OnEnable ()
    {
      Player.onPlayerDeath += UpdateText;
    }

    void OnDisable ()
    {
      Player.onPlayerDeath -= UpdateText;
    }

    void UpdateText ()
    {
      switch (GameGlobals.Instance.registry.userDataReader.userData.language)
      {
        case "english":
          text.text = $"{GameGlobals.Instance.registry.rosettaReader.GetKey (RosettaKey.distance_flown)}: <b>{GameGlobals.Instance.gameController.globalYPosition.ToString ("0.0")} {GameGlobals.Instance.registry.rosettaReader.GetKey (RosettaKey.meters)}</b>";
          break; 

        case "swahili":
          text.text = $"{GameGlobals.Instance.registry.rosettaReader.GetKey (RosettaKey.distance_flown)}: <b>{GameGlobals.Instance.registry.rosettaReader.GetKey (RosettaKey.meters)} {GameGlobals.Instance.gameController.globalYPosition.ToString ("0.0")}</b>";
          break;
      }
    }
  }
}
