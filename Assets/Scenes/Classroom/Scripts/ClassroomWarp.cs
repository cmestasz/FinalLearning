using UnityEngine;

public class ClassroomWarp : WarpController
{
    [SerializeField] private DialogueBox dialogueBox;
    public int topic;

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
        if (EvaluatorController.blockLeave)
        {
            Debug.Log("Can't leave yet");
            StartCoroutine(DialogueBuilder.WriteDialogue(dialogueBox, ValidationDialogues.EVALUATION_NOT_DONE, false));
            return false;
        }
        return true;
    }
}
