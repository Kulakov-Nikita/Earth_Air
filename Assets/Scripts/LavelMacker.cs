using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LavelMacker : MonoBehaviour
{
    public Canvas canvas;
    public enum CellType { Empty, Dirt, Grass, Slope1, Slope2 }
    public int LevelSizeX=10,LevelSizeY=10;
    [SerializeField] private GameObject empty, dirt, grass, slope1, slope2;
    public CellType[,] LevelMap;
    private void Awake()
    {
        LevelMap = new CellType[LevelSizeY, LevelSizeX];
        for (int y = 0; y < LevelSizeY; y++)
        {
            for (int x = 0; x < LevelSizeX; x++)
            {
                LevelMap[y,x] = CellType.Empty;
            }
        }
        LevelMap[5, 5] = CellType.Dirt;
    }
    void Start()
    {
        for (int y = 0; y < LevelSizeY; y++)
        {
            for (int x = 0; x < LevelSizeX; x++)
            {
                GameObject newCell = empty;
                newCell = Instantiate(newCell, new Vector3(x*100+canvas.transform.position.x/4, y*100 + canvas.transform.position.y /5, 0), new Quaternion(0, 0, 0, 0)) as GameObject;
                newCell.transform.SetParent(canvas.transform);
            }
        }
    }

}
