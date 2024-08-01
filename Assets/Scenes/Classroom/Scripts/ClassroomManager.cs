using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClassroomManager : MonoBehaviour
{
    [SerializeField] private TMP_Text courseText;
    [SerializeField] private TMP_Text topicText;

    void Start()
    {
        courseText.text = GlobalStorage.CourseData.courses[TowerData.course].name;
        topicText.text = GlobalStorage.CourseData.courses[TowerData.course].topics[ClassroomData.topic].name;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
