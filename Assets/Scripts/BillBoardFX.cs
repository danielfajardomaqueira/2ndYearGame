using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoardFX : MonoBehaviour
{

    public Camera mainCamera;

    void Start()
    {
        // Obt�n la referencia a la c�mara principal
        mainCamera = Camera.main;

        if (mainCamera == null)
        {
            Debug.LogError("No se pudo encontrar la c�mara principal en la escena.");
        }
    }

    void Update()
    {
        // Aseg�rate de que la c�mara se haya asignado correctamente
        if (mainCamera != null)
        {
            // Obtener la direcci�n desde el texto hacia la c�mara
            Vector3 lookDir = mainCamera.transform.position - transform.position;

            // texto solo gira alrededor del eje Y
            lookDir.y = 0;

            // Calcula la rotaci�n para mirar hacia la c�mara
            Quaternion rotation = Quaternion.LookRotation(-lookDir);

            // Aplica la rotaci�n al objeto (texto)
            transform.rotation = rotation;
        }
    }
}
