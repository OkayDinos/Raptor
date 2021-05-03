//* Morgan Finney
//* www.pdox.uk
//* Apr 21
//* For DES203 | Project Raptor | 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Raptor
{
    public class SceneLoader : MonoBehaviour
    {
        public GameObject startSceneLoadGO;
        public Raptor.StartSceneLoad startSceneLoadScript;
        public string sceneToLoad;
        AsyncOperation preloadOperation;
        public Slider proggressBar;
        public GameObject bookGO;
        public Raptor.BookAnim bookScript;


        private void Awake()
        {
            startSceneLoadGO = GameObject.Find("StartSceneLoad(Clone)").gameObject;
            startSceneLoadScript = startSceneLoadGO.GetComponent<Raptor.StartSceneLoad>();

            bookGO = GameObject.Find("Book").gameObject;
            bookScript = bookGO.GetComponent<Raptor.BookAnim>();

            sceneToLoad = startSceneLoadScript.RECIVESceneToLoad();
            GameObject.Destroy(startSceneLoadGO);
            StartCoroutine(StartLoading());
        }

        private void Update()
        {
            if (preloadOperation == null)
                return;


            proggressBar.value = Mathf.Clamp01(preloadOperation.progress / 0.9f);

            if (proggressBar.value >= 1)
                StartCoroutine(EndLoading());
        }

        IEnumerator StartLoading()
        {
            yield return new WaitForSeconds(0.6f);
            preloadOperation = SceneManager.LoadSceneAsync(sceneToLoad);
            preloadOperation.allowSceneActivation = false;
        }

        IEnumerator EndLoading()
        {
            bookScript.SetBookClosed(true);
            yield return new WaitForSeconds(0.6f);
            //* fade
            yield return new WaitForSeconds(0.1f);
            preloadOperation.allowSceneActivation = true;
        }
    }
}
