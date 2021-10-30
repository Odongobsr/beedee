using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
  public int xDir = 1;
  public int yDir = 1;
  public BlockData prefab;
  public bool limitToScreenX;
  public Rigidbody2D body;
  public Vector2 desiredVelocity;

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
        // if(pos.y < 0.0) Debug.Log("I am below the camera's view.");
        // if(1.0 < pos.y) Debug.Log("I am above the camera's view.");
      }
      body.velocity = desiredVelocity; //* Time.deltaTime;
      xDir = (int) Mathf.Sign (body.velocity.x);
      yDir = (int) Mathf.Sign (body.velocity.y);
  }
}
