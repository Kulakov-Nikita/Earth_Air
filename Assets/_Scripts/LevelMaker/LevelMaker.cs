using System.Collections;
using System.Collections.Generic;
using System.Resources;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LevelMaker : MonoBehaviour
{
    public int LevelSizeX = 20, LevelSizeY = 10;
    public Canvas canvas;
    public GameObject CellSample;
    public GameObject LeftDownCorner;
    public Text text;

    private ResourseManager resourseManager;

    private GameObject[,] LevelMap;
    private LevelSaver levelSaver;

    private void Awake()
    {
        resourseManager = GetComponent<ResourseManager>();
        LevelMap = new GameObject[LevelSizeY, LevelSizeX];
        levelSaver = new LevelSaver();

        levelSaver.data = new LevelSaver.LevelMapArray();
        levelSaver.data.LevelSizeX = LevelSizeX;
        levelSaver.data.LevelSizeY = LevelSizeY;
        levelSaver.data.LevelMap = new Cell.CellType[LevelSizeY, LevelSizeX];
    }
    private void Start()
    {
        for(int y=0;y<LevelSizeY;y++)
        {
            for(int x=0;x<LevelSizeX;x++)
            {
                LevelMap[y,x] = Instantiate(CellSample,new Vector3(x,y,0) + LeftDownCorner.transform.position,new Quaternion(0,0,0,0));
                LevelMap[y, x].transform.SetParent(canvas.transform);
                LevelMap[y, x].GetComponent<Cell>().resourseManager = resourseManager;
            }
        }
    }

    public void SaveLevelMap()
    {
        for (int y = 0; y < LevelSizeY; y++)
        {
            for (int x = 0; x < LevelSizeX; x++)
            {
                levelSaver.data.LevelMap[y, x] = LevelMap[y, x].GetComponent<Cell>().cellType;
            }
        }

        levelSaver.Save(text.text);
    }
    public void DestroyAllCells()
    {
        for (int y = 0; y < LevelSizeY; y++)
        {
            for (int x = 0; x < LevelSizeX; x++)
            {
                Destroy(LevelMap[y, x]);
            }
        }
    }
    public void LoadLevelMap()
    {
        DestroyAllCells();

        levelSaver.Load(text.text);
        Cell.CellType[,] map = levelSaver.data.LevelMap;

        for (int y = 0; y < LevelSizeY; y++)
        {
            for (int x = 0; x < LevelSizeX; x++)
            {
                LevelMap[y, x] = Instantiate(CellSample, new Vector3(x, y, 0) + LeftDownCorner.transform.position, new Quaternion(0, 0, 0, 0));
                LevelMap[y, x].transform.SetParent(canvas.transform);

                Cell newCell = LevelMap[y, x].GetComponent<Cell>();
                newCell.resourseManager = resourseManager;
                newCell.cellType = map[y, x];
                newCell.UpdateSprite();
            }
        }
    }
    public void HideAllCells()
    {
        for (int y = 0; y < LevelSizeY; y++)
        {
            for (int x = 0; x < LevelSizeX; x++)
            {
                LevelMap[y,x].SetActive(false);
            }
        }
    }
    public void ShowAllCells()
    {
        for (int y = 0; y < LevelSizeY; y++)
        {
            for (int x = 0; x < LevelSizeX; x++)
            {
                LevelMap[y, x].SetActive(true);
            }
        }
    }
}
