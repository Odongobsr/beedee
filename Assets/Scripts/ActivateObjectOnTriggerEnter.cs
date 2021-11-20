using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bee
{
  public class ActivateObjectOnTriggerEnter : MonoBehaviour
  {    
    public GameObject obj;

    public void OnTriggerEnter2D(Collider2D other)
    {
      // has player hit obstacle?
      if (other.CompareTag (GameGlobals.Instance.registry.playerTag))
      {
        obj.SetActive (true);
      }
    }

    void OnEnable()
    {
      obj.SetActive (false);      
    }

    void OnDisable()
    {
      obj.SetActive (false);    
    }
  }
}