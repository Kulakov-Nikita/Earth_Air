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
    public AudioClip loadAudio(string name)
    {
        return Resources.Load<AudioClip>("Audio/" + name);
    }
    public Canvas loadCanvas(string name)
    {
        return Resources.Load<Canvas>("Canvas/" + name);
    }
}
