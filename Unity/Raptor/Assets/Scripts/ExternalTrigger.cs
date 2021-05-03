//* Morgan Finney
//* www.pdox.uk
//* Apr 21
//* For DES203 | Project Raptor | 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Raptor
{
    public class ExternalTrigger : MonoBehaviour
    {
        public UnityEvent triggerEnterEvent, triggerExitEvent;

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
                triggerEnterEvent.Invoke();
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Player")
                triggerExitEvent.Invoke();
        }
    }
}
