using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassroomManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(GlobalStorage.CourseData.courses[TowerData.course].topics[ClassroomData.topic].name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
