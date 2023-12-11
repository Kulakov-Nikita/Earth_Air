using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourseManager : MonoBehaviour 
{
    public Sprite Empty;
    public Sprite Dirt;
    public Sprite Grass;
    public Sprite Slope1;
    public Sprite Slope2;
    public Sprite Door;
    public Sprite Gem;
    public Sprite Box;
    public Sprite _Button;

    public Sprite GetSprite(Cell.CellType cellType)
    {
        switch(cellType)
        {
            case Cell.CellType.Empty: return Empty;
            case Cell.CellType.Dirt: return Dirt;
            case Cell.CellType.Grass: return Grass;
            case Cell.CellType.Slope1: return Slope1;
            case Cell.CellType.Slope2: return Slope2;
            case Cell.CellType.Door: return Door;
            case Cell.CellType.Gem: return Gem;
            case Cell.CellType.Box: return Box;
            case Cell.CellType.Button: return _Button;
            default:return Empty;  
        }
    }
}
