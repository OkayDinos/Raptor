//* Morgan Finney
//* www.pdox.uk
//* Apr 21
//* For DES203 | Project Raptor | 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Raptor
{
    public class MenuSelect : MonoBehaviour
    {
        string menuToLoad, errorLog, errorStack;
        AsyncOperation preloadOperation;

        public string RECIVEMenuToLoad()
        {
            return menuToLoad;
        }

        public string RECIVEError()
        {
            return "|LogMSG|\n" + errorLog + "\n|LogSTACK|\n" + errorStack;
        }

        public void POSTMenuToLoad(string setThisMenu, string setThisLog, string setThisStack)
        {
            GameObject.DontDestroyOnLoad(this.gameObject);
            menuToLoad = setThisMenu;
            errorLog = setThisLog;
            errorStack = setThisStack;
            preloadOperation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("002-MainMenu");
            return;
        }
    }
}
