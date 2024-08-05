using UnityEngine;

public class TowerWarp : WarpController
{
    public enum WarpType { Up, Down, FromOutside, FromInside };
    [SerializeField] private int course;
    [SerializeField] private int floor;
    [SerializeField] private UnityEngine.GameObject particles;
    private int floorDest;
    private int courseDest;
    private WarpType cameFrom;
    [SerializeField] private WarpType warpType;
    [SerializeField] private DialogueBox dialogueBox;
    [SerializeField] private EvaluatorController evaluator;

    void Start()
    {
        sceneName = "Tower";
        courseDest = TowerData.course;
    }

    public override void SetParams()
    {
        TowerData.course = courseDest;
        TowerData.floor = floorDest;
        TowerData.cameFrom = cameFrom;
    }

    public override bool ValidateWarp()
    {
        if (evaluator != null && EvaluatorController.blockLeave)
        {
            Debug.Log("Can't leave yet");
            StartCoroutine(DialogueBuilder.WriteDialogue(dialogueBox, ValidationDialogues.EVALUATION_NOT_DONE, false));
            return false;
        }

        switch (warpType)
        {
            case WarpType.Up:
                if (TowerData.floor >= TowerData.MAX_FLOOR)
                {
                    Debug.Log("No way up");
                    StartCoroutine(DialogueBuilder.WriteDialogue(dialogueBox, ValidationDialogues.NO_WAY_UP, false));
                    return false;
                }
                floorDest = TowerData.floor + 1;
                break;
            case WarpType.Down:
                if (TowerData.floor <= 0)
                {
                    Debug.Log("No way down");
                    StartCoroutine(DialogueBuilder.WriteDialogue(dialogueBox, ValidationDialogues.NO_WAY_DOWN, false));
                    return false;
                }
                floorDest = TowerData.floor - 1;
                break;
            case WarpType.FromOutside:
                floorDest = floor;
                courseDest = course;
                particles.transform.position = transform.position;
                particles.SetActive(true);
                break;
            case WarpType.FromInside:
                floorDest = TowerData.floor;
                courseDest = TowerData.course;
                if (!ClassroomManager.classDone)
                {
                    Debug.Log("Class not done");
                    StartCoroutine(DialogueBuilder.WriteDialogue(dialogueBox, ValidationDialogues.CLASS_NOT_DONE, false));
                    return false;
                }
                if (TeacherController.blockLeave)
                {
                    Debug.Log("Wait for answer");
                    StartCoroutine(DialogueBuilder.WriteDialogue(dialogueBox, ValidationDialogues.WAIT_FOR_ANSWER, false));
                    return false;
                }
                break;
        }
        cameFrom = warpType;
        return true;
    }
}
