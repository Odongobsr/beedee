using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (
  fileName = "Event - Destroy me",
  menuName = "Events/Destroy me"
)]
public class Event_DestroyMe : AbstractEvent
{
  public override void RunEvent(MonoBehaviour runner = null)
  {
    Destroy (runner.gameObject);
  }
}
