//* Morgan Finney
//* www.pdox.uk
//* Apr 21
//* For DES203 | Project Raptor | 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Raptor
{
    public class InGameUI : MonoBehaviour
    {
        public GameObject screenCanvas, helperPanel, spellInfoPanel, pauseBGPanel, pausePanel, optionsPanel;

        void Awake()
        {
            this.gameObject.SetActive(true);
            Setup();
        }

        void Setup()
        {
            screenCanvas = this.gameObject;
            helperPanel = this.gameObject.transform.Find("HelperPanel").gameObject;
            spellInfoPanel = this.gameObject.transform.Find("SpellInfoPanel").gameObject;
            pauseBGPanel = this.gameObject.transform.Find("PauseBGPanel").gameObject;
            pausePanel = this.gameObject.transform.Find("PausePanel").gameObject;
            optionsPanel = this.gameObject.transform.Find("OptionsPanel").gameObject;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetButtonDown("Cancel"))
                PauseInput();
        }

        void PauseInput()
        {
            if (pauseBGPanel.activeSelf == false)
                Pause(true);
            else if (pauseBGPanel.activeSelf == true && pausePanel.activeSelf == true)
                Pause(false);
            else if (pauseBGPanel.activeSelf == true && optionsPanel.activeSelf == true)
                Options(false);
        }

        void Pause(bool state)
        {
            pauseBGPanel.SetActive(state);
            pausePanel.SetActive(state);
            Time.timeScale = state ? 0 : 1;
        }

        void Options(bool state)
        {
            optionsPanel.SetActive(state);
            pausePanel.SetActive(!state);
        }

        public void ContinueButton()
        {
            Pause(false);
        }

        public void OptionsInput()
        {
            Options(true);
        }

        public void QuitInput()
        {
            Time.timeScale = 1f;
            SceneManager.LoadSceneAsync("002-MainMenu");
        }
    }
}
