//* Morgan Finney
//* www.pdox.uk
//* Apr 21
//* For DES203 | Project Raptor | 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using pdox;
using TMPro;

namespace Raptor
{
    public class MainMenuScript : MonoBehaviour
    {
        public Button continueBUTTON;
        public GameObject continueCrossoutGO;
        public GameObject loaderPREFAB;

        public GameObject menuSelectGO;
        public Raptor.MenuSelect menuSelectSCRIPT;

        public GameObject mainMenuGO, creditsGO, errorGO, opptionsGO, errorTextGO;

        string toLoad;


        // Start is called before the first frame update
        void Start()
        {
            MenuSelect();
            CheckState();
        }

        void MenuSelect()
        {
            menuSelectGO = GameObject.Find("MenuSelect(Clone)");

            if (menuSelectGO == null)
            {
                DisableAll();
                mainMenuGO.SetActive(true);
                return;
            }


            menuSelectSCRIPT = menuSelectGO.GetComponent<Raptor.MenuSelect>();

            toLoad = menuSelectSCRIPT.RECIVEMenuToLoad();

            if (toLoad == "Credits")
            {
                DisableAll();
                creditsGO.SetActive(true);
            }
            else if (toLoad == "Main")
            {
                DisableAll();
                mainMenuGO.SetActive(true);
            }
            else if (toLoad == "Error")
            {
                DisableAll();
                errorGO.SetActive(true);
                errorTextGO.GetComponent<TextMeshProUGUI>().SetText(menuSelectSCRIPT.RECIVEError());
            }
            else
            {
                DisableAll();
                errorGO.SetActive(true);
            }

            GameObject.Destroy(menuSelectGO);
        }

        void DisableAll()
        {
            mainMenuGO.SetActive(false);
            creditsGO.SetActive(false);
            errorGO.SetActive(false);
            opptionsGO.SetActive(false);
        }

        void CheckState()
        {
            if (PlayerPrefs.HasKey("CheckPoint"))
            {
                continueBUTTON.interactable = true;
                continueCrossoutGO.SetActive(false);
            }
            else
            {
                continueBUTTON.interactable = false;
                continueCrossoutGO.SetActive(true);
            }
        }

        public void ClearSave()
        {
            PlayerPrefs.DeleteAll();
            CheckState();
        }

        public void LoadSaveGame()
        {
            GameObject loader = Instantiate(loaderPREFAB);
            loader.GetComponent<Raptor.StartSceneLoad>().POSTSceneToLoad("995-Test");
        }
        public void NewGame()
        {
            PlayerPrefs.DeleteAll();
            GameObject loader = Instantiate(loaderPREFAB);
            loader.GetComponent<Raptor.StartSceneLoad>().POSTSceneToLoad("995-Test");
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        public void Options()
        {
            DisableAll();
            opptionsGO.SetActive(true);
        }

        public void Credits()
        {
            DisableAll();
            creditsGO.SetActive(true);
        }

        public void ToMainMenu()
        {
            DisableAll();
            mainMenuGO.SetActive(true);
        }
    }
}
