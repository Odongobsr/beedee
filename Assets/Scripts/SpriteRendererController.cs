using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Bee
{
  public class SpriteRendererController : StateListener
  {
    public SpriteRenderer spriteRenderer;

    public override void CheckAssertions()
    {
      base.CheckAssertions();

      Assert.IsNotNull (spriteRenderer);
    }

    
    public void ChangeAlpha (float _diff = 0, float _time = 1)
    {
      StartCoroutine (ChangeAlphaCoroutine (_diff: _diff, _time: _time));
    }
    
    IEnumerator ChangeAlphaCoroutine(float _diff = 0, float _time = 1)
    {
      float _currentAlpha = spriteRenderer.color.a;
      float _finalAlpha = Mathf.Clamp (_currentAlpha + _diff, 0, 1);
      float t = 0;

      // if time is zero, set the alpha instantly
      if (_time == 0)
      {
        spriteRenderer.SetAlpha (_finalAlpha);
        t = 1; // this will skip the following while loop
      }
      
      while (t < 1)
      {
        t += Time.deltaTime / _time;
        spriteRenderer.SetAlpha (Mathf.Lerp(_currentAlpha, _finalAlpha, t));
        // Debug.Log (t);
        yield return new WaitForEndOfFrame();
      }
    }
  }
}