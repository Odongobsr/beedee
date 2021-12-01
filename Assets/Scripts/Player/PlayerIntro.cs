using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bee
{
  public class PlayerIntro : MonoBehaviour
  {
    public Block target;
    public float speed;
    public float startY;
    public float endY;

    void OnEnable ()
    {
      target.body.position = new Vector3 (
        x: 0,
        y: startY,
        z: 0
      );
    }

    void FixedUpdate ()
    {
      if (target.body.position.y < endY)
      {
        Vector2 desiredVelocity = new Vector2 ();

        desiredVelocity += new Vector2 (0, speed);
          // new Vector2 (0, GameGlobals.Instance.registry.globalSpeedMultiplier);
          // (Vector2) GameGlobals.Instance.registry.obstacleSpeed;

        target.body.velocity = desiredVelocity;
      }
      else
      {
        target.body.velocity = Vector2.zero;
        gameObject.SetActive (false);
      }
    }
  }
}
