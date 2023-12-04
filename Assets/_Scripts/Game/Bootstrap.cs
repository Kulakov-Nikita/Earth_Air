using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    private LevelSaver levelSaver;
    private LevelManager levelManager;
    private GameMenuManager gameMenuManager;
    public string levelName;

    private void Awake()
    {
        levelSaver = new LevelSaver();
        levelManager = GetComponent<LevelManager>();
        gameMenuManager = GetComponent<GameMenuManager>();

        gameMenuManager.levelName = levelName;
        levelSaver.Load(levelName);
    }
    private void Start()
    {
        levelManager.LevelMap = levelSaver.data.LevelMap;
        levelManager.LevelSizeX = levelSaver.data.LevelSizeX;
        levelManager.LevelSizeY = levelSaver.data.LevelSizeY;
        levelManager.loadingLevel();

        gameMenuManager.Continue();
    }
}
