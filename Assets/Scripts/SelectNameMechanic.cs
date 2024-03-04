using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SelectNameMechanic : MonoBehaviour
{

    //Variables
    [SerializeField] private TMP_InputField inputText;
    [SerializeField] private  TMP_Text textName;
    public Image check;
    public GameObject buttonPlay;

    private void Awake()
    {
        // The color of the check will always start red
        check.color = Color.red;
    }

    private void Update()
    {
        // When the text length is less than 4 letters, the Check is red
        // and the Play Button does not appear. When the length is greater than or equal to 4,
        // the Check is green and the Play Button appears.

        if(textName.text.Length < 4)
        {
            check.color = Color.red;
            buttonPlay.SetActive(false);
        }

        if (textName.text.Length >= 4)
        {
            check.color = Color.green;
            buttonPlay.SetActive(true);
        }
    }

    public void Play()
    {

        // Save the text information written by the user, and change the scene
        PlayerPrefs.SetString("playerName", inputText.text);
        SceneManager.LoadScene("SampleScene");
    }
}
