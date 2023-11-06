using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    private LevelSelectionMenu levelSelectionMenu;
    private SettingsMenu settingsMenu;
    private HelpMenu helpMenu;

    private void Awake()
    {
        levelSelectionMenu = new LevelSelectionMenu();
        settingsMenu = new SettingsMenu();
        helpMenu = new HelpMenu();
    }

    public void PlayGame()
    {
        levelSelectionMenu.ShowLevels();
    }

    public void OpenSettings()
    {
        settingsMenu.ShowSettings();
    }

    public void OpenHelp()
    {
        helpMenu.ShowHelp();
    }

    public void OpenLevel()
    {
        SceneManager.LoadSceneAsync("Test Level");
    }

    public void OpenAchievements()
    {
        SceneManager.LoadSceneAsync("Achievements Menu");
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadSceneAsync("Main Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

public class LevelSelectionMenu : MainMenuManager
{
    public void ShowLevels()
    {
        SceneManager.LoadSceneAsync("Level Selection Menu");
    }

}

public class SettingsMenu
{
    public void ShowSettings()
    {
        SceneManager.LoadSceneAsync("Settings Menu");
    }
}

public class HelpMenu
{
    public void ShowHelp()
    {
        SceneManager.LoadSceneAsync("Help Menu");
    }
}

