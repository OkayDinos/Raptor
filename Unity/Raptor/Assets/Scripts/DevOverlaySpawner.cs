//* Morgan Finney
//* www.pdox.uk
//* Feb 21
//* For DES203 | Project Raptor | Spawns The Dev Overlay

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Raptor.DevHelper
{
    public class DevOverlaySpawner : MonoBehaviour
    {
        public GameObject devOverlayPrefab; //* Referance to the Dev Overlay Prefab

        void Start()
        {
            //* Spawns the DevOverlay if the game is being played in editor or is marked as a dev build.
            if (Debug.isDebugBuild == true || Application.isEditor == true)
            {
                Instantiate(devOverlayPrefab, transform.position, transform.rotation);
            }
        }
    }
}