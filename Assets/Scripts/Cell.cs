using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public enum CellType { Empty, Dirt, Grass, Slope1, Slope2, Door, Gem, Box, Button };
    public static int NumberOfCellTypes = 9;

    public ResourseManager resourseManager;

    public CellType cellType = CellType.Empty;
    public void OnCellClicked()
    {
        cellType++;
        if ((int)cellType >= NumberOfCellTypes) cellType = CellType.Empty;
        GetComponent<Image>().sprite = resourseManager.GetSprite(cellType);
    }
    public void UpdateSprite()
    {
        GetComponent<Image>().sprite = resourseManager.GetSprite(cellType);
    }
}
