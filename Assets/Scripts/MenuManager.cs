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
    public Slider[] sliders;

    private void Awake()
    {
        // ��������� ����������
        resourceLoader = new ResourceLoader();
        audioManager = GetComponent<AudioManager>();
        audioManager.musicSource = gameObject.AddComponent<AudioSource>() as AudioSource;

        //��������� ���������
        audioManager.LoadSettings();

        // ��������� ����� �����
        AudioClip[] clips = new AudioClip[1];
        clips[0] = resourceLoader.loadAudio("Music");
        audioManager.LoadAudio(clips);

        // ���������� �������� ��������� � ����������
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

    public void OpenLevelMaker()
    {
        SceneManager.LoadSceneAsync("LevelMaker");
    }

    public void StartLevel(int levelNumber)
    {
        //SceneManager.LoadSceneAsync(""+levelNumber.ToString());
        if (levelNumber == 1)SceneManager.LoadSceneAsync("4");
        if (levelNumber == 2) SceneManager.LoadSceneAsync("5");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

