//* Morgan Finney
//* www.pdox.uk
//* Apr 21
//* For DES203 | Project Raptor | 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Raptor
{
    public class StartSceneLoad : MonoBehaviour
    {
        public string sceneToLoad;
        AsyncOperation preloadOperation;
        public GameObject bookGO;
        public Raptor.BookAnim bookScript;

        private void Awake()
        {
            GameObject.DontDestroyOnLoad(this.gameObject);

            bookGO = GameObject.Find("Book").gameObject;
            bookScript = bookGO.GetComponent<Raptor.BookAnim>();

            StartCoroutine(CloseBook());
        }

        public string RECIVESceneToLoad()
        {
            return sceneToLoad;
        }

        public void POSTSceneToLoad(string setThis)
        {
            sceneToLoad = setThis;
            return;
        }

        IEnumerator CloseBook()
        {
            bookScript.SetBookClosed(true);
            yield return new WaitForSeconds(1f);
            preloadOperation = SceneManager.LoadSceneAsync("000-SceneLoader");
        }
    }
}
