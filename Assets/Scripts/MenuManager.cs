using System.Collections;
using System.Collections.Generic;
using UnityEditor.Compilation;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private ResourceLoader resourceLoader;
    private AudioManager audioManager;
    public GameObject MainMenu;
    public GameObject LavelList;
    public GameObject Settings;
    public GameObject Achievements;
    public GameObject Help;
    public Slider[] sliders;

    private void Awake()
    {
        // Загружаем компоненты
        resourceLoader = new ResourceLoader();
        audioManager = GetComponent<AudioManager>();
        audioManager.musicSource = gameObject.AddComponent<AudioSource>() as AudioSource;

        //Загружаем настройки
        audioManager.LoadSettings();

        // Загружаем аудио файлы
        AudioClip[] clips = new AudioClip[1];
        clips[0] = resourceLoader.loadAudio("Music");
        audioManager.LoadAudio(clips);

        // Выставляем ползунки громкости в настройках
        float[] respond = audioManager.GetSettings();
        sliders[0].value = respond[0];
        sliders[1].value = respond[1];

    }
    private void Start()
    {
        SetActiveAll(false);
        MainMenu.SetActive(true);
    }
    private void SetActiveAll(bool isActive)
    {
        MainMenu.SetActive(isActive);
        LavelList.SetActive(isActive);
        Settings.SetActive(isActive);
        Achievements.SetActive(isActive);
        Help.SetActive(isActive);
    }
    public void OpenMainMenu()
    {
        SetActiveAll(false);
        MainMenu.SetActive(true);
    }

    public void OpenLevelList()
    {
        SetActiveAll(false);
        LavelList.SetActive(true);
    }

    public void OpenSettings()
    {
        SetActiveAll(false);
        Settings.SetActive(true);
    }
    public void OpenAchievements()
    {
        SetActiveAll(false);
        Achievements.SetActive(true);
    }

    public void OpenHelp()
    {
        SetActiveAll(false);
        Help.SetActive(true);
    }

    public void StartLevel()
    {
        SceneManager.LoadSceneAsync("Test Level");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

