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

    public static bool AreAllCoursesDone()
    {
        foreach (bool done in coursesDone)
        {
            if (!done)
                return false;
        }
        return true;
    }

    public static Course GetCourse(int course)
    {
        try
        {
            return CourseData.courses[course];
        }
        catch
        {
            return new Course();
        }
    }

    public static bool IsCourseDone(int course)
    {
        try
        {
            return coursesDone[course];
        }
        catch
        {
            return false;
        }
    }

    public static string GetCurrentCourse()
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

    public static Topic GetCurrentTopic()
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
