//* Morgan Finney
//* www.pdox.uk
//* Apr 21
//* For DES203 | Project Raptor | 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Raptor
{
    public class MenuCamera : MonoBehaviour
    {
        float originX, originZ;
        public float mouseX, mouseY;
        float targetX, targetZ;
        public float power = 0.1f, limit = 0.5f;

        private void Start()
        {
            originX = transform.position.x;
            originZ = transform.position.z;
        }


        private void LateUpdate()
        {
            mouseX = Input.mousePosition.x / Screen.width;
            mouseY = Input.mousePosition.y / Screen.height;

            mouseX -= 0.5f;
            mouseY -= 0.5f;

            mouseX = mouseX * 2;
            mouseY = mouseY * 2;


            targetX = transform.position.x + (mouseX * power);
            targetZ = transform.position.z + (mouseY * power);
            targetX = Mathf.Clamp(targetX, originX - limit, originX + limit);
            targetZ = Mathf.Clamp(targetZ, originZ - limit, originZ + limit);
            targetZ = Mathf.Clamp(targetZ, originZ - limit, originZ + limit);

            Vector3 target = new Vector3(targetX, transform.position.y, targetZ);
            transform.position = Vector3.Lerp(transform.position, target, 0.02f);
        }

    }
}