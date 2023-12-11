using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private AirCharScript playerAir;
    [SerializeField] private EarthCharScript playerEarth;
    [SerializeField] private Fan fan;
    [SerializeField] private GameObject Wind;
    private int ReadyPlayerCounter = 0;
    public UnityEvent LevelComplete = new UnityEvent();

    public int LevelSizeX = 10, LevelSizeY = 10;
    [SerializeField] private GameObject dirt, grass, slope1, slope2, door, gem;
    public Cell.CellType[,] LevelMap;
    public GameObject LeftDownCorner;

    public void CreateWind()
    {
        Debug.Log("Level Manager [CreateWind]: " + "(fan.isPlayerInside=" + fan.isPlayerInside + ") (playerAir.isAirActive=" + playerAir.isAirActive + ")");
        if (fan.isPlayerInside && !playerAir.isAirActive) Instantiate(Wind, fan.transform.position + new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
    }

    public void loadingLevel()
    {
        for (int y = 0; y < LevelSizeY; y++)
        {
            for (int x = 0; x < LevelSizeX; x++)
            {
                GameObject newCell = null;
                Vector3 shift = Vector3.zero;

                if (LevelMap[y, x] == Cell.CellType.Dirt) newCell = dirt;
                if (LevelMap[y, x] == Cell.CellType.Grass) newCell = grass;
                if (LevelMap[y, x] == Cell.CellType.Slope1) newCell = slope1;
                if (LevelMap[y, x] == Cell.CellType.Slope2) newCell = slope2;
                if (LevelMap[y, x] == Cell.CellType.Door)
                {
                    newCell = door;
                    shift = new Vector3(0, 0.3f, 0);
                }
                if (LevelMap[y, x] == Cell.CellType.Gem) newCell = gem;

                if(newCell != null)Instantiate(newCell, new Vector3(x, y, 0) + LeftDownCorner.transform.position + shift, new Quaternion(0, 0, 0, 0));
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
