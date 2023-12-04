using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMakerMenu : MonoBehaviour
{
    public GameObject Menu;
    public Text text;

    private void Start()
    {
        Menu.SetActive(false);
    }
    public void Pause()
    {
        Debug.Log("Pause");
        Menu.SetActive(true);
    }
    public void Continue()
    { 
        Menu.SetActive(false);
    }
    public void MainMenu()
    {
        SceneManager.LoadSceneAsync("Main Menu");
    }
    public void TestLevel()
    {
        SceneManager.LoadSceneAsync("4");
    }
}
