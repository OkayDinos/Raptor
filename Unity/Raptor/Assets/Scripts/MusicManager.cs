//* Morgan Finney
//* www.pdox.uk
//* Apr 21
//* For DES203 | Project Raptor | 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Raptor
{
    public class MusicManager : MonoBehaviour
    {
        public AudioClip[] menu, village, caves, forest;
        public bool isMenu, isVillage, isCaves, isForest;

        private void Awake()
        {
            GameObject[] musics = GameObject.FindGameObjectsWithTag("MusicMan");
            if (musics.Length > 1)
            {
                Destroy(this.gameObject);
            }
            else
            {
                SelectTrack();
            }

            DontDestroyOnLoad(this.gameObject);
        }

        void SelectTrack()
        {
            if (isMenu)
                StartCoroutine(PlayTrack(menu));
            else if (isVillage)
                StartCoroutine(PlayTrack(village));
            else if (isCaves)
                StartCoroutine(PlayTrack(caves));
            else if (isForest)
                StartCoroutine(PlayTrack(forest));
        }

        IEnumerator PlayTrack(AudioClip[] thisClip)
        {
            yield return new WaitForEndOfFrame();
            int bgRand = (int)Mathf.Round(Random.Range(0f, thisClip.Length - 1));
            GetComponent<AudioSource>().clip = thisClip[bgRand];
            GetComponent<AudioSource>().Play();
            yield return new WaitForEndOfFrame();
            yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length);
            SelectTrack();
        }
    }
}
