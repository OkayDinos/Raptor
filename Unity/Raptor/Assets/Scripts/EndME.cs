//* Morgan Finney
//* www.pdox.uk
//* Apr 21
//* For DES203 | Project Raptor | 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Raptor
{
    public class EndME : MonoBehaviour
    {
        public GameObject MenuSelectPREFFAB;

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                StartCoroutine(Timer());
            }
        }


        IEnumerator Timer()
        {
            yield return new WaitForSeconds(1f);
            GameObject loader = Instantiate(MenuSelectPREFFAB);
            loader.GetComponent<Raptor.MenuSelect>().POSTMenuToLoad("Credits", "", "");
        }
    }
}
