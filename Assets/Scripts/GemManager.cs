using UnityEngine;

public class GemManager : MonoBehaviour
{
    public static int gemCount = 0;

    void Start()
    {
        // �������� ���������� ����� �� ������������ �����
        gemCount = PlayerPrefs.GetInt("GemCount", 0);
    }

    public static void AddGems(int amount)
    {
        gemCount += amount;
        PlayerPrefs.SetInt("GemCount", gemCount);
        PlayerPrefs.Save();
    }
}
