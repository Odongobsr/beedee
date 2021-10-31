using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Block
{
  public InputHandler inputHandler;

  void OnTriggerEnter2D(Collider2D other)
  {
    Logger.Log ($"Player has hit {other.attachedRigidbody.tag} - {other.attachedRigidbody.name}", other.attachedRigidbody);
  }
}
