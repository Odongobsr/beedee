using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Bee
{
  public class DoubleObstacle : AbstractGameComponent
  {
    public Rigidbody2D leftObstacle;
    public Rigidbody2D rightObstacle;

    public override void CheckAssertions()
    {
      base.CheckAssertions ();

      Assert.IsNotNull (leftObstacle);
      Assert.IsNotNull (rightObstacle);
    }

    public override void OnEnable()
    {
      base.OnEnable ();

      SetupDoubleObstacle ();
    }

    [ContextMenu ("Setup double obstacle")]
    void SetupDoubleObstacle ()
    {
      // position obstacles at center of screen
      List<Collider2D> colliders = new List<Collider2D> ();

      Vector3 leftPos = leftObstacle.transform.position;
      if (leftObstacle.GetAttachedColliders (colliders) > 0)
      {
        leftPos.x = -colliders [0].bounds.size.x / 2;
      }
      Vector3 rightPos = rightObstacle.transform.position;
      if (rightObstacle.GetAttachedColliders (colliders) > 0)
      {
        rightPos.x = colliders [0].bounds.size.x / 2;
      }
      
      // insert gap between obstacles
      float gap = 
        Random.Range (
          minInclusive: GameGlobals.Instance.registry.doubleObstacleGapMin, 
          maxInclusive: GameGlobals.Instance.registry.doubleObstacleGapMax
        ); 

      // change obstacle position
      leftPos += new Vector3 (x: -gap, y: 0);
      leftObstacle.transform.position = leftPos;
      rightPos += new Vector3 (x: gap, y: 0);
      rightObstacle.transform.position = rightPos;

      // adjust x offset
      // float offset = 
      //   Random.Range (
      //     -GameGlobals.Instance.registry.doubleObstacleXOffset, 
      //     GameGlobals.Instance.registry.doubleObstacleXOffset
      //   );

      // transform.position = new Vector3 (offset, 0, 0);

      // Logger.Log ($"Left obstacle position: {leftPos}", leftObstacle);
      // Logger.Log ($"Right obstacle position: {rightPos}", rightObstacle);
      // Logger.Log ($"Gap {gap}", this);
    }
  }
}
