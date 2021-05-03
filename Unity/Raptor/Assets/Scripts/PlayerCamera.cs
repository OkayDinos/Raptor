//* Morgan Finney
//* www.pdox.uk
//* Feb 21
//* For DES203 | Project Raptor | Controlls Camera
//* #FeelsMorgan

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Raptor.Player
{
    public class PlayerCamera : MonoBehaviour
    {
        bool isVillage = false, isX = true, isPositive = true; //* bools for current camera state
        float pathCenter, villageRot;
        public GameObject playerCamera, villageCamObject;
        public Vector3 cameraOffset;
        public float adventureCamFollowSpeed, villageCamRotSpeed, villageCamFollowSpeed, villageFOV = 45, fovSpeed, camAngleOffsetX, camAngleOffsetY, camAngleOffsetZ;


        private void Start()
        {
            playerCamera = GameObject.FindGameObjectWithTag("MainCamera");
            playerCamera.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            playerCamera.transform.eulerAngles = new Vector3(0, transform.rotation.y - 90, 0);
        }


        void VillageCameraMovement()
        {
            playerCamera.transform.position = Vector3.Lerp(playerCamera.transform.position, villageCamObject.transform.position, Time.deltaTime * villageCamFollowSpeed);
            playerCamera.transform.rotation = Quaternion.Lerp(playerCamera.transform.rotation, villageCamObject.transform.rotation, Time.deltaTime * villageCamRotSpeed);
            UnityEngine.Camera.main.fieldOfView = Mathf.Lerp(UnityEngine.Camera.main.fieldOfView, villageFOV, Time.deltaTime * fovSpeed);
        }

        void AdventureCameraXPositive()
        {
            //* Set Rotation
            playerCamera.transform.rotation = Quaternion.Lerp(playerCamera.transform.rotation, Quaternion.Euler(0 + camAngleOffsetX, 0 + camAngleOffsetY, 0 + camAngleOffsetZ), Time.deltaTime);

            //* Camera Postition
            Vector3 newPos = new Vector3(transform.position.x + cameraOffset.x, transform.position.y + cameraOffset.y, pathCenter + cameraOffset.z);
            playerCamera.transform.position = Vector3.Lerp(playerCamera.transform.position, newPos, Time.deltaTime * adventureCamFollowSpeed);

            //* FOV
            float newFOV = 40 + ((pathCenter - transform.position.z) * 2);
            UnityEngine.Camera.main.fieldOfView = Mathf.Lerp(UnityEngine.Camera.main.fieldOfView, newFOV, Time.deltaTime * fovSpeed);
        }

        void AdventureCameraXNegitive()
        {
            //* Set Rotation
            playerCamera.transform.rotation = Quaternion.Lerp(playerCamera.transform.rotation, Quaternion.Euler(0 + camAngleOffsetX, 180 + camAngleOffsetY, 0 + camAngleOffsetZ), Time.deltaTime);

            //* Camera Postition
            Vector3 newPos = new Vector3(transform.position.x - cameraOffset.x, transform.position.y + cameraOffset.y, pathCenter - cameraOffset.z);
            playerCamera.transform.position = Vector3.Lerp(playerCamera.transform.position, newPos, Time.deltaTime * adventureCamFollowSpeed);

            //* FOV
            float newFOV = 40 + ((pathCenter + transform.position.z) * 2);
            UnityEngine.Camera.main.fieldOfView = Mathf.Lerp(UnityEngine.Camera.main.fieldOfView, newFOV, Time.deltaTime * fovSpeed);
        }

        void AdventureCameraZPositive()
        {
            //* Set Rotation
            playerCamera.transform.rotation = Quaternion.Lerp(playerCamera.transform.rotation, Quaternion.Euler(0 + camAngleOffsetX, 270 + camAngleOffsetY, 0 + camAngleOffsetZ), Time.deltaTime);

            //* Camera Postition
            Vector3 newPos = new Vector3(pathCenter - cameraOffset.z, transform.position.y + cameraOffset.y, transform.position.z + cameraOffset.x);
            playerCamera.transform.position = Vector3.Lerp(playerCamera.transform.position, newPos, Time.deltaTime * adventureCamFollowSpeed);

            //* FOV
            float newFOV = 40 + -((pathCenter - transform.position.x) * 2);
            UnityEngine.Camera.main.fieldOfView = Mathf.Lerp(UnityEngine.Camera.main.fieldOfView, newFOV, Time.deltaTime * fovSpeed);
        }

        void AdventureCameraZNegitive()
        {
            //* Set Rotation
            playerCamera.transform.rotation = Quaternion.Lerp(playerCamera.transform.rotation, Quaternion.Euler(0 + camAngleOffsetX, 90 + camAngleOffsetY, 0 + camAngleOffsetZ), Time.deltaTime);

            //* Camera Postition
            Vector3 newPos = new Vector3(pathCenter + cameraOffset.z, transform.position.y + cameraOffset.y, transform.position.z - cameraOffset.x);
            playerCamera.transform.position = Vector3.Lerp(playerCamera.transform.position, newPos, Time.deltaTime * adventureCamFollowSpeed);

            //* FOV
            float newFOV = 40 + -((pathCenter + transform.position.x) * 2);
            UnityEngine.Camera.main.fieldOfView = Mathf.Lerp(UnityEngine.Camera.main.fieldOfView, newFOV, Time.deltaTime * fovSpeed);
        }

        void AdventureCameraMovement()
        {
            if (isX == true && isPositive == true)
                AdventureCameraXPositive();
            else if (isX == true && isPositive == false)
                AdventureCameraXNegitive();
            else if (isX == false && isPositive == true)
                AdventureCameraZPositive();
            else if (isX == false && isPositive == false)
                AdventureCameraZNegitive();
        }

        void LateUpdate()
        {

            if (isVillage == true)
                VillageCameraMovement();
            else
                AdventureCameraMovement();
        }

        public void POST(bool village, bool x, bool pos, float rot)
        {
            isVillage = village;
            isX = x;
            isPositive = pos;
            villageRot = rot;
        }
    }
}
