using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bee
{
  /// <summary>
  /// Dont destroy when swithcing scenes
  /// </summary>
  public class DontDestroyOnLoad : MonoBehaviour
  {
    public new string tag;

    void Awake()
    {
      GameObject[] objs = GameObject.FindGameObjectsWithTag(tag);

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad (this.gameObject);
    }
  }
}