//* Morgan Finney
//* www.pdox.uk
//* Feb 21
//* For DES203 | Project Raptor | Controlls Animation for the main player

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Raptor.Player
{
    public class PlayerAnimator : MonoBehaviour
    {
        public Animator playerAnimatorConteroller, playerShadowAnimatorConteroller; //* Refrances the 2 player sprite animation controllers componats
        public GameObject playerSprite, playerShaodwSprite, sprtieHolder; //* Refrances the 2 player sprite game object and the sprite holder object
        public float fallThreshold; //* velocity threshold of when to detect the falling state
        bool facingForward; //* Is the player facing forwards or backwards
        float targetRot; //* The end goal for the current rotation
        private CharacterController playerCharacterController; // *referance to the charecter cointroller componant
        public bool isGrounded;
        public Vector3 Velocity;
        public Raptor.Player.PlayerMovement movescript;
        bool playerIsGrab;

        private void Start()
        {
            SetUp();
        }

        void SetUp()
        {
            if (playerCharacterController == null)
                playerCharacterController = GetComponent<CharacterController>(); //* sets the refrance for the charecter controller

            if (playerAnimatorConteroller == null)
                playerAnimatorConteroller = playerSprite.GetComponent<Animator>(); //* sets the refrance for the animator compnant

            if (playerShadowAnimatorConteroller == null)
                playerShadowAnimatorConteroller = playerShaodwSprite.GetComponent<Animator>(); //* sets the refrance for the animator compnant

            if (movescript == null)
                movescript = GetComponent<Raptor.Player.PlayerMovement>();
        }

        //* Function to set walking animation
        public void SetWalking(bool toThis)
        {
            if (playerAnimatorConteroller == null || playerShadowAnimatorConteroller == null)
            {
                SetUp();
                return;
            }

            if (!playerIsGrab)
            {
                playerAnimatorConteroller.SetBool("IsWalking", toThis);
                playerShadowAnimatorConteroller.SetBool("IsWalking", toThis);
            }
        }

        //* function to set jumping animation
        public void SetJumping(bool toThis)
        {
            if (playerAnimatorConteroller == null || playerShadowAnimatorConteroller == null)
            {
                SetUp();
                return;
            }

            playerAnimatorConteroller.SetBool("IsJump", toThis);
            playerShadowAnimatorConteroller.SetBool("IsJump", toThis);
        }

        //*function to set falling animation
        public void SetFalling(bool toThis)
        {
            if (playerAnimatorConteroller == null || playerShadowAnimatorConteroller == null)
            {
                SetUp();
                return;
            }

            playerAnimatorConteroller.SetBool("IsFall", toThis);
            playerShadowAnimatorConteroller.SetBool("IsFall", toThis);
        }

        public void SetGrounded(bool toThis)
        {
            if (playerAnimatorConteroller == null || playerShadowAnimatorConteroller == null)
            {
                SetUp();
                return;
            }

            isGrounded = toThis;
            playerAnimatorConteroller.SetBool("IsGrounded", toThis);
            playerShadowAnimatorConteroller.SetBool("IsGrounded", toThis);
        }


        private void Update()
        {
            PushOrPull();
            FallCheck();

            if (!playerIsGrab)
                Rotate();
        }

        //* functions checks if the player if falling, based of there velocity
        void FallCheck()
        {

            Velocity = new Vector3(playerCharacterController.velocity.x, playerCharacterController.velocity.y, playerCharacterController.velocity.z);

            if (playerCharacterController.velocity.y < fallThreshold && !movescript.GroundCheck())
            {
                SetFalling(true);
            }
            else
            {
                SetFalling(false);
            }
        }


        //* rotates player based on what keys are being pressed. 
        void Rotate()
        {
            if (Input.GetAxisRaw("Horizontal") > 0)
                facingForward = true;
            else if (Input.GetAxisRaw("Horizontal") < 0)
                facingForward = false;

            if (facingForward == true)
            {
                if (Input.GetAxisRaw("Vertical") > 0)
                    targetRot = 330;
                else if (Input.GetAxisRaw("Vertical") < 0)
                    targetRot = 30;
                else
                    targetRot = 0;
            }
            else if (facingForward == false)
            {
                if (Input.GetAxisRaw("Vertical") > 0)
                    targetRot = 210;
                else if (Input.GetAxisRaw("Vertical") < 0)
                    targetRot = 150;
                else
                    targetRot = 180;
            }

            sprtieHolder.transform.rotation = Quaternion.Lerp(sprtieHolder.transform.rotation, Quaternion.Euler(0, targetRot + transform.localRotation.eulerAngles.y, 0), Time.deltaTime * 50);
        }

        public void PushOrPull()
        {
            if (playerIsGrab && facingForward && Input.GetAxisRaw("Horizontal") > 0)
            {
                playerAnimatorConteroller.SetBool("IsPush", true);
                playerShadowAnimatorConteroller.SetBool("IsPush", true);
            }
            else if (playerIsGrab && facingForward && Input.GetAxisRaw("Horizontal") < 0)
            {
                playerAnimatorConteroller.SetBool("IsPull", true);
                playerShadowAnimatorConteroller.SetBool("IsPull", true);
            }
            else if (playerIsGrab && !facingForward && Input.GetAxisRaw("Horizontal") > 0)
            {
                playerAnimatorConteroller.SetBool("IsPull", true);
                playerShadowAnimatorConteroller.SetBool("IsPull", true);
            }
            else if (playerIsGrab && !facingForward && Input.GetAxisRaw("Horizontal") < 0)
            {
                playerAnimatorConteroller.SetBool("IsPush", true);
                playerShadowAnimatorConteroller.SetBool("IsPush", true);
            }
            else
            {
                playerAnimatorConteroller.SetBool("IsPush", false);
                playerShadowAnimatorConteroller.SetBool("IsPush", false);
                playerAnimatorConteroller.SetBool("IsPull", false);
                playerShadowAnimatorConteroller.SetBool("IsPull", false);
            }
        }

        public bool GETfacingFoward()
        {
            return facingForward;
        }

        public void POSTplayerIsGrab(bool toThis)
        {
            playerIsGrab = toThis;
        }
    }
}