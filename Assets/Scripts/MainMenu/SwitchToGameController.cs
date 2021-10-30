using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class SwitchToGameController : MonoBehaviour
{
  [Header ("References")]
  public GameObject switcher;
  
  [Header ("Runtime only")]
  public bool switchingToGameScene;

  void Awake()
  {
    Assert.IsNotNull (switcher);    
  }

  void Start()
  {
    switcher.gameObject.SetActive (false);
  }

  void Update()
  {
    if (!switchingToGameScene)
    {
      // detect user input
      if (Input.GetMouseButtonDown (0) || Input.GetKeyDown (KeyCode.Space))    
      {
        SwitchToGameScene ();
      }
    }
  }

  void SwitchToGameScene ()
  {
    Logger.Log ("Try switch to game scene");
    switchingToGameScene = true;

    switcher.gameObject.SetActive (true);
  }
}
