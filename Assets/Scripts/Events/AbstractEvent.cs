using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractEvent : AbstractScriptableObject
{
  public abstract void RunEvent (MonoBehaviour runner); 
}
