using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GemCounter : MonoBehaviour
{
    [SerializeField]
    private Text gemText;

    private int gemCount = 0;
    private string jsonDataPath;

    public static event System.Action<int> OnGemCountChanged;

    private static GemCounter _instance;
    public static GemCounter Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GemCounter>();
            }
            return _instance;
        }
    }

    public int GemCount
    {
        get { return gemCount; }
    }

    void OnEnable()
    {
        // Подписываемся на событие при включении объекта
        OnGemCountChanged += UpdateGemCountUI;
    }

    void OnDisable()
    {
        // Отписываемся от события при выключении объекта
        OnGemCountChanged -= UpdateGemCountUI;
    }

    void Start()
    {
        gemText.fontSize = 64;
        jsonDataPath = Application.persistentDataPath + "/gemData.json";
        LoadGemCount();
        UpdateGemCountUI(gemCount);
    }

    private void LoadGemCount()
    {
        if (File.Exists(jsonDataPath))
        {
            string jsonData = File.ReadAllText(jsonDataPath);
            GemData data = JsonUtility.FromJson<GemData>(jsonData);
            gemCount = data.gemCount;
            // Вызываем событие при загрузке, чтобы обновить UI
            if (OnGemCountChanged != null)
            {
                OnGemCountChanged.Invoke(gemCount);
            }
        }
    }

    private void SaveGemCount()
    {
        GemData data = new GemData { gemCount = gemCount };
        string jsonData = JsonUtility.ToJson(data);
        File.WriteAllText(jsonDataPath, jsonData);
    }

    public void AddGems(int amount)
    {
        gemCount += amount;
        SaveGemCount();
        if (OnGemCountChanged != null)
        {
            OnGemCountChanged.Invoke(gemCount);
        }
        Debug.Log("GemCount: " + gemCount);
    }

    private void UpdateGemCountUI(int count)
    {
        if (gemText != null)
        {
            gemText.text = "Gems: " + count;
        }
        else
        {
            Debug.LogError("gemText is null!");
        }
    }


    [System.Serializable]
    private class GemData
    {
        public int gemCount;
    }
}
