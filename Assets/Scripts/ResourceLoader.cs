using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ResourceLoader
{
    public Sprite getTexture(string name)
    {
        return Resources.Load<Sprite>("Textures/" + name);
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
