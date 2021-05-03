//* Morgan Finney
//* www.pdox.uk
//* Apr 21
//* For DES203 | Project Raptor | 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Raptor
{
    public class Comic : MonoBehaviour
    {
        public GameObject comicStrip;
        public GameObject[] POI;
        public Vector2 target;
        public float totalTime;
        public float[] timeForThis;


        // Start is called before the first frame update
        void Start()
        {

            if (PlayerPrefs.HasKey("CheckPoint"))
            {
                if (PlayerPrefs.GetInt("CheckPoint") >= 1)
                    End();
                else
                    StartCoroutine(ComicPlayer(0));
            }
            else
            {
                StartCoroutine(ComicPlayer(0));
            }

        }

        void End()
        {
            for (var i = 0; i < POI.Length; i++)
            {
                GameObject.Destroy(POI[i]);
            }
            GameObject.Destroy(comicStrip);
            GameObject.Destroy(this.gameObject);
        }

        // Update is called once per frame
        void Update()
        {
            comicStrip.GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp(comicStrip.GetComponent<RectTransform>().anchoredPosition, target, 0.1f);
        }

        IEnumerator ComicPlayer(int thisTarget)
        {
            target = -POI[thisTarget].GetComponent<RectTransform>().anchoredPosition;
            yield return new WaitForSeconds(timeForThis[thisTarget]);
            if (thisTarget < POI.Length - 1)
                StartCoroutine(ComicPlayer(thisTarget + 1));
            else
                End();
        }
    }
}
