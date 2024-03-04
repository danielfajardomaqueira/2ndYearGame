using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField]private GameObject pauseMenu;
    [SerializeField]private bool pause;
    
    private void Start()
    {
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

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

    public void Pause()
    {
        pause = !pause;
        pauseMenu.SetActive(pause);
        
        if (pause)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
        
    }

    public void Resume()
    {
        pauseMenu.SetActive(!pause);
        Time.timeScale = 1f;
        pause = false;
    }
}
