using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bee
{
  public class BlockDestroyer : MonoBehaviour
  {
    void OnTriggerEnter2D(Collider2D other)
    {
      if (other.CompareTag ("Destroy"))
      {
        gameObject.SetActive (false);
      }       
    }
  }
}