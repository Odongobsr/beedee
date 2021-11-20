using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SpriteRendererExtensionMethods
{
  public static void SetAlpha (this SpriteRenderer renderer, float alpha = 1)
  {
    renderer.color = 
      new Color(renderer.color.r, renderer.color.g, renderer.color.b, alpha);
  }
}
