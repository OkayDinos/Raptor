//* Morgan Finney
//* www.pdox.uk
//* Apr 21
//* For DES203 | Project Raptor | 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Raptor.Player
{
    public class SphereCastTest : MonoBehaviour
    {
        public float radius;
        public Vector3 offset;
        public Collider[] hitColliders;


        void Update()
        {
           hitColliders = Physics.OverlapSphere(transform.position + offset, radius);
            
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position + offset, radius);
        }
    }
}
