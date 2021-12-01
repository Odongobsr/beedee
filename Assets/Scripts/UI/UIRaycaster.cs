using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Bee
{
  public class UIRaycaster : StateListener
  {
    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;

    public override void Start ()
    {
      base.Start ();

      GameGlobals.Instance.UIRaycaster = this;

      m_Raycaster = GetComponent<GraphicRaycaster> ();
      m_EventSystem = GetComponentInChildren<EventSystem> ();
    }

    public bool CheckIfUIObjectHasBeenHit (Vector2 _position)
    {
      // set up the new pointer event
      m_PointerEventData = new PointerEventData (m_EventSystem);

      // set the pointer event position
      m_PointerEventData.position = _position;

      // create a list of raycast results
      List<RaycastResult> __results = new List<RaycastResult> ();

      // Raycast using the graphics raycaster
      m_Raycaster.Raycast (m_PointerEventData, __results);

      // output name of gameobjects on the canvas that have been hit
      foreach (RaycastResult __result in __results)
      {
        Logger.Log (
          $"UI object hit {__result.gameObject.name}", 
          __result.gameObject
        );
        return true;
      }

      return false;
    }
  }
}
