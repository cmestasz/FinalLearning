using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndController : MonoBehaviour
{
    [SerializeField] private DialogueBox dialogueBox;
    [SerializeField] private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void EndGame()
    {
        gameObject.SetActive(true);
        StartCoroutine(EndGameCoroutine());
    }

    private IEnumerator EndGameCoroutine()
    {
        player.canMove = false;
        yield return new WaitForSeconds(3);
        yield return DialogueBuilder.WriteDialogue(dialogueBox, "El autor:Gracias por jugar.\n<<end", true);
        yield return new WaitForSeconds(2);
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
