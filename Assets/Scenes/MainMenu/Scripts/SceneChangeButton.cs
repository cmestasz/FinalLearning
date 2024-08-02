using UnityEngine;

public class SceneChangeButton : MonoBehaviour
{
    [SerializeField] private string sceneName;

    public void OnClick()
    {
        StartCoroutine(SceneChanger.ChangeScene(sceneName));
    }
}
