using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ResolutionButton : MonoBehaviour
{
    [SerializeField] private TMP_Text resolutionText;
    [SerializeField] private int direction;

    public void ClickAction()
    {
        Vector2[] resolutionsList = SettingsManager.resolutionsList;
        int resolutionIndex = PlayerPrefs.GetInt("resolutionIndex");
        switch (direction)
        {
            case 1:
                resolutionIndex++;
                if (resolutionIndex >= resolutionsList.Length)
                    resolutionIndex = 0;
                break;
            case -1:
                resolutionIndex--;
                if (resolutionIndex < 0)
                    resolutionIndex = resolutionsList.Length - 1;
                break;
        }
        PlayerPrefs.SetInt("resolutionIndex", resolutionIndex);
        Vector2 resolution = resolutionsList[resolutionIndex];
        Debug.Log("Resolution changed to " + resolution);
        resolutionText.text = resolution.x + "x" + resolution.y;
        Screen.SetResolution((int)resolution.x, (int)resolution.y, PlayerPrefs.GetInt("fullscreen") == 1);
        PlayerPrefs.Save();
    }
}