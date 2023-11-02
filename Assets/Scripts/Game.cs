using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private LevelManager levelManager;
    private ResourceLoader resourceLoader;
    void Awake()
    {
        resourceLoader = new ResourceLoader();
        levelManager = gameObject.AddComponent<LevelManager>() as LevelManager;
        levelManager.loadingLevel(resourceLoader);
    }

}
