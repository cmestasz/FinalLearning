using System.Collections;
using UnityEngine;

public class PersonController : AnyCharacterController, IKeyInteractable
{
    [SerializeField] private DialogueBox dialogueBox;
    private int dialogueIndex = 0;

    public IEnumerator Interact()
    {
        string dialogue = PersonDialogues.GetDialogue(dialogueIndex, characterName);
        dialogueIndex++;
        yield return DialogueBuilder.WriteDialogue(dialogueBox, dialogue, true);
    }

    // Start is called before the first frame update
    void Start()
    {
        ChooseNameSprite();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
