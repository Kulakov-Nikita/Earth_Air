using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using static LavelMacker;

public class LevelSaver : MonoBehaviour
{
    [System.Serializable]
    public class LevelMapArray
    {
        public int LevelSizeX = 10, LevelSizeY = 10;
        public CellType[,] LevelMap;
    }
    public LevelMapArray data;
    public void Save(string levelName)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream fs = new FileStream(Application.dataPath + "/" + levelName + ".lvl", FileMode.OpenOrCreate))
        {
            formatter.Serialize(fs, data);
            //Debug.Log(Application.dataPath + "/LevelMapArray.lvl");
        }
    }
    public void Load(string levelName)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        Debug.Log(Application.dataPath + "/" + levelName + ".lvl");
        using (FileStream fs = new FileStream(Application.dataPath + "/" + levelName +".lvl", FileMode.OpenOrCreate))
        {            
            data = (LevelMapArray)formatter.Deserialize(fs);
        }
    }
}
