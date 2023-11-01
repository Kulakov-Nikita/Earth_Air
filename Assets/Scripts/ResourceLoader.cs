using System.Collections.Generic;
using System.IO;
using System.Drawing;
using UnityEngine;

public class ResourceLoader : MonoBehaviour
{
    [SerializeField] private Dictionary<string, Sprite> textures = new Dictionary<string, Sprite>();
    public Sprite sprite;
    public string path = Application.dataPath;
    public Sprite getTexture(string name)
    {
        return Resources.Load<Sprite>("Textures/"+name);
    }
    public GameObject loadMap(string name)
    {
        return Resources.Load<GameObject>("Prefabs/" + name);
    }
    public GameObject loadPlayer(string name)
    {
        return Resources.Load<GameObject>("Prefabs/" + name);
    }
}
