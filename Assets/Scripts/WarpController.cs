using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WarpController : MonoBehaviour
{
    protected string sceneName;

    public abstract void SetParams();
    public abstract bool ValidateWarp();
    public void Warp()
    {
        if (ValidateWarp())
        {
            SetParams();
            StartCoroutine(SceneChanger.ChangeScene(sceneName));
        }
    }
}
