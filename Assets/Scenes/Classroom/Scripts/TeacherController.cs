using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacherController : AnyCharacterController, IKeyInteractable
{
    [SerializeField] private DialogueBox dialogueBox;
    [SerializeField] private ClassroomManager classroomManager;
    private string dialogueStart, dialogueEnd;
    public static bool blockLeave = false;

    public IEnumerator Interact()
    {
        if (!ClassroomManager.classDone)
        {
            if (!classroomManager.classLoaded)
            {
                yield return DialogueBuilder.WriteDialogue(dialogueBox, $"{characterName}:Espera un momento, estoy cargando la clase.\n<<end", true);
                yield break;
            }
            yield return DialogueBuilder.WriteDialogue(dialogueBox, dialogueStart, true);
            classroomManager.StartClass();
        }
        else
        {
            if (blockLeave)
            {
                yield return DialogueBuilder.WriteDialogue(dialogueBox, $"{characterName}:Espera un momento, estoy respondiendo una pregunta.\n<<end", true);
                yield break;
            }
            blockLeave = true;
            yield return DialogueBuilder.WriteDialogue(dialogueBox, dialogueEnd, true);
            string question = dialogueBox.GetInput(0);
            dialogueBox.ClearInputs();
            yield return FetchAnswer(question);
        }
    }

    private IEnumerator FetchAnswer(string question)
    {
        void callback(string response)
        {
            Debug.Log(response);
            string answer = JsonUtility.FromJson<Answer>(response).answer;
            string dialogue = string.Join(
                "\n",
                new string[] {
                    $"{characterName}:{answer}",
                    "<<end"
                }
            );

            Debug.Log(dialogue);
            StartCoroutine(DialogueBuilder.WriteDialogue(dialogueBox, dialogue, true));
            blockLeave = false;
        }

        Dictionary<string, string> data = new()
        {
            { "question", question }
        };

        yield return APIManager.PostRequest("http://localhost:5000/question", data, callback);
    }

    private class Answer
    {
        public string answer;
    }

    // Start is called before the first frame update
    void Start()
    {
        ChooseNameSprite();
        string topic = GlobalStorage.GetCurrentTopic().name;
        dialogueStart = string.Join(
            "\n",
            new string[] {
                $"{characterName}:Hola! Listo para tu clase de {topic}!",
                "<<click",
                "SISTEMA:Estas listo para la clase de",
                "<<timewait 0.25",
                $"{characterName}:No estaba preguntando!",
                "<<timewait 0.25",
                "<<forceend"
            }
        );

        dialogueEnd = string.Join(
            "\n",
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
