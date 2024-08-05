using TMPro;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject evaluator;
    [SerializeField] private ClassroomWarp[] classroomWarps;
    [SerializeField] private TMP_Text[] classroomTexts;
    [SerializeField] private Transform[] classroomBackWarps;
    [SerializeField] private Transform outsideWarp;
    [SerializeField] private Transform upWarp;
    [SerializeField] private Transform downWarp;
    [SerializeField] private TMP_Text courseText;
    [SerializeField] private TMP_Text floorText;
    [SerializeField] private GameObject fireworks;
    private const int CLASSROOMS_PER_FLOOR = 4;

    // Start is called before the first frame update
    void Start()
    {
        courseText.text = GlobalStorage.GetCurrentCourse();
        floorText.text = "Piso " + (TowerData.floor + 1);
        Vector2 pos = Vector2.zero;

        if (TowerData.floor == TowerData.MAX_FLOOR)
        {
            evaluator.SetActive(true);
        }

        for (int i = 0; i < CLASSROOMS_PER_FLOOR; i++)
        {
            classroomTexts[i].text = GlobalStorage.GetTopic(TowerData.floor * CLASSROOMS_PER_FLOOR + i).name;
            classroomWarps[i].topic = TowerData.floor * CLASSROOMS_PER_FLOOR + i;
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

        if (GlobalStorage.IsCourseDone())
            fireworks.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
