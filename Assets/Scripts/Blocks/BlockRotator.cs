using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bee
{
  public class BlockRotator : StateListener
  {
    public bool rotate;
    public float rotateChance = 0.5f;
    public float speed;
    public int dir;
    public Transform target;

    public override void OnEnable ()
    {
      base.OnEnable ();
      
      rotate = Random.value < rotateChance ? true : false;

      if (!rotate)
      {
        return;
      }

      dir = Random.value < rotateChance ? -1 : 1;
    }

    public override void MyFixedUpdate()
    {
      if (!isActive)
      {
        return;
      }
      
      base.MyFixedUpdate();

      target.Rotate (0, 0, speed * Time.deltaTime * dir, Space.Self);
    }
  }
}