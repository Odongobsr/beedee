using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Bee
{
  public class ParticleBurst : StateListener
  {
    public int particleCount;
    public ParticleSystem particle;

    public override void CheckAssertions()
    {
      base.CheckAssertions();

      Assert.IsNotNull (particle);
    }

    public override void OnEnable ()
    {
      base.OnEnable ();
      
      Emit ();
    }

    [ContextMenu ("Emit")]
    void Emit()
    {
      particle.Emit (particleCount);
    }
  }
}
