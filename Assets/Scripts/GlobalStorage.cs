using UnityEngine;

public class GlobalStorage : MonoBehaviour
{
    public static CourseData CourseData;
    public static bool[] coursesDone;

    void Awake()
    {
        CourseData = JsonUtility.FromJson<CourseData>(Resources.Load<TextAsset>("CourseData").text);
        coursesDone = new bool[CourseData.courses.Count];
    }

    public static bool AllDone()
    {
        foreach (bool done in coursesDone)
        {
            if (!done)
                return false;
        }
        return true;
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
