using UnityEngine;
using UnityEngine.UI;

public class GemCounter : MonoBehaviour
{
    public Text gemText;

    void Start()
    {
        if (gemText != null)
        {
            gemText.text = "Gems: " + GemManager.gemCount;
        }
        else
        {
            Debug.LogError("gemText is null in Start!");
        }
    }

    void Update()
    {
        if (gemText != null)
        {
            gemText.text = "Gems: " + GemManager.gemCount;
        }
        else
        {
            Debug.LogError("gemText is null in Update!");
        }
    }

}