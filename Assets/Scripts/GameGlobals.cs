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
    public Player player;
    public Registry registry;
    public GameController gameController;
    public StateMachine stateMachine;

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

    public void Awake()
    {
      Logger.Log ("GameGlobals awake");

      registry = Resources.Load ("Registry") as Registry;
      registry.Setup ();
    }
  }
}
