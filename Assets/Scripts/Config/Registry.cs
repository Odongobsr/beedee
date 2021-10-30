using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Assertions;

[CreateAssetMenu (
  fileName = "Registry",
  menuName = "Registry"
)]
public class Registry : AbstractScriptableObject
{
  // [Header ("Configuration")]
  // public string mainMenuScene;
  // public string gameplayScene;
  
  [Header ("Obstacles")]
  public Vector2 obstacleSpeed;

  [Header ("References")]
  public List<BlockData> blocks = new List<BlockData> ();
  public List<Level> levels = new List<Level> ();

  void Awake ()
  {
    // Assert.IsNotNull (mainMenu);
    // Assert.IsNotNull (gameplay);
  }

  public void Setup ()
  {
    Logger.Log ("Setup registry");
  }
}
