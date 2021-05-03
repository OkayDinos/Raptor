//* Morgan Finney
//* www.pdox.uk
//* Apr 21
//* For DES203 | Project Raptor | 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Raptor.Player.Magic
{
    public class RockBoi : MonoBehaviour
    {

        public Camera playerCamera;
        public GameObject hand;
        public Vector3 objectHit;
        public GameObject RockBoiPrefab;
        public float multiply;
        public GameObject spawned;
        public Vector3 tempVelo, bannana;
        public LayerMask layerMask;

        // Start is called before the first frame update
        void Start()
        {
            SetUp();
        }

        void SetUp()
        {
            playerCamera = Camera.main;
        }

        public void CastSpell()
        {
            if (spawned == null)
            {
                if (playerCamera == null)
                {
                    SetUp();
                    return;
                }

                RaycastHit hit;
                Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
                {
                    objectHit = hit.point;
                    bannana = objectHit - hand.transform.position;
                }
                Debug.DrawRay(Camera.main.transform.position, Camera.main.ScreenPointToRay(Input.mousePosition).direction * 1000);

                spawned = Instantiate(RockBoiPrefab, hand.transform.position, transform.rotation) as GameObject;
                spawned.GetComponent<Rigidbody>().AddForce(bannana.x * multiply, bannana.y * multiply, bannana.z * multiply, ForceMode.VelocityChange);
                StartCoroutine(Destroy());
                StartCoroutine(LongWait());
            }
        }

        IEnumerator Destroy()
        {
            tempVelo = spawned.transform.position;
            yield return new WaitForSeconds(1);
            if (spawned != null)
            {
                if (tempVelo != spawned.transform.position)
                {
                    StartCoroutine(Destroy());
                }
                else if (tempVelo == spawned.transform.position)
                {
                    GameObject.Destroy(spawned);
                    spawned = null;
                }
            }
        }

        IEnumerator LongWait()
        {
            yield return new WaitForSeconds(6f);
            GameObject.Destroy(spawned);
            spawned = null;
        }
    }
}
