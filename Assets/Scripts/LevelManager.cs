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
    public GameObject LeftDownCorner;

    public void loadingLevel()
    {
        Debug.Log("loadingLevel");
        for (int y = 0; y < LevelSizeY; y++)
        {
            for (int x = 0; x < LevelSizeX; x++)
            {
                GameObject newCell = null;

                if (LevelMap[y, x] == CellType.Dirt) newCell = dirt;
                if (LevelMap[y, x] == CellType.Grass) newCell = grass;
                if (LevelMap[y, x] == CellType.Slope1) newCell = slope1;
                if (LevelMap[y, x] == CellType.Slope2) newCell = slope2;

                if (newCell != null)Instantiate(newCell, new Vector3(x, y, 0) + LeftDownCorner.transform.position, new Quaternion(0, 0, 0, 0));
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
