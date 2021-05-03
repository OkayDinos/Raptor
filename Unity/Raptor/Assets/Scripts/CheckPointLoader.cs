//* Morgan Finney
//* www.pdox.uk
//* Apr 21
//* For DES203 | Project Raptor | 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Raptor
{
    public class CheckPointLoader : MonoBehaviour
    {
        public GameObject playerPrefab;
        public GameObject[] respawnPoints;
        public Transform spawnTransform;

        void Start()
        {
            respawnPoints = GameObject.FindGameObjectsWithTag("CheckPoint");

            if (PlayerPrefs.HasKey("CheckPoint"))
            {
                SpawnPlayer();
            }
            else
            {
                PlayerPrefs.SetInt("CheckPoint", 0);
                SpawnPlayer();
            }
        }

        public void SpawnPlayer()
        {
            
            foreach (GameObject respawnPoint in respawnPoints)
            {
                if (respawnPoint.transform.Find("Trigger").GetComponent<Raptor.CheckPointTrigger>().GetID() == PlayerPrefs.GetInt("CheckPoint"))
                {
                    spawnTransform = respawnPoint.transform.Find("SpawnPoint");
                }
            }
            Instantiate(playerPrefab, spawnTransform.position, Quaternion.identity);
        }
    }
}