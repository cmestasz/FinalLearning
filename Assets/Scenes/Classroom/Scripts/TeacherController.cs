using System.Collections;
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
        string topic = GlobalStorage.CourseData.courses[TowerData.course].topics[ClassroomData.topic].name;
        // string topic = "tema";

        string dialogue = string.Join(
            "\n",
            new string[] {
                $"{teacherName}:Hola! Listo para tu clase de {topic}!",
                "<<click",
                "SISTEMA:Estas listo para la clase de",
                "<<wait 0.25",
                $"{teacherName}:No estaba preguntando!",
                "<<wait 0.25",
                "<<end"
            }
        );

        yield return DialogueBuilder.WriteDialogue(dialogueBox, dialogue);


        classroomManager.StartClass();
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
