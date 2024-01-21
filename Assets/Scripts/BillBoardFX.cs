using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoardFX : MonoBehaviour
{

    public Camera mainCamera;

    void Start()
    {
        // Obtén la referencia a la cámara principal
        mainCamera = Camera.main;

        if (mainCamera == null)
        {
            Debug.LogError("No se pudo encontrar la cámara principal en la escena.");
        }
    }

    void Update()
    {
        // Asegúrate de que la cámara se haya asignado correctamente
        if (mainCamera != null)
        {
            // Obtener la dirección desde el texto hacia la cámara
            Vector3 lookDir = mainCamera.transform.position - transform.position;

            // texto solo gira alrededor del eje Y
            lookDir.y = 0;

            // Calcula la rotación para mirar hacia la cámara
            Quaternion rotation = Quaternion.LookRotation(-lookDir);

            // Aplica la rotación al objeto (texto)
            transform.rotation = rotation;
        }
    }
}
