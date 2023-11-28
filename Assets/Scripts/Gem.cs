using UnityEngine;

public class Gem : MonoBehaviour
{
    public int gemValue = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GemManager.AddGems(gemValue);
            Debug.Log("GemCount: " + GemManager.gemCount);

            // ������������� ����� ������������� �������� ��� ���� ����� ����

            Destroy(gameObject);

            PlayerPrefs.SetInt("GemCounter", PlayerPrefs.GetInt("GemCounter", 0) + 1);
        }
    }
}