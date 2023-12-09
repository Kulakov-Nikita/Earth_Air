using UnityEngine;

public class Gem : MonoBehaviour
{
    public int gemValue = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("AirCharacter") || other.CompareTag("EarthCharacter"))
        {
            GemCounter.Instance.AddGems(gemValue);
            Debug.Log("GemCount: " + GemCounter.Instance.GemCount);

            Destroy(gameObject);
        }
    }
}