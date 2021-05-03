//* Morgan Finney
//* www.pdox.uk
//* Feb 21
//* For DES203 | Project Raptor | Collects Inputs and Runs Events

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Raptor.Player
{
    [RequireComponent(typeof(Raptor.Player.PlayerMovement))]
    public class PlayerInput : MonoBehaviour
    {
        private Raptor.Player.PlayerMovement playerMovementScript; //* refrance to the players movment script
        private Raptor.Player.PlayerAnimator playerAnimScript; //* refrance to the player animation script
        private Raptor.Player.PlayerGrab playerGrabScript; //* refrance to the player grab script

        public bool moveAllowed = true, jumpAllowed = true, grabAllowed = true;
        bool grabActive = false, grabActiveXbox = false;
        public float allAllowed = 0;

        private void Start()
        {
            playerMovementScript = GetComponent<Raptor.Player.PlayerMovement>(); //* set the refrance
            playerAnimScript = GetComponent<Raptor.Player.PlayerAnimator>(); //* set the refrance
            playerGrabScript = GetComponent<Raptor.Player.PlayerGrab>(); //* set the refrance
        }
        void Update()
        {
            //if (allAllowed == 0)
            //{

                if (moveAllowed)
                    MovementInput();
                if (jumpAllowed)
                    JumpInput();
                if (grabAllowed)
                    GrabInput();
                SpellInput();
            //}
        }

        public void AddAllAllowed()
        {
            allAllowed++;
        }

        public void SubAllAllowed()
        {
            allAllowed--;
        }

        void MovementInput()
        {
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                playerMovementScript.MovePlayer(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
                playerAnimScript.SetWalking(true);
            }
            else
                playerAnimScript.SetWalking(false);
        }
        void JumpInput()
        {
            if (Input.GetButtonDown("Jump"))
            {
                playerMovementScript.Jump();
            }
        }

        void GrabInput()
        {
            if (Input.GetButtonDown("Grab") && !grabActive)
            {
                playerGrabScript.SetGrabState(true);
                grabActive = true;
            }
            else if (Input.GetButtonUp("Grab") && grabActive)
            {
                playerGrabScript.SetGrabState(false);
                grabActive = false;
            }

            if (Input.GetAxisRaw("GrabXbox") > 0 && !grabActiveXbox)
            {
                playerGrabScript.SetGrabState(true);
                grabActive = true;
            }
            else if (Input.GetAxisRaw("GrabXbox") == 0 && grabActiveXbox)
            {
                playerGrabScript.SetGrabState(false);
                grabActive = false;
            }
        }

        public void setJump(bool newJump)
        {
            jumpAllowed = newJump;
        }

        void SpellInput()
        {
            if ((Input.GetButtonDown("Fire") || (Input.GetAxisRaw("FireXbox") > 0)))
            {
                if(GetComponent<Raptor.Player.Magic.SpellSelect>().GetActive() == "rockActive")
                {
                    GetComponent<Raptor.Player.Magic.RockBoi>().CastSpell();
                }
            }
        }
    }
}