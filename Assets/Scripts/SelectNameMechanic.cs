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

        // El color del "Check" siempre empezara de color rojo.

        check.color = Color.red;
    }

    private void Update()
    {

        //Cuando la longitud del texto es inferior a 4 letras, el "Check" es rojo
        //y no aparece el boton "Play". Cuando la longitud es mayor o igual a 4,
        //el "Check" es de color verde y aparece el boton "Play".


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

        //Guarda la información del texto escrito por el usuario, y cambia de escena.

        PlayerPrefs.SetString("playerName", inputText.text);
        SceneManager.LoadScene("SampleScene");
    }
}
