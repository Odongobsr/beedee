using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.Assertions;
using UnityEngine.Audio;
using System.Text;

public class GameGlobals : ScriptableObject
{
  public Registry registry;

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
      registry = Resources.Load ("Registry") as Registry;
      // registry.Setup ();
    }
}
