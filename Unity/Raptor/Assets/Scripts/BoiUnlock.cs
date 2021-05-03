//* Morgan Finney
//* www.pdox.uk
//* Apr 21
//* For DES203 | Project Raptor | 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Raptor
{
    public class BoiUnlock : MonoBehaviour
    {
        public GameObject player;
        public Raptor.Player.Magic.SpellSelect spellManager;
        public string toUnlock;

        void Start()
        {
            SetUp();
        }

        void SetUp()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                spellManager = player.GetComponent<Raptor.Player.Magic.SpellSelect>();
            }
        }

        private void Update()
        {
            if (player == null)
            {
                SetUp();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                spellManager.UnlockSpell(toUnlock);
                GameObject.Destroy(this.gameObject);
            }
        }


    }
}