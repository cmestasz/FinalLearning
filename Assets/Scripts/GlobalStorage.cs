using UnityEngine;

public class GlobalStorage : MonoBehaviour
{
    public static CourseData CourseData;
    public static bool[] coursesDone;
    private static bool initialized = false;

    void Awake()
    {
        if (!initialized)
        {
            CourseData = JsonUtility.FromJson<CourseData>(Resources.Load<TextAsset>("CourseData").text);
            coursesDone = new bool[CourseData.courses.Count];
            initialized = true;
        }
    }

    public static bool AreAllCoursesDone()
    {
        try
        {
            foreach (bool done in coursesDone)
            {
                if (!done)
                    return false;
            }
            return true;
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
            return false;
        }
    }

    public static Course GetCourse(int course)
    {
        try
        {
            return CourseData.courses[course];
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
            return new Course();
        }
    }

    public static void SetCourseDone()
    {
        try
        {
            coursesDone[TowerData.course] = true;
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
            return;
        }
    }

    public static bool IsCourseDone()
    {
        try
        {
            return coursesDone[TowerData.course];
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
            return false;
        }
    }

    public static string GetCurrentCourse()
    {
        try
        {
            return CourseData.courses[TowerData.course].name;
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
            return "curso por defecto";
        }
    }

    public static Topic GetCurrentTopic()
    {
        try
        {
            return CourseData.courses[TowerData.course].topics[ClassroomData.topic];
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
            return new Topic();
        }
    }
}
