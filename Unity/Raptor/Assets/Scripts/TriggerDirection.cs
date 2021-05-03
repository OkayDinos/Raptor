//* Morgan Finney
//* www.pdox.uk
//* Feb 21
//* For DES203 | Project Raptor | Sets player and camera rotation when triggered

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Raptor.Trigger
{
    public class TriggerDirection : MonoBehaviour
    {
        public GameObject player;
        public Raptor.Player.PlayerRotate playerRotScript;
        public Raptor.Player.PlayerCamera playerCameraScript;
        public bool isVillage = true, isX = true, isPositive = true;
        public float villageRot;

        void Start()
        {
            Setup();
        }

        void Setup()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                playerRotScript = player.GetComponent<Raptor.Player.PlayerRotate>();
                playerCameraScript = player.GetComponent<Raptor.Player.PlayerCamera>();
            }
        }

        private void Update()
        {
            if (player == null)
            {
                Setup();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player" && player != null)
            {
                playerCameraScript.POST(isVillage, isX, isPositive, villageRot);
                playerRotScript.POST(isVillage, isX, isPositive, villageRot);
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.tag == "Player" && player != null)
            {
                playerCameraScript.POST(isVillage, isX, isPositive, villageRot);
                playerRotScript.POST(isVillage, isX, isPositive, villageRot);
            }
        }

    }
}