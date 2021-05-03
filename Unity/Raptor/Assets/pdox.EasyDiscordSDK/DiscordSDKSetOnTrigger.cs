//* Morgan Finney
//* www.pdox.uk

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pdox.EasyDiscordSDK
{
    public class DiscordSDKSetOnTrigger : MonoBehaviour
    {
        [Header("Easy Discord SDK Controller")]
        [Tooltip("Refrance of main discord sdk controller")]
        public GameObject easyDiscordSDKController;
        [Tooltip("Refrance of main discord sdk controller script")]
        public pdox.EasyDiscordSDK.DiscordController easyDiscordSDKControllerScript;

        [Header("New Activitys to be passed to the manager")]
        [Tooltip("The New DiscordActivity Details [First Line in Discord]")]
        [SerializeField] public string details;
        [Tooltip("The New DiscordActivity State [Second Line in Discord]")]
        [SerializeField] public string state;

        void Start()
        {
            easyDiscordSDKController = GameObject.FindGameObjectWithTag("EasyDiscordSDK");
            if (easyDiscordSDKController != null)
            {
                easyDiscordSDKControllerScript = easyDiscordSDKController.GetComponent<pdox.EasyDiscordSDK.DiscordController>();
            }
            else
            {
                Debug.LogError("Unable to find DiscordSDKController Object");
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player" && easyDiscordSDKControllerScript != null)
            {
                easyDiscordSDKControllerScript.POSTState(state);
                easyDiscordSDKControllerScript.POSTDetails(details);
            }
        }
    }
}