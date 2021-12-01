using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Bee
{
    public class ShakeTransform : StateListener
    {
#region public variables
      [Header ("Configuration")]
      public bool isShaking;
      public float shakeStartTime;
      public float shakeDuration;
      public float shakeStrength;
      public bool shakeX;
      public bool shakeY;

      [Header ("References")]
      public Transform target;

      [Header ("Runtime Only")]
      public Vector2 originalPosition;
#endregion


#region public functions
      public override void CheckAssertions()
      {
        base.CheckAssertions ();
        
        Assert.IsNotNull (target);
      }
       
      public void Shake (float _duration = 1, float _strength = 1, bool _shakeX = false, bool _shakeY = false)
      {
        if (isShaking)
        {
          Logger.LogWarning (
            $"{target.GetName ()} is already shaking!",
            this
          );
          return;
        }

        isShaking = true;
        shakeDuration = _duration;
        shakeStrength = _strength;
        shakeX = _shakeX;
        shakeY = _shakeY;
        originalPosition = target.position;
        shakeStartTime = GameGlobals.time;

        Logger.Log (
          $"{target.GetName ()} - start shaking!",
          this
        );
      }

      public override void MyLateUpdate ()
      {
        base.MyLateUpdate ();

        if (isShaking)
        {
          if (GameGlobals.time > shakeStartTime + shakeDuration)
          {
            StopShaking ();
          }

          float offsetX = Random.Range (-shakeStrength, shakeStrength);
          float offsetY = Random.Range (-shakeStrength, shakeStrength);

          Vector2 pos = originalPosition;

          if (shakeX)
          {
            pos.x = offsetX;
          }
          if (shakeY)
          {
            pos.y = offsetY;
          }

          target.SetXYPosition (pos); 
        }
      }

      public void StopShaking ()
      {
        isShaking = false;
        target.SetXYPosition (originalPosition);

        Logger.Log (
          $"{target.GetName ()} - stop shaking!",
          this
        );
      }
#endregion
    }
}
