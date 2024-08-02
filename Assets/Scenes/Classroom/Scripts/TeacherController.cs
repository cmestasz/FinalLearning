using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacherController : MonoBehaviour, IKeyInteractable
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private string[] teacherNames;
    private string teacherName;
    [SerializeField] private DialogueBox dialogueBox;
    [SerializeField] private ClassroomManager classroomManager;

    public IEnumerator Interact()
    {
        string topic = GlobalStorage.GetTopic();

        string dialogueStart = string.Join(
            "\n",
            new string[] {
                $"{teacherName}:Hola! Listo para tu clase de {topic}!",
                "<<click",
                "SISTEMA:Estas listo para la clase de",
                "<<timewait 0.25",
                $"{teacherName}:No estaba preguntando!",
                "<<timewait 0.25",
                "<<forceend"
            }
        );

        string dialogueEnd = string.Join(
            "\n",
            new string[] {
                $"{teacherName}:Preguntas?",
                "<<click",
                "<<inputstart",
                "<<inputend",
                "<<forceend"
            }
        );


        if (!classroomManager.classDone)
        {
            yield return DialogueBuilder.WriteDialogue(dialogueBox, dialogueStart);
            classroomManager.StartClass();
        }
        else
        {
            yield return DialogueBuilder.WriteDialogue(dialogueBox, dialogueEnd);
            string question = dialogueBox.GetInput(0);
            dialogueBox.ClearInputs();
            yield return FetchResponse(question);
        }
    }

    private IEnumerator FetchResponse(string question)
    {
        void callback(string response)
        {
            Debug.Log(response);
            string answer = JsonUtility.FromJson<Response>(response).answer;
            string dialogue = string.Join(
                "\n",
                new string[] {
                    $"{teacherName}:{answer}",
                    "<<end"
                }
            );

            Debug.Log(dialogue);
            StartCoroutine(DialogueBuilder.WriteDialogue(dialogueBox, dialogue));
        }

        Dictionary<string, string> data = new()
        {
            { "question", question }
        };

        yield return APIManager.PostRequest("http://localhost:5000/question", data, callback);
    }

    private class Response
    {
        public string answer;
    }



    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
        teacherName = teacherNames[Random.Range(0, teacherNames.Length)];
    }

    // Update is called once per frame
    void Update()
    {

    }
}
