using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateGameObject : MonoBehaviour
{
  public bool activate;
  public GameObject obj;

  void Start ()
  {
    if (obj)
    {
      obj.SetActive (activate);
    }
  }
}
