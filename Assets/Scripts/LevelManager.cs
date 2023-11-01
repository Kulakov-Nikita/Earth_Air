using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject entities;
    [SerializeField] private GameObject map;
    
    public void loadingLevel(ResourceLoader resourceLoader)
    {
        player = Instantiate(resourceLoader.loadPlayer("Player")) as GameObject;
        map = Instantiate(resourceLoader.loadMap("TestMap")) as GameObject;
    }

    void Update()
    {
        
    }
}
