using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DataPersistance : MonoBehaviour
{
    private TMP_Text playerNameText;

    private void Start()
    {

        //Guardar nombre del jugador
        //
        //


        // Encontrar objeto con la etiqueta "playerName"
        GameObject playerNameObject = GameObject.FindGameObjectWithTag("playerName");

        // Asegurar de encontrar un objeto con la etiqueta
        if (playerNameObject != null)
        {
            // Intentar obtener componente TMP_Text del objeto encontrado
            playerNameText = playerNameObject.GetComponent<TMP_Text>();

            // Asegurar de que se encontró el componente TMP_Text
            if (playerNameText != null)
            {
                // Asigna el texto del componente con el nombre del jugador almacenado
                playerNameText.text = PlayerPrefs.GetString("playerName");
            }
            else
            {
                Debug.LogError("No se encontró el componente TMP_Text en el objeto con la etiqueta 'playerName'.");
            }
        }
        else
        {
            Debug.LogError("No se encontró ningún objeto con la etiqueta 'playerName'.");
        }
    }





}
