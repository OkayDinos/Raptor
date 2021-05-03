//* Morgan Finney
//* www.pdox.uk
//* Apr 21
//* For DES203 | Project Raptor | 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Raptor
{
    public class KillPlayer : MonoBehaviour
    {
        public float timeToKill = 0.0f;
        bool sentToDeath = false;

        private void OnTriggerEnter(Collider other)
        {
            if (!sentToDeath && other.tag == "Player")
            {
                StartCoroutine(WaitToKill());
            }
        }

        IEnumerator WaitToKill()
        {
            sentToDeath = true;
            yield return new WaitForSeconds(timeToKill);
            GameObject.Destroy(GameObject.FindGameObjectWithTag("Player"));
            yield return new WaitForSeconds(1f);
            GameObject.Find("/Player+User/CheckPointLoader").GetComponent<Raptor.CheckPointLoader>().SpawnPlayer();
            sentToDeath = false;
        }
    }
}
