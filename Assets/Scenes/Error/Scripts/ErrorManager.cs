using System.Collections;
using UnityEngine;

public class ErrorManager : MonoBehaviour
{
  [SerializeField] private DialogueBox dialogueBox;
  private string dialogue;

  void Start()
  {
    string[] dialogueParts = {
      "SISTEMA:Algo ha salido mal con las peticiones a la IA, por seguridad, te hemos traido aquí.",
      "<<click",
      "SISTEMA:Espera un momento hasta asegurarnos que es seguro regresarte.",
      "<<click",
      "SISTEMA:Lamentamos los inconvenientes.",
      "<<end"
    };

    dialogue = string.Join("\n", dialogueParts);
    EvaluatorController.blockLeave = false;
    TeacherController.blockLeave = false;
    PlayerController.canMove = true;
    ClassroomManager.classDone = false;
    StartCoroutine(ErrorCoroutine());
  }

  private IEnumerator ErrorCoroutine()
  {
    yield return DialogueBuilder.WriteDialogue(dialogueBox, dialogue, true);
    yield return new WaitForSeconds(1);
    StartCoroutine(SceneChanger.ChangeScenePlayerless("MainMenu"));
  }
}