using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuManager : MonoBehaviour
{
    public GameObject GameMenu;
    public GameObject GameOverMenu;
    public GameObject LevelCompleteMenu;
    public GameObject PauseMenu;
    public PlayerMovement playerMovement;
    public string levelName;

    public void ReturnToMenu()
    {
        SceneManager.LoadSceneAsync("Main Menu");
    }
    public void Replay()
    {
        SceneManager.LoadSceneAsync("5");
    }
    public void LevelComplete()
    {
        GameMenu.SetActive(false);
        LevelCompleteMenu.SetActive(true);
        playerMovement.GameIsGoingOn = false;
    }
    public void GameOver()
    {
        GameMenu.SetActive(false);
        GameOverMenu.SetActive(true);
        //Time.timeScale = 0f;
        playerMovement.GameIsGoingOn = true;
    }
    public void Pause()
    {
        GameMenu.SetActive(false);
        PauseMenu.SetActive(true);
        //Time.timeScale = 0f;
        playerMovement.GameIsGoingOn = false;
    }

    public void Continue()
    {
        GameMenu.SetActive(true);
        PauseMenu.SetActive(false);
        // Time.timeScale = 1f;
        playerMovement.GameIsGoingOn = true;
    }
    public void NextLevel()
    {
        if (levelName == "1") SceneManager.LoadSceneAsync("5");
        if (levelName == "2") SceneManager.LoadSceneAsync("Main Menu");
    }
}
