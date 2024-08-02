using System.Collections;
using UnityEngine;

public class PersonController : AnyCharacterController, IKeyInteractable
{
    [SerializeField] private DialogueBox dialogueBox;

    public IEnumerator Interact()
    {
        string dialogue = PersonDialogues.GetRandomDialogue(characterName);

        yield return DialogueBuilder.WriteDialogue(dialogueBox, dialogue);
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
