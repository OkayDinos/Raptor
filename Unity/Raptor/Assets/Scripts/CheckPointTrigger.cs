//* Morgan Finney
//* www.pdox.uk
//* Apr 21
//* For DES203 | Project Raptor | 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Raptor
{
    public class CheckPointTrigger : MonoBehaviour
    {
        public int myID = 0;

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player" && PlayerPrefs.GetInt("CheckPoint") < myID)
            {
                PlayerPrefs.SetInt("CheckPoint", myID);
            }
        }

        public int GetID()
        {
            return myID;
        }
    }
}
