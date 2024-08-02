using System.Collections.Generic;

[System.Serializable]
public class CourseData
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

  public Topic()
  {
    name = "Tema por defecto";
    description = "Descripción por defecto";
  }
}