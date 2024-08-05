using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacherController : AnyCharacterController, IKeyInteractable
{
    [SerializeField] private DialogueBox dialogueBox;
    [SerializeField] private ClassroomManager classroomManager;
    [SerializeField] private PlayerController player;
    private string dialogueStart, dialogueEnd;
    public static bool blockLeave;

    public IEnumerator Interact()
    {
        //todo block player movement
        if (!ClassroomManager.classDone)
        {
            if (!classroomManager.classLoaded)
            {
                yield return DialogueBuilder.WriteDialogue(dialogueBox, $"{characterName}:Espera un momento, estoy cargando la clase.|||<<end", true);
                yield break;
            }
            yield return DialogueBuilder.WriteDialogue(dialogueBox, dialogueStart, true);
            classroomManager.StartClass();
        }
        else
        {
            if (blockLeave)
            {
                yield return DialogueBuilder.WriteDialogue(dialogueBox, $"{characterName}:Espera un momento, estoy respondiendo una pregunta.|||<<end", true);
                yield break;
            }
            blockLeave = true;
            PlayerController.canMove = false;
            yield return DialogueBuilder.WriteDialogue(dialogueBox, dialogueEnd, true);
            string question = dialogueBox.GetInput(0).Trim();
            dialogueBox.ClearInputs();
            yield return FetchAnswer(question);
        }
    }

    private IEnumerator FetchAnswer(string question)
    {
        void callback(Answer res)
        {
            string answer = res.answer;
            string dialogue = string.Join(
                "|||",
                new string[] {
                    $"{characterName}:{answer}",
                    "<<end"
                }
            );

            Debug.Log(dialogue);
            StartCoroutine(DialogueBuilder.WriteDialogue(dialogueBox, dialogue, true));
            blockLeave = false;
            PlayerController.canMove = true;
        }

        Dictionary<string, string> data = new()
        {
            { "course", GlobalStorage.GetCurrentCourse() },
            { "topicName", GlobalStorage.GetCurrentTopic().name },
            { "topicDescription", GlobalStorage.GetCurrentTopic().description },
            { "question", question }
        };

        yield return APIManager.PostRequest<Answer>("ask", data, callback);
    }

    private class Answer
    {
        public string answer;
    }

    // Start is called before the first frame update
    void Start()
    {
        blockLeave = false;
        ChooseNameSprite();
        string topic = GlobalStorage.GetCurrentTopic().name;
        dialogueStart = string.Join(
            "|||",
            new string[] {
                $"{characterName}:Hola! Listo para la clase de {topic}!",
                "<<click",
                "SISTEMA:Estas listo para la clase de",
                "<<timewait 0.25",
                $"{characterName}:No estaba preguntando!",
                "<<timewait 0.25",
                "<<forceend"
            }
        );

        dialogueEnd = string.Join(
            "|||",
            new string[] {
                $"{characterName}:Preguntas?",
                "<<click",
                "<<inputstart",
                "<<inputend",
                "<<forceend"
            }
        );
    }

    // Update is called once per frame
    void Update()
    {

    }
}
