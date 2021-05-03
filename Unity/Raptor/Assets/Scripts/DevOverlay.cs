//* Morgan Finney
//* www.pdox.uk
//* Feb 21
//* For DES203 | Project Raptor | Shows stats about current dev play session, used for debugging.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Raptor.DevHelper
{
    public class DevOverlay : MonoBehaviour
    {
        public GameObject panel, text; //* refrance to the dev panel and its text box;
        float timer; //* Used to store time 
        int thisFPS = 200, slowFPS = 200, lowFPS = 200, highFPS = 0; //* stores diffrant FPS stats

        void Update()
        {
            thisFPS = (int)(1f / Time.unscaledDeltaTime); //* Sets the current FPS

            timer += Time.deltaTime; //* Updates the Timer 

            //* Every 1/2 second, logs the current FPS
            if (timer > 0.5)
            {
                slowFPS = thisFPS;
                timer = 0;
            }

            //* Logs the highest FPS
            if (thisFPS > highFPS)
                highFPS = thisFPS;

            //* Logs the lowest FPS
            if (thisFPS < lowFPS && thisFPS > 8)
                lowFPS = thisFPS;

            //* Sets stats to the text overlay
            text.GetComponent<TMPro.TextMeshProUGUI>().text = "PROJECT RAPTOR \nEARLY DEV GAMEPLAY \nVERSION\t\t|\t" + Application.version + "\nSCENE\t\t|\t" + UnityEngine.SceneManagement.SceneManager.GetActiveScene().name + "\nSYSTEM TIME\t|\t" + System.DateTime.Now + "\nFRAMES\t\t|\t" + thisFPS + "\t|\t" + slowFPS + "\t|\t" + lowFPS + "\t|\t" + highFPS;
        }
    }
}