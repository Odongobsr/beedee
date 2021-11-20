using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Assertions;

namespace Bee
{
  [CreateAssetMenu (
    fileName = "Registry",
    menuName = "Registry"
  )]
  public class Registry : AbstractScriptableObject
  {
    [Header ("Gameplay")]
    public WorldState worldState;
    public bool paused;
    public bool debugMode;
    public bool hasShownIntroCutscene;
    
    /// <summary>
    /// How long do we wait before beginning gameplay
    /// </summary>
    public int introTime;
    [Range (0.5f, 3)]
    public float globalSpeedMultiplier;
    [Range (1, 5)]
    public float playerMoveSpeed = 3;
    [Range (1, 5)]
    public float deathTimeout = 1;

    [Range (1, 7)]
    public float cutsceneFrameTime;
    [Range (0, 3)]
    public float defaultFadeTime;
    /// <summary>
    /// How much lighter does the ground get when BeeDee lands on a flower?
    /// </summary>
    [Range (-1, 1)]
    public float groundLightenValue;

    /// <summary>
    /// How much time does it take to lighten the ground get when BeeDee lands on a flower?
    /// </summary>
    [Range (0, 5)]
    public float groundLightenTime;

    [Header ("States")]
    public List<AbstractState> states;

    [Header ("Input")]
    public bool useTouchInput;

    [Header ("Variables")]
    public FloatVariable obstacleWaitTime;
    public FloatVariable flowerWaitTime;
    
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
    [Header ("Flowers")]
    [Range (1, 40)]
    public int flowerInterval;  
    [Range (1, 20)]
    public int flowerPoolSize;  
    public List<BlockData> flowerDataList = new List<BlockData> ();

    [Header ("References")]
    public List<BlockData> blocks = new List<BlockData> ();
    public List<Level> levels = new List<Level> ();


    [Header ("Tags")]
    public string obstacleTag;
    public string flowerTag;
    public string playerTag;

    [Header ("UI")]
    public List<StyleAsset> styles;
    
    void Awake ()
    {
    }

    public void Setup ()
    {
      Assert.IsTrue (obstacleDataList.Count > 0, "No obstacle data");
      Assert.IsTrue (styles.Count > 0, "No UI styles");
      Assert.IsTrue (states.Count > 0, "No states");

      for (int i = 0; i < obstacleDataList.Count; i++)
      {
        Assert.IsNotNull (obstacleDataList [i]);
      }

      Assert.IsNotNull (obstacleWaitTime);

      Logger.Log ("Setup registry");
    }

    public float GetGlobalSpeed ()
    {
      // if (paused)
      // {
      //   return 0;
      // }
      // else
      // {
        return globalSpeedMultiplier;
      // }
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

    public List<DataObject> GetFlowerDataObjects ()
    {
      List<DataObject> flowers = new List<DataObject> ();
      for (int i = 0; i < flowerDataList.Count; i++)
      {
        DataObject obj = flowerDataList [i];
        // obj.name = obstacleDataList [i].name;
        flowers.Add (obj);
      }

      return flowers;
    }

    public AbstractState GetState(State _state)
    {
      return states.Find (x => x.state == _state);
    }

    public StyleAsset GetStyle (StyleName _name)
    {
      StyleAsset style = styles.Find (x => x.styleName == _name);

      if (null != style)
      {
        return style;
      }

      style = styles [0];

      Logger.LogWarning (
        $"{_name} - style not found. Returning default style {style}",
        style
      );

      return style;
    }
    public void SetWorldState (WorldState _worldState)
    {
      worldState = _worldState;
      Logger.Log (
        $"Set world state to {worldState}",
        this,
        _color: "yellow"
      );
    }


    public override void OnValidate()
    {
      base.OnValidate();

      if (doubleObstacleGapMax < doubleObstacleGapMin)
      {
        doubleObstacleGapMax = doubleObstacleGapMin;
      }
    }

    public void Pause ()
    {
      paused = true;
    }
    public void UnPause ()
    {
      paused = false;
    }
  }
}