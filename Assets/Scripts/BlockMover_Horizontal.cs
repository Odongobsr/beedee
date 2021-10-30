using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMover_Horizontal : MonoBehaviour
{
  public float speed;
  public bool bounce;
  public Block block;

  void Start()
  {
    block.xDir = 1;     
  }

  void FixedUpdate()
  {
    block.desiredVelocity.x += speed * block.xDir;

    if (bounce)
    {
      Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

      if (block.desiredVelocity.x > 0)
      {
        if (pos.x > 1.0)
        {
         block.desiredVelocity.x *= -1; 
        }
      }
      else
      {
        if (pos.x < 1.0)
        {
          block.desiredVelocity *= -1;
        }
      }
    }
  }
}
