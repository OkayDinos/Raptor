//* Morgan Finney
//* www.pdox.uk
//* Apr 21
//* For DES203 | Project Raptor | 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Raptor
{
    public class SetHelperText : MonoBehaviour
    {
        public GameObject helperPanel, helperTextGO;
        public TextMeshProUGUI helperTextTMP;
        public string textToSet;
        public bool clearMe;

        void Start()
        {
            SetUp();
        }

        void SetUp()
        {
            helperPanel = GameObject.Find("HelperPanel").gameObject;
            helperTextGO = helperPanel.transform.Find("HelperText").gameObject;
            helperTextTMP = helperTextGO.GetComponent<TextMeshProUGUI>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag != "Player")
                return;

            if (helperTextTMP == null)
                SetUp();

            if (clearMe)
                CleanHelperUI();
            else
                SetHelperUI();
        }

        void CleanHelperUI()
        {
            helperTextTMP.SetText("");
            helperPanel.SetActive(false);
        }

        void SetHelperUI()
        {
            helperPanel.SetActive(true);
            helperTextTMP.SetText(textToSet);
        }

    }
}
