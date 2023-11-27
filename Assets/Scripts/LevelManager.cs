using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using static LavelMacker;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject playerEarth, playerAir;
    [SerializeField] private GameObject entities;
    [SerializeField] private GameObject map;
    private int ReadyPlayerCounter = 0;
    public UnityEvent LevelComplete = new UnityEvent();

    public int LevelSizeX = 10, LevelSizeY = 10;
    [SerializeField] private GameObject dirt, grass, slope1, slope2;
    public CellType[,] LevelMap;

    public void loadingLevel() {
        for (int y = 0; y < LevelSizeY; y++)
        {
            for (int x = 0; x < LevelSizeX; x++)
            {
                if (LevelMap[y, x] == CellType.Dirt) Instantiate(dirt, new Vector3(x - LevelSizeX / 2, y - LevelSizeY / 2, 0), new Quaternion(0, 0, 0, 0));
            }
        }
    }
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
