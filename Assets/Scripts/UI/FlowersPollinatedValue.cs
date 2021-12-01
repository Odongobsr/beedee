using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Bee
{
  public class FlowersPollinatedValue : MonoBehaviour
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
      text.text = $"{GameGlobals.Instance.registry.rosettaReader.GetKey (RosettaKey.flowers_pollinated)}: <b>{GameGlobals.Instance.gameController.flowersPollinated} / {GameGlobals.Instance.registry.numberOfFlowers}</b>";
    }
  }
}
