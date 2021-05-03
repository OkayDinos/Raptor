//* Morgan Finney
//* www.pdox.uk
//* Feb 21
//* For DES203 | Project Raptor | Open a Scene From Home Screen


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Raptor.DevHelper
{
    public class SceneOverride : MonoBehaviour
    {
        public bool ON;
        public string toLoad;

        // Start is called before the first frame update
        void Start()
        {
            if (ON == true)
                UnityEngine.SceneManagement.SceneManager.LoadScene(toLoad);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}