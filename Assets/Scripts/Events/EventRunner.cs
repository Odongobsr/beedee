using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventRunner : MonoBehaviour
{
  public List<AbstractEvent> events = new List<AbstractEvent> ();

  public void RunAllEvents ()
  {
    for (int e = 0; e < events.Count; e++)
    {
      events [e].RunEvent (runner: this);
    }
  }
}
