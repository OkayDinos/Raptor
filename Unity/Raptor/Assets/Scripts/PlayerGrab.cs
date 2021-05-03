//* Morgan Finney
//* www.pdox.uk
//* Apr 21
//* For DES203 | Project Raptor | 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Raptor.Player
{
    public class PlayerGrab : MonoBehaviour
    {

        public GameObject playerHandsFront, playerHandsBack, setHand;
        public float handsRadius;
        public bool facingForward;
        public float pushPower, pushpowerdef;
        public Collider[] hitColliders;
        public GameObject thisBox;
        public bool isHold = false;
        public Vector3 LOGEDPSO, offset;
        public Raptor.Player.PlayerMovement playerMovementScript;
        public Raptor.Player.PlayerInput playerInputScript;
        public Raptor.Player.PlayerAnimator playerAnimatorScript;
        public float dist, distHigh, distLow, low, high;
        bool isPushNotPull;





        // Start is called before the first frame update
        void Start()
        {
            playerMovementScript = this.gameObject.GetComponent<Raptor.Player.PlayerMovement>();
            playerInputScript = this.gameObject.GetComponent<Raptor.Player.PlayerInput>();
            playerAnimatorScript = this.gameObject.GetComponent<Raptor.Player.PlayerAnimator>();
            pushpowerdef = pushPower;
        }

        // Update is called once per frame
        void Update()
        {
            if (!isHold)
            {
                if (playerAnimatorScript.GETfacingFoward())
                    setHand = playerHandsFront;
                else
                    setHand = playerHandsBack;

                BoxCheck(setHand);
            }


            if (isHold && thisBox != null)
            {
                playerAnimatorScript.POSTplayerIsGrab(true);
                playerMovementScript.SetSpeed(1.1f);
                playerInputScript.setJump(false);

                Vector3 pushDir = new Vector3(Input.GetAxisRaw("Horizontal") * pushPower * Time.deltaTime, 0, Input.GetAxisRaw("Vertical") * pushPower * Time.deltaTime);
                pushDir = Quaternion.Euler(0, GetComponent<Raptor.Player.PlayerRotate>().REQUESTRot(), 0) * pushDir;
                thisBox.GetComponent<Rigidbody>().MovePosition(thisBox.transform.position + pushDir);

                dist = Vector3.Distance(setHand.transform.position, thisBox.transform.position);

                pushOrPull();

                if (pushPower < low)
                    pushPower = low;
                else if (pushPower > high)
                    pushPower = high;


                if (dist < distHigh && dist > distLow)
                    pushPower = pushpowerdef;

                else if (dist < distLow && isPushNotPull)
                    pushPower -= 0.1f;

                else if (dist > distHigh && isPushNotPull)
                    pushPower -= 0.1f;

                else if (dist < distHigh && !isPushNotPull)
                    pushPower -= 0.1f;

                else if (dist > distHigh && !isPushNotPull)
                    pushPower += 0.1f;
            }
            else
            {
                playerAnimatorScript.POSTplayerIsGrab(false);
                playerMovementScript.SetSpeed(6);
                playerInputScript.setJump(true);
            }
        }

        void pushOrPull()
        {
            if (facingForward && Input.GetAxisRaw("Horizontal") > 0)
            {
                isPushNotPull = false;
            }
            else if (facingForward && Input.GetAxisRaw("Horizontal") < 0)
            {
                isPushNotPull = true;
            }
            else if (!facingForward && Input.GetAxisRaw("Horizontal") > 0)
            {
                isPushNotPull = false;
            }
            else if (!facingForward && Input.GetAxisRaw("Horizontal") < 0)
            {
                isPushNotPull = true;
            }
        }


        public void SetGrabState(bool state)
        {
            isHold = state;
        }

        void BoxCheck(GameObject hands)
        {
            bool end = false;

            hitColliders = Physics.OverlapSphere(hands.transform.position, handsRadius);

            for (int i = 0; i < hitColliders.Length; i++)
            {
                if (hitColliders[i].gameObject.tag == "Crate" && !end)
                {
                    thisBox = hitColliders[i].gameObject;
                    end = true;
                }
            }

            if (!end && !isHold)
                thisBox = null;

        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(playerHandsFront.transform.position, handsRadius);
            Gizmos.DrawWireSphere(playerHandsBack.transform.position, handsRadius);
        }
    }
}
