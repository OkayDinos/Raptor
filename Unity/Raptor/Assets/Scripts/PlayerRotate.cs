//* Morgan Finney
//* www.pdox.uk
//* Feb 21
//* For DES203 | Project Raptor | RotatesThePlayer

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Raptor.Player
{
    public class PlayerRotate : MonoBehaviour
    {
        bool isVillage, isX, isPositive;
        float villageRot;

        // Update is called once per frame
        void Update()
        {
            if (isVillage == true)
                SetRotation(villageRot);
            else if (isX == true && isPositive == true)
                SetRotation(0);
            else if (isX == true && isPositive == false)
                SetRotation(180);
            else if (isX == false && isPositive == true)
                SetRotation(270);
            else if (isX == false && isPositive == false)
                SetRotation(90);
        }

        void SetRotation(float rot)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, rot, 0), Time.deltaTime);
        }

        public void POST(bool village, bool x, bool pos, float rot)
        {
            isVillage = village;
            isX = x;
            isPositive = pos;
            villageRot = rot;
        }

        public float REQUESTRot()
        {
            return villageRot;
        }
    }
}