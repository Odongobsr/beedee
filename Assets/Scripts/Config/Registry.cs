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
  [Header ("Gameplay")]
  /// <summary>
  /// How long do we wait before beginning gameplay
  /// </summary>
  public int introTime;
  
  [Header ("Obstacles")]
  [Range (0, 5)]
  public float obstacleWaitTime;
  public Vector2 obstacleSpeed;
  [Range (1, 5)]
  public int obstaclePoolSize;
  public List<BlockData> obstacleDataList = new List<BlockData> ();


  [Header ("References")]
  public List<BlockData> blocks = new List<BlockData> ();
  public List<Level> levels = new List<Level> ();

  void Awake ()
  {
  }

  public void Setup ()
  {
    Assert.IsTrue (obstacleDataList.Count > 0, "No obstacle data");

    for (int i = 0; i < obstacleDataList.Count; i++)
    {
      Assert.IsNotNull (obstacleDataList [i]);
    }

    Logger.Log ("Setup registry");
  }

  public float GetObstacleWaitTime ()
  {
    return obstacleWaitTime;
  }
}
