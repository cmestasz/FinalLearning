using UnityEngine;

public class WorldWarp : WarpController
{
    [SerializeField] private GameObject particles;
    [SerializeField] private EvaluatorController evaluator;
    [SerializeField] private DialogueBox dialogueBox;
    [SerializeField] private GameObject normalWarp;

    // Start is called before the first frame update
    void Start()
    {
        sceneName = "World";
    }

    public override void SetParams()
    {
        // tada
    }

    public override bool ValidateWarp()
    {
        if (evaluator != null && EvaluatorController.blockLeave)
        {
            Debug.Log("Can't leave yet");
            StartCoroutine(DialogueBuilder.WriteDialogue(dialogueBox, ValidationDialogues.EVALUATION_NOT_DONE, false));
            return false;
        }

        particles.transform.position = transform.position;
        particles.SetActive(true);
        normalWarp.SetActive(true);
        normalWarp.transform.position = transform.position;
        return true;
    }
}
