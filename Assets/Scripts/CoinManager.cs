using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bee
{
    public class CoinManager : StateListener
    {
#region mono functions
      public override void Awake ()
      {
        base.Awake ();

        // GameGlobals.Instance.coinManager = this;
      }
#endregion

#region public functions
      public void CollectCoin (GameObject coin)
      {
          coin.gameObject.SetActive (false);
          GameGlobals.Instance.audioManager.PlayFX (GameGlobals.Instance.registry.audioRegistry.fx_coin);
          GameGlobals.Instance.registry.score += 1;
      }
#endregion
    }
}
