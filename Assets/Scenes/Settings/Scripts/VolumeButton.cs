using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class VolumeButton : MonoBehaviour
{
    [SerializeField] private TMP_Text volumeText;
    [SerializeField] private int direction;

    public void ClickAction()
    {
        int volume = PlayerPrefs.GetInt("volume");
        switch (direction)
        {
            case -3:
                volume -= 10;
                break;
            case -2:
                volume -= 5;
                break;
            case -1:
                volume -= 1;
                break;
            case 1:
                volume += 1;
                break;
            case 2:
                volume += 5;
                break;
            case 3:
                volume += 10;
                break;
        }
        volume = Mathf.Clamp(volume, 0, 100);
        PlayerPrefs.SetInt("volume", volume);
        Debug.Log("Volume changed to " + volume);
        volumeText.text = volume + "%";
        PlayerPrefs.Save();
    }
}