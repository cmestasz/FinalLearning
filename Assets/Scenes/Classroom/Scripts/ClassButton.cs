using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassButton : MonoBehaviour
{
    private enum Types { Next, Prev, End }
    [SerializeField] private Types type;
    [SerializeField] private ClassroomManager classroomManager;

    void OnMouseDown()
    {
        switch (type)
        {
            case Types.Next:
                classroomManager.NextPage();
                break;
            case Types.Prev:
                classroomManager.PrevPage();
                break;
            case Types.End:
                classroomManager.EndClass();
                break;
        }
    }
}
