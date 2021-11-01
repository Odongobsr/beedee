using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustStartPosition : MonoBehaviour
{
  public Vector3 offset;

  void OnEnable()
  {
    // transform.localPosition = Vector3.zero;
    transform.position += offset;
  }
}
