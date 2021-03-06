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
    public int score;
    public int numberOfFlowers;
    
    /// <summary>
    /// How long do we wait before beginning gameplay
    /// </summary>
    public int introTime;
    [Range (0.5f, 4)]
    public float minSpeedMultiplier;
    [Range (0.5f, 4)]
    public float maxSpeedMultiplier;
    [Range (0.5f, 4)]
    public float globalSpeedMultiplier;
    [Range (0, 1)]
    public float globalSpeedIncreaseStep = 0.25f;
  

    [Range (1, 5)]
    public float playerMoveSpeed = 3;
    [Range (1, 5)]
    public float deathTimeout = 1;
    /// <summary>
    /// How far does player move for new obstacle to be spanwed?
    /// </summary>
    [Range (1, 5)]
    public int spawnDistance;

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

    [Header ("Data")]
    [ReadOnly] public string userDataKey = "bee_userData";
    public PlayerPrefsReader playerPrefsReader;
    public UserDataReader userDataReader;
    public RosettaReader rosettaReader;
    public SceneLoader sceneLoader;
    public AudioRegistry audioRegistry;

    [Header ("States")]
    public List<AbstractState> states;

    [Header ("Input")]
    public bool useTouchInput;

    [Header ("Variables")]
    public FloatVariable obstacleWaitTime;
    public FloatVariable flowerWaitTime;
    public FloatVariable playerHealth;
    /// <summary>
    /// How long does player health get to zero?
    /// </summary>
    public float playerHealthTime = 15;
    
    [Header ("Obstacles")]
    // public Vector2 obstacleSpeed;
    [Range (1, 5)]
    public int obstaclePoolSize;
    [Range (1, 3)]
    public float doubleObstacleGapMin;
    [Range (1, 3)]
    public float doubleObstacleGapMax;
    [Range (0, 5)]
    public float doubleObstacleXOffset;

    [Header ("Flowers")]
    [Range (1, 40)]
    public int flowerInterval;  
    [Range (1, 20)]
    public int flowerPoolSize;  

    [Header ("References")]
    public List<ObjectPatternRules> patternRules; 


    [Header ("Tags")]
    public string obstacleTag;
    public string coinTag;
    public string flowerTag;
    public string playerTag;

    [Header ("UI")]
    [HideInInspector] internal string orangeColor = "#FFAA00";
    [HideInInspector] internal string lightredColor = "#f9615d";
    public UIToggle togglePrefab;
    public List<StyleAsset> styles;

// #if UNITY_EDITOR
    public void CheckGameComponents ()
    {
      List<AbstractGameComponent> gameObjects = 
        new List<AbstractGameComponent> (GameObject.FindObjectsOfType<AbstractGameComponent> ());

      if (!Application.isPlaying)
      {
        Logger.LogDivider ();
      }

      Logger.LogList (
        _title: $"Checking {gameObjects.Count} game components:",
        _message: $"{gameObjects.PrintMe ()}",
        null
      );

      for (int i = 0; i < gameObjects.Count; i++)
      {
        gameObjects [i].CheckAssertions ();
      }
    }

    [ContextMenu ("Check Assertions")]
    public override void CheckAssertions()
    {
      base.CheckAssertions ();

      CheckGameComponents ();
      
      Assert.IsNotNull (playerPrefsReader);
      playerPrefsReader.CheckAssertions ();
      Assert.IsNotNull (userDataReader);
      userDataReader.CheckAssertions ();
      Assert.IsNotNull (rosettaReader);
      rosettaReader.CheckAssertions ();
      Assert.IsNotNull (sceneLoader);
      sceneLoader.CheckAssertions ();
      Assert.IsNotNull (audioRegistry);
      audioRegistry.CheckAssertions ();

      Assert.IsFalse (patternRules.HasNull ());
      for (int i = 0; i < patternRules.Count; i++)
      {
        patternRules [i].CheckAssertions ();
      }

      Assert.IsTrue (styles.Count > 0);
      Assert.IsFalse (styles.HasNull ());
      Assert.IsTrue (states.Count > 0);
      Assert.IsFalse (states.HasNull ());

      Assert.IsNotNull (obstacleWaitTime);
      Assert.IsNotNull (playerHealth);
      Assert.IsNotNull (togglePrefab);
    }
     
// #endif
    
    void Awake ()
    {
    }

    public override void Setup ()
    {
      base.Setup ();
      
      Logger.LogBegin ("Setup registry");

      // check game components in scene + project
      CheckAssertions ();

      // load user data
      userDataReader.LoadUserData ();

      // load language file
      rosettaReader.Load ();

      // update language
      rosettaReader.UpdateLanguage ();

      Logger.LogEnd ("Setup registry");
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

    public void IncreaseGlobalSpeed ()
    {
      globalSpeedMultiplier = 
        Mathf.Clamp (
          value: globalSpeedMultiplier + globalSpeedIncreaseStep, 
          min: minSpeedMultiplier, 
          max: maxSpeedMultiplier
        );
      Logger.Log (
        $"Increase global speed: {globalSpeedMultiplier.ToString ().Important ()}",
        this
      );
    }
  }
}