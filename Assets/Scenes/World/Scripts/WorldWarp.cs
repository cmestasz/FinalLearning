using UnityEngine;

public class WorldWarp : WarpController
{
    [SerializeField] private GameObject particles;
    // Start is called before the first frame update
    void Start()
    {
        sceneName = "World";
    }

    public override void SetParams()
    {
        // tada
    }

    public override bool ValidateWarp()
    {
        particles.transform.position = transform.position;
        particles.SetActive(true);
        return true;
    }
}
