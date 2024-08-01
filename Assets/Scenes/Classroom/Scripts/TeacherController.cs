using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacherController : MonoBehaviour, IKeyInteractable
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private DialogueBox dialogueBox;

    public IEnumerator Interact()
    {
        dialogueBox.WriteDialogue("waaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
        yield return new WaitUntil(dialogueBox.CanWrite);
        dialogueBox.WriteDialogue("waaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
        yield return new WaitUntil(dialogueBox.CanWrite);
        dialogueBox.CloseDialogue();
    }

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
    }

    // Update is called once per frame
    void Update()
    {

    }
}
