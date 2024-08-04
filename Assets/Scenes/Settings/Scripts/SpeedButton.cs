using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class SpeedButton : MonoBehaviour
{
    [SerializeField] private TMP_Text speedText;
    [SerializeField] private int direction;

    public void ClickAction()
    {
        int speed = PlayerPrefs.GetInt("speed");
        switch (direction)
        {
            case -3:
                speed -= 10;
                break;
            case -2:
                speed -= 5;
                break;
            case -1:
                speed -= 1;
                break;
            case 1:
                speed += 1;
                break;
            case 2:
                speed += 5;
                break;
            case 3:
                speed += 10;
                break;
        }
        speed = Mathf.Clamp(speed, 0, 100);
        PlayerPrefs.SetInt("speed", speed);
        Debug.Log("Speed changed to " + speed);
        speedText.text = speed + "%";
        PlayerPrefs.Save();
    }
}