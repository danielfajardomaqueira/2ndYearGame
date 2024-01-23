using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public void PlayGame()
    {
        SceneManager.LoadScene("SelectName");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Instructions()
    {
        SceneManager.LoadScene("Instructions");
    }
    
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
