using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achievements : MonoBehaviour
{
    public int DeathCounter, GemCounter;
    public GameObject DeathText,GemText;

    void Start()
    {
        if (PlayerPrefs.HasKey("DeathCounter")) DeathCounter = PlayerPrefs.GetInt("DeathCounter");
        else DeathCounter = 0;

        if (PlayerPrefs.HasKey("GemCounter")) GemCounter = PlayerPrefs.GetInt("GemCounter");
        else GemCounter = 0;

        DeathText.GetComponent<Text>().text = DeathCounter.ToString() + " / 100";
        GemText.GetComponent<Text>().text = GemCounter.ToString() + " / 10";
    }

    public void Clear()
    {
        DeathCounter = 0;
        GemCounter = 0;

        PlayerPrefs.SetInt("DeathCounter", 0);
        PlayerPrefs.SetInt("GemCounter", 0);

        DeathText.GetComponent<Text>().text = DeathCounter.ToString() + " / 100";
        GemText.GetComponent<Text>().text = GemCounter.ToString() + " / 10";
    }
}
