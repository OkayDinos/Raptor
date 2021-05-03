//* Morgan Finney
//* www.pdox.uk
//* Feb 21
//* For DES203 | Project Raptor | Hide Building walls when entering a building

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Raptor.Tigger
{
    public class VillageBuildingHide : MonoBehaviour
    {
        bool hidden = false; //* Current State for Hidden parts
        public GameObject[] buildingParts; //* List of parts that should be hidden

        //* Hides all parts of a building when entering the trigger;
        private void OnTriggerEnter(Collider other)
        {
            if (hidden == false && other.tag == "Player")
            {
                for (int i = 0; i < buildingParts.Length; i++)
                    buildingParts[i].GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly; //* Chganges the shadow mode, this means only the mesh is hidden, not the shadows and the collision too.

                hidden = true;
            }
        }

        //* Unhides All parts of the building;
        private void OnTriggerExit(Collider other)
        {
            if (hidden == true && other.tag == "Player")
            {
                for (int i = 0; i < buildingParts.Length; i++)
                    buildingParts[i].GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On; //* Chganges the shadow mode, this means only the mesh is hidden, not the shadows and the collision too.

                hidden = false;
            }
        }
    }
}