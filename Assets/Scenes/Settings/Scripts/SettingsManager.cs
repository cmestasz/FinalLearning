using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public static Vector2Int[] resolutionsList = { new(640, 480), new(1280, 720), new(1366, 768) };

    void Awake()
    {
        LoadSettings();
    }

    public static Vector2Int GetResolution()
    {
        int resolutionIndex = PlayerPrefs.GetInt("resolutionIndex", 0);
        return resolutionsList[resolutionIndex];
    }

    public void LoadSettings()
    {
        if (!PlayerPrefs.HasKey("resolutionIndex"))
            PlayerPrefs.SetInt("resolutionIndex", 1);
        if (!PlayerPrefs.HasKey("volume"))
            PlayerPrefs.SetInt("volume", 40);
        if (!PlayerPrefs.HasKey("speed"))
            PlayerPrefs.SetInt("speed", 50);
        PlayerPrefs.Save();

        Vector2Int resolution = GetResolution();
        Screen.SetResolution(resolution.x, resolution.y, false);
    }
}