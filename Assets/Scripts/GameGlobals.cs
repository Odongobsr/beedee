using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.Assertions;
using UnityEngine.Audio;
using System.Text;

namespace Bee
{
  public class GameGlobals : ScriptableObject
  {
    public bool awake;
    public Player player;
    public Registry registry;
    public GameController gameController;
    public MainMenuController mainMenuController;
    public StateMachine stateMachine;
    public CoroutineRunner runner;
    public GameIntroPrompt gameIntroPrompt;
    public UIScreen playerButtonsUIScreen;
    public SpriteRendererController darkGroundSprite;
    public Transform transformHolder;

    private static GameGlobals _instance;
    public static GameGlobals Instance
    {
      get
      {
        if (null == _instance)
        {
          _instance = FindObjectOfType<GameGlobals> ();
        }
        if (null == _instance)
        {
          _instance = CreateInstance<GameGlobals> ();
          _instance.hideFlags = HideFlags.HideAndDontSave;
        }
        return _instance;
      }

      private set
      {
        _instance = value;
      }
    }

    /// <summary>
    /// Game time (value of each Time.deltaTime added up)
    /// </summary>
    public static float time 
    {
      get 
      {
        if (null != GameGlobals.Instance.stateMachine)
        {
          return GameGlobals.Instance.stateMachine.time;
        }
        else
        {
          return 0;
        }
      }
    }

    public void Awake()
    {
      awake = true;

      Logger.LogDivider ();
      Logger.Log ("GameGlobals awake", _color: "yellow");
      Logger.LogDivider ();

      registry = Resources.Load ("Registry") as Registry;
      registry.Setup ();
    }
  }
}
