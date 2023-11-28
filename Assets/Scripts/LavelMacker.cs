using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LavelMacker : MonoBehaviour
{
    public Canvas canvas;
    public enum CellType { Empty, Dirt, Grass, Slope1, Slope2, Door, Gem }
    public int LevelSizeX=10,LevelSizeY=10;
    [SerializeField] private GameObject empty, dirt, grass, slope1, slope2, door, gem;
    public CellType[,] LevelMap;
    private GameObject[,] LevelMapGO;
    private LevelSaver levelSaver;

    public GameObject text;
    private void Awake()
    {
        levelSaver = GetComponent<LevelSaver>();
        LevelMap = new CellType[LevelSizeY, LevelSizeX];
        for (int y = 0; y < LevelSizeY; y++)
        {
            for (int x = 0; x < LevelSizeX; x++)
            {
                LevelMap[y,x] = CellType.Empty;
            }
        }
    }
    void Start()
    {
        LevelMapGO = new GameObject[LevelSizeY, LevelSizeX];
        InstantiateLevel();
    }
    private void InstantiateLevel()
    {
        for (int y = 0; y < LevelSizeY; y++)
        {
            for (int x = 0; x < LevelSizeX; x++)
            {
                GameObject newCell = empty;
                if (LevelMap[y, x] == CellType.Empty) newCell = empty;
                if (LevelMap[y, x] == CellType.Dirt) newCell = dirt;
                if (LevelMap[y, x] == CellType.Grass) newCell = grass;
                if (LevelMap[y, x] == CellType.Slope1) newCell = slope1;
                if (LevelMap[y, x] == CellType.Slope2) newCell = slope2;
                if (LevelMap[y, x] == CellType.Door) newCell = door;
                if (LevelMap[y, x] == CellType.Gem) newCell = gem;
                LevelMapGO[y, x] = Instantiate(newCell, new Vector3(x * 100 + canvas.transform.position.x / 4, y * 100 + canvas.transform.position.y / 5, 0), new Quaternion(0, 0, 0, 0)) as GameObject;
                LevelMapGO[y, x].transform.SetParent(canvas.transform);
                LevelMapGO[y, x].GetComponent<Cell>().cellType = LevelMap[y, x];
            }
        }
    }
    private void DestroyLevel()
    {
        foreach(var LMGO in LevelMapGO)
        {
            Destroy(LMGO);
        }
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadSceneAsync("Main Menu");
    }

    public void SaveLevel()
    {
        for (int y = 0; y < LevelSizeY; y++)
        {
            for (int x = 0; x < LevelSizeX; x++)
            {
                LevelMap[y, x] = LevelMapGO[y, x].GetComponent<Cell>().cellType;
            }
        }

        levelSaver.data.LevelMap = LevelMap;
        levelSaver.data.LevelSizeX = LevelSizeX;
        levelSaver.data.LevelSizeY = LevelSizeY;
        levelSaver.Save(text.GetComponent<Text>().text);
    }
    public void LoadLevel()
    {
        DestroyLevel();
        levelSaver.Load(text.GetComponent<Text>().text);
        LevelSizeX = levelSaver.data.LevelSizeX;
        LevelSizeY = levelSaver.data.LevelSizeY;
        LevelMap = levelSaver.data.LevelMap;
        InstantiateLevel();
    }

}
