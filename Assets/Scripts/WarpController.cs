using UnityEngine;

public abstract class WarpController : MonoBehaviour
{
    protected string sceneName;
    protected Vector3 playerDest;
    protected Transform player;

    public abstract void SetParams();
    public abstract bool ValidateWarp();
    public void Warp(Transform player, Vector3 playerDest)
    
    {
        if (ValidateWarp())
        {
            SetParams();
            StartCoroutine(SceneChanger.ChangeScene(sceneName, player, playerDest));
        }
    }
}
