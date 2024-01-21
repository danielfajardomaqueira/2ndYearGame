using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SelectNameMechanic : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputText;
    [SerializeField] private  TMP_Text textName;
    public Image check;
    public GameObject buttonPlay;

    private void Awake()
    {
        check.color = Color.red;
    }

    private void Update()
    {
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
        PlayerPrefs.SetString("playerName", inputText.text);
        SceneManager.LoadScene("SampleScene");
    }
}
