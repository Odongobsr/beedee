using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Bee
{
  [RequireComponent(typeof(RectTransform), typeof(CanvasGroup))]
  public class UIScreen : StateListener
  {
    public CanvasGroup canvasGroup;
    public RectTransform rectTransform;

    public override void CheckAssertions()
    {
      base.CheckAssertions();

      Assert.IsNotNull (canvasGroup);
      Assert.IsNotNull (rectTransform);
    }

    public override void Awake ()
    {
      base.Awake ();
      
      if (null == canvasGroup)
      {
        canvasGroup = GetComponent<CanvasGroup> ();
      }
      if (null == rectTransform)
      {
        rectTransform = GetComponent<RectTransform> ();
      }
    }

    public override bool Enter()
    {
      if (!base.Enter()) return false;
      
      CenterOnScreen ();

      return true;
    }

    void CenterOnScreen ()
    {
      rectTransform.anchoredPosition = Vector3.zero;
    }

    public void Activate (float _time = 1)
    {
      StartCoroutine (FadeCoroutine (_finalAlpha: 1, _time: _time));
    }

    public void Deactivate (float _time = 1)
    {
      StartCoroutine (FadeCoroutine (_finalAlpha: 0, _time: _time));
    }
    
    IEnumerator FadeCoroutine(float _finalAlpha = 1, float _time = 1)
    {
      float currentAlpha = canvasGroup.alpha;
      float t = 0;

      // if time is zero, set the alpha instantly
      if (_time == 0)
      {
        canvasGroup.alpha = _finalAlpha;
        t = 1; // this will skip the following while loop
      }
      
      if (_finalAlpha > 0)
      {
        EnableInteractivity(); // UIScreen will be faded if not called here
      }
      else
      {
        DisableInteractivity();
      }
      
      while (t < 1)
      {
        t += Time.deltaTime / _time;
        canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, _finalAlpha, t);
        // Debug.Log (t);
        yield return new WaitForEndOfFrame();
      }

      if (canvasGroup.alpha > 0)
      {
        EnableInteractivity();
      }
    }

    void EnableInteractivity()
    {
      canvasGroup.blocksRaycasts = true;
      canvasGroup.interactable = true;
    }

    void DisableInteractivity()
    {
      canvasGroup.blocksRaycasts = false;
      canvasGroup.interactable = false;
    }

  }
}