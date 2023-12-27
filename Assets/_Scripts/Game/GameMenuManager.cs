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
        if (levelName == "1") SceneManager.LoadSceneAsync("4");
        if (levelName == "2") SceneManager.LoadSceneAsync("5");
        if (levelName == "3") SceneManager.LoadSceneAsync("6");
        if (levelName == "4") SceneManager.LoadSceneAsync("7");
        if (levelName == "5") SceneManager.LoadSceneAsync("8");
        if (levelName == "6") SceneManager.LoadSceneAsync("9");
        if (levelName == "7") SceneManager.LoadSceneAsync("10");
        if (levelName == "8") SceneManager.LoadSceneAsync("11");
        if (levelName == "9") SceneManager.LoadSceneAsync("12");
        if (levelName == "10") SceneManager.LoadSceneAsync("13");
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
        if (levelName == "2") SceneManager.LoadSceneAsync("6");
        if (levelName == "3") SceneManager.LoadSceneAsync("7");
        if (levelName == "4") SceneManager.LoadSceneAsync("8");
        if (levelName == "5") SceneManager.LoadSceneAsync("10");
        if (levelName == "6") SceneManager.LoadSceneAsync("11");
        if (levelName == "7") SceneManager.LoadSceneAsync("12");
        if (levelName == "8") SceneManager.LoadSceneAsync("13");
        if (levelName == "9") SceneManager.LoadSceneAsync("Main Menu");
    }
}
