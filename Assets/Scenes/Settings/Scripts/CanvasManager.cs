using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private TMP_Text resolutionText;
    [SerializeField] private TMP_Text volumeText;
    [SerializeField] private TMP_Text speedText;

    // Start is called before the first frame update
    void Start()
    {
        LoadCanvas();
    }

    // Update is called once per frame
    void Update()
    {

    }


    void LoadCanvas()
    {
        Vector2Int resolution = SettingsManager.GetResolution();
        resolutionText.text = resolution.x + "x" + resolution.y;
        volumeText.text = PlayerPrefs.GetInt("volume") + "%";
        speedText.text = PlayerPrefs.GetInt("speed") + "%";
    }
}