//* Morgan Finney
//* www.pdox.uk
//* Apr 21
//* For DES203 | Project Raptor | 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Raptor
{
    public class ErrorKick : MonoBehaviour
    {

        public string output = "";
        public string stack = "";

        public GameObject MenuLoaderPREFAB;

        void OnEnable()
        {
            GameObject.DontDestroyOnLoad(this.gameObject);
            Application.logMessageReceived += HandleLog;
        }

        void OnDisable()
        {
            Application.logMessageReceived -= HandleLog;
        }

        void HandleLog(string logString, string stackTrace, LogType type)
        {
           if(type == LogType.Error || type == LogType.Exception)
            {
                GameObject loader = Instantiate(MenuLoaderPREFAB);
                loader.GetComponent<Raptor.MenuSelect>().POSTMenuToLoad("Error", logString, stackTrace);
            }
        }
    }
}