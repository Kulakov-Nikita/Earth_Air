using UnityEngine;

public class Gem : MonoBehaviour
{
    public int gemValue = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("AirCharacter") || other.CompareTag("EarthCharacter"))
        {
            GemManager.AddGems(gemValue);
            Debug.Log("GemCount: " + GemManager.gemCount);

            // Дополнительно можно воспроизвести анимацию или звук сбора гема

            Destroy(gameObject);

            PlayerPrefs.SetInt("GemCounter", PlayerPrefs.GetInt("GemCounter", 0) + 1);
        }
    }
}