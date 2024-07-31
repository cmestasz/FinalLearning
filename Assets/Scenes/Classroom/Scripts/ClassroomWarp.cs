using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassroomWarp : WarpController
{
    [SerializeField] private string topic;

    void Start()
    {
        sceneName = "Classroom";
    }

    public override void SetParams()
    {
        ClassroomData.topic = topic;
    }

    public override bool ValidateWarp()
    {
        return true;
    }
}
