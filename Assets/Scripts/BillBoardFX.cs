using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoardFX : MonoBehaviour
{

    public Camera mainCamera;

    void Start()
    {
        // Reference to the main camera
        mainCamera = Camera.main;

        if (mainCamera == null)
        {
            Debug.LogError("Could not find main camera at scene");
        }
    }

    void Update()
    {
        // Make sure the camera has been assigned correctly
        if (mainCamera != null)
        {
            // Direction from text to camera
            Vector3 lookDir = mainCamera.transform.position - transform.position;

            // Text only rotates around the Y axis
            lookDir.y = 0;

            // Calculate the rotation to face the camera
            Quaternion rotation = Quaternion.LookRotation(-lookDir);

            // Applies rotation to the object (text)
            transform.rotation = rotation;
        }
    }
}
