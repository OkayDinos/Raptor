//* Morgan Finney
//* www.pdox.uk
//* Feb 21
//* For DES203 | Project Raptor | Contolls Selected and Unlocked Spells

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Raptor.Player.Magic
{

    public class SpellSelect : MonoBehaviour
    {

        public Button tpButton, rockButton, waterButton, leafButton, fireButton, dlc1Button, dlc2Button;

        public bool tpAllowed = true, rockAllowed = false, waterAllowed = false, leafAllowed = false, fireAllowed = false, dlc1Allowed = false, dlc2Allowed = false;

        public bool tpActive = false, rockActive = false, waterActive = false, leafActive = false, fireActive = false, dlc1Active = false, dlc2Active = false;

        public GameObject spellPanel;


        // Start is called before the first frame update
        void Start()
        {
            GetPlayerPrefs();
            UpdateButtonStatus();
        }

        private void FixedUpdate()
        {
            if (Input.GetButton("SpellSelect"))
                spellPanel.SetActive(true);
            else
                spellPanel.SetActive(false);

            ShowSelected();
        }


        void ShowSelected()
        {
            IAmSelected("tp");
            IAmSelected("rock");
            IAmSelected("water");
            IAmSelected("leaf");
            IAmSelected("fire");
            IAmSelected("dlc1");
            IAmSelected("dlc2");
        }

        void IAmSelected(string spell)
        {
            if ((bool)GetType().GetField(spell + "Active").GetValue(this) == true)
            {
                Button tempButton = (Button)GetType().GetField(spell + "Button").GetValue(this);
                tempButton.Select();
                UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(null);
            }
        }

        void UpdateButtonStatus()
        {
            tpButton.interactable = tpAllowed;
            rockButton.interactable = rockAllowed;
            waterButton.interactable = waterAllowed;
            leafButton.interactable = leafAllowed;
            fireButton.interactable = fireAllowed;
            dlc1Button.interactable = dlc1Allowed;
            dlc2Button.interactable = dlc2Allowed;
        }

        void GetPlayerPrefs()
        {
            tpAllowed = RECIVEPlayerPref("tpAllowed");
            rockAllowed = RECIVEPlayerPref("rockAllowed");
            waterAllowed = RECIVEPlayerPref("waterAllowed");
            leafAllowed = RECIVEPlayerPref("leafAllowed");
            fireAllowed = RECIVEPlayerPref("fireAllowed");
            dlc1Allowed = RECIVEPlayerPref("dlc1Allowed");
            dlc2Allowed = RECIVEPlayerPref("dlc2Allowed");
        }

        bool RECIVEPlayerPref(string thisPref)
        {
            if (PlayerPrefs.HasKey(thisPref))
            {

                return PlayerPrefs.GetInt(thisPref) == 1 ? true : false;
            }
            return false;
        }

        void POSTPlayerPref(string pref)
        {
            bool tempBool = (bool)GetType().GetField(pref + "Allowed").GetValue(this);
            PlayerPrefs.SetInt(pref + "Allowed", tempBool ? 1 : 0);
        }

        public void UnlockSpell(string spell)
        {
            this.GetType().GetField(spell + "Allowed").SetValue(this, true);
            UpdateButtonStatus();
            POSTPlayerPref(spell);
        }

        void DisableAll()
        {
            tpActive = false;
            rockActive = false;
            waterActive = false;
            leafActive = false;
            fireActive = false;
            dlc1Active = false;
            dlc2Active = false;
        }

        public void ButtonTP()
        {
            DisableAll();
            tpActive = true;
        }
        public void ButtonRock()
        {
            DisableAll();
            rockActive = true;
        }
        public void ButtonWater()
        {
            DisableAll();
            waterActive = true;
        }
        public void ButtonLeaf()
        {
            DisableAll();
            leafActive = true;
        }
        public void ButtonFire()
        {
            DisableAll();
            fireActive = true;
        }
        public void ButtonDLC1()
        {
            DisableAll();
            dlc1Active = true;
        }
        public void ButtonDLC2()
        {
            DisableAll();
            dlc2Active = true;
        }

        public string GetActive()
        {
            if (tpActive)
                return "tpActive";
            else if (rockActive)
                return "rockActive";
            else if (waterActive)
                return "waterActive";
            else if (leafActive)
                return "leafActive";
            else if (fireActive)
                return "fireActive";
            else if (dlc1Active)
                return "dlc1Active";
            else if (dlc2Active)
                return "dlc2Active";
            else
                return null;
        }
    }
}
