//* Morgan Finney
//* www.pdox.uk
//* Apr 21
//* For DES203 | Project Raptor | 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Raptor
{
    public class Stalactites : MonoBehaviour
    {
        public float down;
        bool doFall;
        Vector3 endPos;

        // Start is called before the first frame update
        void Start()
        {
            endPos = new Vector3(transform.position.x, transform.position.y - down, transform.position.z);
        }

        // Update is called once per frame
        void Update()
        {
            if(doFall)
            {
                transform.position = Vector3.Lerp(transform.position, endPos, 0.1f);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "RockBoi")
            {
                doFall = true;
            }
        }
    }
}
