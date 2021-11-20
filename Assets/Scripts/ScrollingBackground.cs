using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;

namespace Bee
{
  public class ScrollingBackground : StateListener {

    [Header ("Configuration")]
    public float scrollSpeed = .1f;
    public SpriteRenderer spriteRenderer;
    // public Renderer rend;

    [Header ("Runtime only")]
    public float yOffset;
    public float yStart = 0;
    public float yStop = 0;
    public float offset;

    // Use this for initialization
    [ContextMenu ("Start")]
    public override void Start () 
    {
      base.Start ();

      Assert.IsNotNull (spriteRenderer);

      transform.position = new Vector3 (
        transform.position.x,
        GetYStart () + (spriteRenderer.bounds.size.y * yOffset),
        transform.position.z
      );
    }

    // Update is called once per frame
    public override void MyFixedUpdate () 
    {
      if (!isActive)
      {
        return;
      }
      
      base.MyFixedUpdate ();

      // Time.time is time since the game began, vs. deltaTime, which is time since last frame
      // float offset = Time.time * scrollSpeed;
      
      offset = Time.deltaTime * scrollSpeed * GameGlobals.Instance.registry.GetGlobalSpeed ();

      // // texture offsets shift how the texture is drawn onto the 3D object, skewing its
      // // UV coordinates; this results in a scrolling effect when applied on one axis
      //     rend.material.SetTextureOffset("_MainTex", new Vector2(0, offset));

      // // shown out of curiosity, in case this texture had an associated bump map
      // rend.material.SetTextureOffset("_BumpMap", new Vector2(0, offset));

      transform.position -= new Vector3 (0, offset); 

      if (transform.position.y <= GetYStop ())
      {
        transform.position = new Vector3 (
          transform.position.x,
          transform.position.y + spriteRenderer.bounds.size.y * 2,
          transform.position.z
        );
      }
    }

    float GetYStart ()
    {
      Vector3 pos = Camera.main.ViewportToWorldPoint (new Vector3 (0, 1, 0));

      yStart = pos.y;

      return yStart;
    }

    float GetYStop ()
    {
      Vector3 pos = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, 0));

      yStop = pos.y;

      return yStop;
    }
  }
}