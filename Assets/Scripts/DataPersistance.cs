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
        //Save player name

        // Find object with tag "playerName"
        GameObject playerNameObject = GameObject.FindGameObjectWithTag("playerName");

        if (playerNameObject != null)
        {
            // Try to get TMP_Text component from found object
            playerNameText = playerNameObject.GetComponent<TMP_Text>();

            // Ensure that the TMP_Text component was found
            if (playerNameText != null)
            {
                // Maps the component text with the stored player name
                playerNameText.text = PlayerPrefs.GetString("playerName");
            }
            else
            {
                Debug.LogError("The TMP_Text component was not found in the object with tag 'playerName'.");
            }
        }
        else
        {
            Debug.LogError("No object with tag 'playerName' was found.");
        }
    }





}
