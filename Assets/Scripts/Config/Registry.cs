using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (
  fileName = "Registry",
  menuName = "Registry"
)]
public class Registry : ScriptableObject
{
  public Vector2 obstacleSpeed;
  public List<BlockData> blocks = new List<BlockData> ();
  public List<Level> levels = new List<Level> ();
}
