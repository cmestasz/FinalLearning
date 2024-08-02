using UnityEngine;

public class GlobalStorage : MonoBehaviour
{
    public static CourseData CourseData;

    void Awake()
    {
        CourseData = JsonUtility.FromJson<CourseData>(Resources.Load<TextAsset>("CourseData").text);
    }

    public static string GetCourse()
    {
        try
        {
            return CourseData.courses[TowerData.course].name;
        }
        catch
        {
            return "curso por defecto";
        }
    }

    public static Topic GetTopic()
    {
        try
        {
            return CourseData.courses[TowerData.course].topics[ClassroomData.topic];
        }
        catch
        {
            return new Topic();
        }
    }
}
