using UnityEngine;

public class SceneChangeButton : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private DialogueBox dialogueBox;
    [SerializeField] private bool validateClass;
    [SerializeField] private bool validateQuestion;
    [SerializeField] private bool validateEvaluator;

    public void OnClick()
    {
        if (ValidateWarp())
            StartCoroutine(SceneChanger.ChangeScene(sceneName));
    }

    private bool ValidateWarp()
    {
        if (validateClass && !ClassroomManager.classDone)
        {
            StartCoroutine(DialogueBuilder.WriteDialogue(dialogueBox, ValidationDialogues.CLASS_NOT_DONE, false));
            return false;
        }
        if (validateQuestion && TeacherController.blockLeave)
        {
            StartCoroutine(DialogueBuilder.WriteDialogue(dialogueBox, ValidationDialogues.WAIT_FOR_ANSWER, false));
            return false;
        }
        if (validateEvaluator && EvaluatorController.blockLeave)
        {
            StartCoroutine(DialogueBuilder.WriteDialogue(dialogueBox, ValidationDialogues.EVALUATION_NOT_DONE, false));
            return false;
        }
        return true;
    }
}
