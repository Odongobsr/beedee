using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bee
{
  public class SubscribeToStates : MonoBehaviour
  {
    public List<State> states;
    public StateListener listener;

    void Awake ()
    {
      if (listener)
      {
        listener.SetActiveStates (states);
      }
    }
  }
}
