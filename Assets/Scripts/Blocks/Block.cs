using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : AbstractGameObject
{
  public BlockData prefab;

  [Header ("Configuration")]
  public int xDir = 1;
  public int yDir = 1;
  public bool limitToScreenX;
  public Vector2 desiredVelocity;

  [Header ("References")]
  public Rigidbody2D body;

  [Header ("Runtime only")]
  public List<AbstractBlockDependent> dependents = new List<AbstractBlockDependent> ();

  public void FixedUpdate()
  {
      if (limitToScreenX)
      {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        
        if (desiredVelocity.x < 0)
        {
          if(pos.x < 0.0) desiredVelocity.x = 0;
        }
        else
        if (desiredVelocity.x > 0)
        {
          if(pos.x > 1.0) desiredVelocity.x = 0;
        }
        // if(pos.y < 0.0) Logger.Log("I am below the camera's view.");
        // if(1.0 < pos.y) Logger.Log("I am above the camera's view.");
      }
      body.velocity = desiredVelocity; //* Time.deltaTime;
      xDir = (int) Mathf.Sign (body.velocity.x);
      yDir = (int) Mathf.Sign (body.velocity.y);
  }
}
