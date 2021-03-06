using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bee
{
  public class Block : AbstractPoolable
  {
    [Header ("Configuration")]
    public int xDir = 1;
    public int yDir = 1;
    public bool limitToScreenX;
    public Vector2 desiredVelocity;

    [Header ("References")]
    public Transform originalParent;
    public Rigidbody2D body;
    public Transform scripts;

    [Header ("Runtime only")]
    public List<AbstractVelocityModifier> velocityModifiers;
    public List<AbstractBlockDependent> dependents = new List<AbstractBlockDependent> ();

    public override void Awake()
    {
      base.Awake();

      originalParent = transform.parent;
    }
    
    public override  void Start()
    {
      base.Start ();
      
      if (null != scripts)
      {
        velocityModifiers = 
          new List<AbstractVelocityModifier> (scripts.GetComponentsInChildren<AbstractVelocityModifier> ());
      }
    }

    public override void MyFixedUpdate()
    {
      if (!isActive)
      {
        return;
      }
      
      base.MyFixedUpdate ();
      
      // if (GameGlobals.Instance.registry.paused)
      // {
      //   body.velocity = Vector2.zero;
      //   return;
      // }

      desiredVelocity = Vector2.zero;

      for (int i = 0; i < velocityModifiers.Count; i++)
      {
        desiredVelocity += velocityModifiers [i].ModifyVelocity (this);
      }

      if (limitToScreenX)
      {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        
        if (desiredVelocity.x < 0)
        {
          if(pos.x < 0.1) desiredVelocity.x = 0;
        }
        else
        if (desiredVelocity.x > 0)
        {
          if(pos.x > 0.9) desiredVelocity.x = 0;
        }
        // if(pos.y < 0.0) Logger.Log("I am below the camera's view.");
        // if(1.0 < pos.y) Logger.Log("I am above the camera's view.");
      }
      
      body.velocity = desiredVelocity; //* Time.deltaTime;
      xDir = (int) Mathf.Sign (body.velocity.x);
      yDir = (int) Mathf.Sign (body.velocity.y);
    }

    public override void Pause()
    {
      base.Pause();

      body.velocity = Vector2.zero;
    }

    public override void MyLateUpdate()
    {
      base.MyLateUpdate ();

      desiredVelocity = Vector2.zero;
    }
  }
}
