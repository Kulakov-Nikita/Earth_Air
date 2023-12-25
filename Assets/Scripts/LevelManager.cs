using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.U2D.Animation;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private AirCharScript playerAir;
    [SerializeField] private EarthCharScript playerEarth;
    [SerializeField] private Fan fan;
    [SerializeField] private GameObject Wind;
    private int ReadyPlayerCounter = 0;
    private bool airInDoor = false,earthInDoor=false;
    public UnityEvent LevelComplete = new UnityEvent();

    public int LevelSizeX = 10, LevelSizeY = 10;
    [SerializeField] private GameObject dirt, grass, slope1, slope2, door, gem, box, button;
    public Cell.CellType[,] LevelMap;
    public GameObject LeftDownCorner;

    public bool AirCanUseAbility()
    {
        return fan.isPlayerInside && !playerAir.isAirActive;
    }
    public void CreateWind()
    {
        Debug.Log("Level Manager [CreateWind]: " + "(fan.isPlayerInside=" + fan.isPlayerInside + ") (playerAir.isAirActive=" + playerAir.isAirActive + ")");
        if (fan.isPlayerInside && !playerAir.isAirActive) Instantiate(Wind, fan.transform.position + new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
    }

    public void loadingLevel()
    {
        Door doorForAir = null, doorForEarth = null;
        Button buttonForDoors = null;

        for (int y = 0; y < LevelSizeY; y++)
        {
            for (int x = 0; x < LevelSizeX; x++)
            {
                GameObject newCell = null;
                Vector3 shift = Vector3.zero;

                // Устанавливаем неинтерактивные элементы, гемы и ящики
                if (LevelMap[y, x] == Cell.CellType.Dirt) newCell = dirt;
                if (LevelMap[y, x] == Cell.CellType.Grass) newCell = grass;
                if (LevelMap[y, x] == Cell.CellType.Slope1) newCell = slope1;
                if (LevelMap[y, x] == Cell.CellType.Slope2) newCell = slope2;
                if (LevelMap[y, x] == Cell.CellType.Gem) newCell = gem;
                if (LevelMap[y, x] == Cell.CellType.Box) newCell = box;

                if (newCell != null) Instantiate(newCell, new Vector3(x, y, 0) + LeftDownCorner.transform.position + shift, new Quaternion(0, 0, 0, 0));
                
                // Устанавливаем интерактивные элементы
                if (LevelMap[y, x] == Cell.CellType.Door)
                {
                    newCell = door;
                    shift = new Vector3(0, 0.3f, 0);

                    var newDoor = Instantiate(newCell, new Vector3(x, y, 0) + LeftDownCorner.transform.position + shift, new Quaternion(0, 0, 0, 0));

                    if (doorForAir == null)
                    {
                        doorForAir = newDoor.GetComponent<Door>();

                        doorForAir.doorForAir = true;

                        doorForAir.CharacterGoIn.AddListener(AirInDoor);
                        doorForAir.CharacterGoOut.AddListener(AirOutDoor);

                        if(buttonForDoors != null)
                        {
                            buttonForDoors.buttonPressed.AddListener(doorForAir.onTogglePressed);
                            buttonForDoors.buttonReleased.AddListener(doorForAir.onToggleReleased);

                        }
                    }
                    else if (doorForEarth == null)
                    {
                        doorForEarth = newDoor.GetComponent<Door>();

                        doorForAir.doorForAir = false;

                        doorForEarth.CharacterGoIn.AddListener(EarthInDoor);
                        doorForEarth.CharacterGoOut.AddListener(EarthOutDoor);

                        if (buttonForDoors != null)
                        {
                            buttonForDoors.buttonPressed.AddListener(doorForEarth.onTogglePressed);
                            buttonForDoors.buttonReleased.AddListener(doorForEarth.onToggleReleased);

                        }
                    }
                    else Debug.LogError("LevelManager: Too many doors");

                }
                if (LevelMap[y, x] == Cell.CellType.Button)
                {
                    newCell = button;
                    Debug.Log("LevelManager: Button added");
                    shift = new Vector3(0, -0.4f, 0);

                    if (buttonForDoors == null)
                    {
                        var newButton = Instantiate(newCell, new Vector3(x, y, 0) + LeftDownCorner.transform.position + shift, new Quaternion(0, 0, 0, 0));
                        buttonForDoors = newButton.GetComponent<Button>();

                        if (doorForAir != null)
                        {
                            buttonForDoors.buttonPressed.AddListener(doorForAir.onTogglePressed);
                            buttonForDoors.buttonReleased.AddListener(doorForAir.onToggleReleased);
                        }
                        if (doorForEarth != null)
                        {
                            buttonForDoors.buttonPressed.AddListener(doorForEarth.onTogglePressed);
                            buttonForDoors.buttonReleased.AddListener(doorForEarth.onToggleReleased);
                        }
                    }
                }
            }
        }
    }
    public void AirInDoor()
    {
        airInDoor = true;
        Debug.LogWarning("LevelManager: AirInDoor");
        if (earthInDoor == true) LevelComplete.Invoke(); 
    }
    public void AirOutDoor()
    {
        airInDoor = false;
        Debug.LogWarning("LevelManager: AirOutDoor");
    }
    public void EarthInDoor()
    {
        earthInDoor = true;
        Debug.LogWarning("LevelManager: EarthInDoor");
        if (airInDoor == true) LevelComplete.Invoke();
    }
    public void EarthOutDoor()
    {
        Debug.LogWarning("LevelManager: EarthOutDoor");
        earthInDoor = false;
    }

}
