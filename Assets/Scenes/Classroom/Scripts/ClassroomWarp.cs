public class ClassroomWarp : WarpController
{
    public int topic;

    void Start()
    {
        sceneName = "Classroom";
    }

    public override void SetParams()
    {
        ClassroomData.topic = topic;
    }

    public override bool ValidateWarp()
    {
        return true;
    }
}
