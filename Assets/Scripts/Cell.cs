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
    }
}
