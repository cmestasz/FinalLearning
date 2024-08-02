public class WorldWarp : WarpController
{
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
        return true;
    }
}
