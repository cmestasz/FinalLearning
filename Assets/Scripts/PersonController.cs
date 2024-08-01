using System.Collections;
using UnityEngine;

public class PersonController : MonoBehaviour, IKeyInteractable
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private string[] personNames;
    private string personName;
    [SerializeField] private DialogueBox dialogueBox;

    public IEnumerator Interact()
    {
        string dialogue = PersonDialogues.GetRandomDialogue(personName);

        yield return DialogueBuilder.WriteDialogue(dialogueBox, dialogue);
    }

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
        personName = personNames[Random.Range(0, personNames.Length)];
    }

    // Update is called once per frame
    void Update()
    {

    }
}
