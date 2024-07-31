
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CourseData", menuName = "ScriptableObjects/CourseData", order = 1)]
public class CourseDataSO : ScriptableObject
{
  public List<Course> courses;
}

[System.Serializable]
public class Course
{
  public string id;
  public string name;
  public List<Topic> topics = new();
}

[System.Serializable]
public class Topic
{
  public string name;
  public string description;
}