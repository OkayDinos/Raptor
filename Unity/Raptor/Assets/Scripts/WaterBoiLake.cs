//* Morgan Finney
//* www.pdox.uk
//* Apr 21
//* For DES203 | Project Raptor | 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Raptor.Magic
{
    public class WaterBoiLake : MonoBehaviour
    {
        public GameObject bottom, top, waterColider, waterRender;
        [Range(0.0f, 100.0f)]
        public float fillPercent = 100;
        public float dist;

        private void Update()
        {
            waterColider.transform.position = bottom.transform.position;

            dist = top.transform.position.y - bottom.transform.position.y;

            waterColider.transform.localScale = new Vector3(1, dist, 1);

            waterRender.transform.localPosition = new Vector3(0, (dist * (fillPercent / 99)) + 0.01f, 0);
        }
    }
}