using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public Sprite empty, dirt, grass, slope1, slope2;
    public LavelMacker.CellType cellType = LavelMacker.CellType.Empty;
    public void OnCellClicked()
    {
        if (cellType == LavelMacker.CellType.Empty)
        {
            cellType = LavelMacker.CellType.Dirt;
            GetComponent<Image>().sprite = dirt;
        }
        else if (cellType == LavelMacker.CellType.Dirt)
        {
            cellType = LavelMacker.CellType.Grass;
            GetComponent<Image>().sprite = grass;
        }
        else if (cellType == LavelMacker.CellType.Grass)
        {
            cellType = LavelMacker.CellType.Slope1;
            GetComponent<Image>().sprite = slope1;
        }
        else if (cellType == LavelMacker.CellType.Slope1)
        {
            cellType = LavelMacker.CellType.Slope2;
            GetComponent<Image>().sprite = slope2;
        }
        else if (cellType == LavelMacker.CellType.Slope2)
        {
            cellType = LavelMacker.CellType.Empty;
            GetComponent<Image>().sprite = empty;
        }
    }
}
