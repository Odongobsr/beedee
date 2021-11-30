using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bee
{
    public class SetAsTransformHolder : MonoBehaviour
    {
        void Awake ()
        {
          GameGlobals.Instance.transformHolder = transform;
        }
    }
}
