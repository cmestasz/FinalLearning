using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public static Vector2[] resolutionsList = { new(640, 480), new(1280, 720), new(1366, 768), new(1600, 900), new(1920, 1080), new(1920, 1200), new(2560, 1440), new(2560, 1600) };

    void Start()
    {
        LoadSettings();
    }

    public void LoadSettings()
    {
        if (!PlayerPrefs.HasKey("resolutionIndex"))
            PlayerPrefs.SetInt("resolutionIndex", 0);
        if (!PlayerPrefs.HasKey("volume"))
            PlayerPrefs.SetInt("volume", 25);
        if (!PlayerPrefs.HasKey("speed"))
            PlayerPrefs.SetInt("speed", 50);
        PlayerPrefs.Save();

        int resolutionIndex = PlayerPrefs.GetInt("resolutionIndex", 0);
        Vector2 resolution = resolutionsList[resolutionIndex];
        Screen.SetResolution((int)resolution.x, (int)resolution.y, false);
    }
}