using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    private LevelManager levelManager;
    private ResourceLoader resourceLoader;
    public GameObject GameOverMenu, LevelCompleteMenu;
    void Awake()
    {
        resourceLoader = new ResourceLoader();
        levelManager = GetComponent<LevelManager>() as LevelManager;
        //levelManager.loadingLevel(resourceLoader);
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

}
