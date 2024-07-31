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
}
