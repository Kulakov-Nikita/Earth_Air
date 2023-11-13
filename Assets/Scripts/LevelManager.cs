using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject playerEarth, playerAir;
    [SerializeField] private GameObject entities;
    [SerializeField] private GameObject map;
    private int ReadyPlayerCounter = 0;
    public UnityEvent LevelComplete = new UnityEvent();

    public void loadingLevel(ResourceLoader resourceLoader) { }
    public void PlayerInDoor()
    {
        ReadyPlayerCounter++;
        if(ReadyPlayerCounter == 2) LevelComplete.Invoke();
    }
    public void PlayerOutDoor()
    {
        ReadyPlayerCounter--;
    }

}
