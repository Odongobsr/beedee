using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bee
{
  public class ActivateObjectOnPlayerDeath : MonoBehaviour
  {
    public bool activate;
    public GameObject obj;

    void Start ()
    {
      if (obj)
      {
        obj.SetActive (!activate);
      }
    }

    void OnEnable()
    {
        if (obj)
        {
          Player.onPlayerDeath += Activate;
        }
    }
    void OnDisable()
    {
        if (obj)
        {
          Player.onPlayerDeath -= Activate;
        }
    }

    void Activate ()
    {
      if (obj)
      {
        obj.SetActive (activate);
      }
    }
  }
}
