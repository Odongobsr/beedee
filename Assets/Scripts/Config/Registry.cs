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
  [Range (0.5f, 2)]
  public float globalSpeedMultiplier;
  [Range (1, 5)]
  public float playerMoveSpeed = 3;

  [Header ("Input")]
  public bool useTouchInput;

  [Header ("Variables")]
  public FloatVariable obstacleWaitTime;
  
  [Header ("Obstacles")]
  public Vector2 obstacleSpeed;
  [Range (1, 5)]
  public int obstaclePoolSize;
  [Range (1, 3)]
  public float doubleObstacleGapMin;
  [Range (1, 3)]
  public float doubleObstacleGapMax;
  [Range (0, 5)]
  public float doubleObstacleXOffset;
  public List<BlockData> obstacleDataList = new List<BlockData> ();

  [Header ("References")]
  public List<BlockData> blocks = new List<BlockData> ();
  public List<Level> levels = new List<Level> ();


  [Header ("Tags")]
  public string obstacleTag;
  
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

    Assert.IsNotNull (obstacleWaitTime);

    Logger.Log ("Setup registry");
  }

  public List<DataObject> GetObstacleDataObjects ()
  {
    List<DataObject> obstacles = new List<DataObject> ();
    for (int i = 0; i < obstacleDataList.Count; i++)
    {
      DataObject obj = obstacleDataList [i];
      // obj.name = obstacleDataList [i].name;
      obstacles.Add (obj);
    }

    return obstacles;
  }

  public override void OnValidate()
  {
    base.OnValidate();

    if (doubleObstacleGapMax < doubleObstacleGapMin)
    {
      doubleObstacleGapMax = doubleObstacleGapMin;
    }
  }
}
