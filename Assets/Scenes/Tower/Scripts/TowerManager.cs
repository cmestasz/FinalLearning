using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private ClassroomWarp[] classroomWarps;
    [SerializeField] private Transform[] classroomBackWarps;
    [SerializeField] private Transform outsideWarp;
    [SerializeField] private Transform upWarp;
    [SerializeField] private Transform downWarp;
    private const int CLASSROOMS_PER_FLOOR = 4;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(TowerData.floor);
        Debug.Log(GlobalStorage.CourseData.courses[TowerData.course].name);
        Vector2 pos = Vector2.zero;

        foreach (ClassroomWarp clsw in classroomWarps)
        {
            clsw.topic = TowerData.floor * CLASSROOMS_PER_FLOOR + clsw.topic;
        }

        switch (TowerData.cameFrom)
        {
            case TowerWarp.WarpType.FromOutside:
                pos = outsideWarp.position;
                break;
            case TowerWarp.WarpType.FromInside:
                pos = classroomBackWarps[ClassroomData.topic % CLASSROOMS_PER_FLOOR].position;
                break;
            case TowerWarp.WarpType.Up:
                pos = upWarp.position;
                break;
            case TowerWarp.WarpType.Down:
                pos = downWarp.position;
                break;
        }
        player.transform.position = new Vector3(pos.x, pos.y, player.transform.position.z);
        Camera.main.transform.position = new Vector3(pos.x, pos.y, Camera.main.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
