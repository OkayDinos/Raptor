//* Morgan Finney
//* www.pdox.uk
//* Feb 21
//* For DES203 | Project Raptor | PlayerMovement

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Raptor.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody playerRigidbody;
        public float speedMultiplyer = 0.2f;
        public float jumpForce = 2.0f;
        private Raptor.Player.PlayerAnimator playerAnimScript;
        public CharacterController playerCharacterController;
        Vector3 playerVelocity;
        public float worldGravity = -9.81f;

        public float radius;
        public Vector3 offset;
        public Collider[] hitColliders;
        public LayerMask playerToGroundMask;


        public bool hitRecent;

        public void SetSpeed(float newSpeed)
        {
            speedMultiplyer = newSpeed;
        }

        private void Start()
        {
            playerCharacterController = GetComponent<CharacterController>();
            playerAnimScript = GetComponent<Raptor.Player.PlayerAnimator>();
        }

        void Update()
        {
            if (GroundCheck())
                playerAnimScript.SetGrounded(true);
            else if (!GroundCheck())
                playerAnimScript.SetGrounded(false);


            if (playerCharacterController.isGrounded && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }





            playerVelocity.y += worldGravity * Time.deltaTime;
            playerCharacterController.Move(playerVelocity * Time.deltaTime);
        }

        public bool GroundCheck()
        {
            bool end = false;

            hitColliders = Physics.OverlapSphere(transform.position + offset, radius);

            for (int i = 0; i < hitColliders.Length; i++)
            {
                if (hitColliders[i].gameObject.tag != "Player" && !end && hitColliders[i].gameObject.tag != "Trigger" && hitColliders[i].gameObject.tag != "RayCatcher" && hitColliders[i].gameObject.tag != "RockBoi")
                {
                    end = true;
                }
            }

            return end;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position + offset, radius);
        }


        public void MovePlayer(float moveVertialValue, float moveHorisontalValue)
        {
            Vector3 moveDirection = new Vector3(moveVertialValue * speedMultiplyer * Time.deltaTime, playerCharacterController.velocity.y / 1000, moveHorisontalValue * speedMultiplyer * Time.deltaTime);
            moveDirection = Quaternion.Euler(0, GetComponent<Raptor.Player.PlayerRotate>().REQUESTRot(), 0) * moveDirection;
            playerCharacterController.Move(moveDirection);
        }

        public void Jump()
        {
            if (!hitRecent)
            {
                hitRecent = true;
                StartCoroutine(AntiSpam());
                if (GroundCheck())
                {
                    StartCoroutine(WaitToJump());
                }
            }


        }

        IEnumerator WaitToJump()
        {
            playerAnimScript.SetJumping(true);
            yield return new WaitForSeconds(0.125f);
            playerVelocity.y += Mathf.Sqrt(jumpForce * -3.0f * worldGravity);
            playerAnimScript.SetJumping(false);
        }
        IEnumerator AntiSpam()
        {
            yield return new WaitForSeconds(0.2f);
            hitRecent = false;
        }
    }
}