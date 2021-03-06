using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStartPosition : MonoBehaviour
{
  public bool topOfScreen;

  void OnEnable()
  {
    if (topOfScreen)
    {
      Vector3 pos = Camera.main.ViewportToWorldPoint (new Vector2 (0.5f, 1.25f));
      pos.x = transform.position.x;
      // dont start at camera's z position
      pos.z = transform.position.z;

      transform.position = pos;
    }
  }
}
