using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LocalizationManager : MonoBehaviour
{

    #region Singltone
    private static LocalizationManager _instance;
    public static LocalizationManager instance => _instance;

    private void Awake()
    {
        SetLanguage("Russian");

        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    #endregion


    private Dictionary<string, string> localizedText = new Dictionary<string, string>();
    private bool isReady = false;
    private string missingTextString = "Localized text not found";
    [HideInInspector] public List<LocalizedText> listLocalizedText = new List<LocalizedText>();
    string filePath;

    public void SetLanguage(string language)
    {
        PlayerPrefs.DeleteAll();
        string languageData = PlayerPrefs.GetString(language, $"{language}.json");
        LoadLocalizedText(languageData);
        DontDestroyOnLoad(gameObject);
    }

    public void LoadLocalizedText(string fileName)
    {
        PlayerPrefs.SetString("language", fileName);
        PlayerPrefs.Save();
        
        localizedText = new Dictionary<string, string>();

#if UNITY_ANDROID && !UNITY_EDITOR
        string path = Path.Combine(Application.streamingAssetsPath, fileName);
        WWW reader = new WWW(path);
        while (!reader.isDone) { }
        if (reader.error != null) { Debug.Log("error:" + reader.error); }
        filePath = Application.persistentDataPath + fileName;
        File.WriteAllBytes(filePath, reader.bytes);

#else
        filePath = Path.Combine(Application.streamingAssetsPath, fileName);
#endif

        if (File.Exists(filePath))
        {

            string dataAsJson = File.ReadAllText(filePath);
            LocalizationData loadedData = JsonUtility.FromJson<LocalizationData>(dataAsJson);

            for (int i = 0; i < loadedData.items.Length; i++)
            {
                localizedText.Add(loadedData.items[i].key, loadedData.items[i].value);
                
            }
        }
        else
        {
            Debug.LogError("Cannot find file!");
        }

        isReady = true;
    }

    
    public string GetLocalizedValue(string key)
    {
        string result = missingTextString;
        if (localizedText.ContainsKey(key))
        {
            result = localizedText[key];
        }
        return result;
    }
}