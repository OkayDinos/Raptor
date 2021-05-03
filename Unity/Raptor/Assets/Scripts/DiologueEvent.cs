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
    public class DiologueEvent : MonoBehaviour
    {
        public UnityEvent nextEvent;
        public bool triggered, timed, inUse;
        public float time;

        public void DiologueStart()
        {
            inUse = true;
            this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            this.gameObject.transform.Find("Text").gameObject.SetActive(true);

            if (timed)
                StartCoroutine(DiolougeTimer());
        }

        public void DiologueEnd()
        {
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            this.gameObject.transform.Find("Text").gameObject.SetActive(false);

            if (nextEvent != null)
                nextEvent.Invoke();
        }

        public void Enter()
        {
            if(triggered == true && inUse == false)
            {
                DiologueStart();
            }
        }

        public void Exit()
        {
            if (timed == false && inUse == true)
            {
                DiologueEnd();
            }
        }

        IEnumerator DiolougeTimer()
        {
            yield return new WaitForSeconds(time);
            DiologueEnd();
        }

    }
}
