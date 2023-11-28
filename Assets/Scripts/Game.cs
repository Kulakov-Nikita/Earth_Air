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
    private LevelSaver levelSaver;
    public string levelName;
    void Awake()
    {
        resourceLoader = new ResourceLoader();
        levelSaver = GetComponent<LevelSaver>() as LevelSaver;
        levelManager = GetComponent<LevelManager>() as LevelManager;
        audioManager = GetComponent<AudioManager>() as AudioManager;

        audioManager.LoadSettings();
        levelSaver.Load(levelName);

    }
    private void Start()
    {
        levelManager.LevelMap = levelSaver.data.LevelMap;
        levelManager.LevelSizeX = levelSaver.data.LevelSizeX;
        levelManager.LevelSizeY = levelSaver.data.LevelSizeY;
        levelManager.loadingLevel();
    }
    public void LevelComplete()
    {
        LevelCompleteMenu.SetActive(true);
    }
    public void GameOver()
    {
        GameOverMenu.SetActive(true);
        PlayerPrefs.SetInt("DeathCounter", PlayerPrefs.GetInt("DeathCounter", 0) + 1);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadSceneAsync("Main Menu");
    }

    public void Replay()
    {
        SceneManager.LoadSceneAsync("" + levelName);
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
