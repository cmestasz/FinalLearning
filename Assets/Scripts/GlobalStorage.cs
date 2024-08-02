using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalStorage : MonoBehaviour
{
    public static CourseDataSO CourseData;
    public CourseDataSO courseData;

    void Awake()
    {
        CourseData = courseData;
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

    public static string GetTopic()
    {
        try
        {
            return CourseData.courses[TowerData.course].topics[ClassroomData.topic].name;
        }
        catch
        {
            return "tema por defecto";
        }
    }
}
