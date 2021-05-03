//* Morgan Finney
//* www.pdox.uk
//* Apr 21
//* For DES203 | Project Raptor | 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Raptor
{
    public class HomeScreen : MonoBehaviour
    {
        public string toLoad;

        public bool doStart = false;

        void Update()
        {
            if (doStart)
                UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(toLoad);
            else if (Input.anyKey && !Input.GetButton("Cancel"))
            {
                doStart = true;
            }
            else if (Input.GetButton("Cancel"))
                Application.Quit();
            else
                return;
        }
    }
}