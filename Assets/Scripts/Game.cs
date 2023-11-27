using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    private LevelManager levelManager;
    private ResourceLoader resourceLoader;
    private AudioManager audioManager;
    public GameObject GameOverMenu, LevelCompleteMenu, PauseMenu;
    void Awake()
    {
        resourceLoader = new ResourceLoader();
        levelManager = GetComponent<LevelManager>() as LevelManager;
        audioManager = GetComponent<AudioManager>() as AudioManager;

    }
    public void LevelComplete()
    {
        LevelCompleteMenu.SetActive(true);
    }
    public void GameOver()
    {
        //Debug.Log("Game Over"); 
        GameOverMenu.SetActive(true);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadSceneAsync("Main Menu");
    }

    public void Replay()
    {
        SceneManager.LoadSceneAsync("DemoLevel");
    }

    public void OpenPauseMenu()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
  }

    public void ClosePauseMenu()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
  }
}
