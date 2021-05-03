//* Morgan Finney
//* www.pdox.uk
//* Apr 21
//* For DES203 | Project Raptor | 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Raptor
{
    public class CaveUnlock : MonoBehaviour
    {
        public GameObject stoperCollider, text1, text2;

        public void CaveLock()
        {
            stoperCollider.SetActive(false);
            text1.SetActive(false);
            text2.SetActive(true);
        }
    }
}
