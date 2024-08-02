using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassButton : MonoBehaviour
{
    [SerializeField] private bool right;
    [SerializeField] private ClassroomManager classroomManager;

    void OnMouseDown()
    {
        if (right)
            classroomManager.NextPage();
        else
            classroomManager.PrevPage();
    }
}
