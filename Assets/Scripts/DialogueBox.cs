using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueBox : MonoBehaviour
{
    public bool writing;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private Animator clickImage;
    [SerializeField] private float writeDelay;
    private bool firstAnim = true;


    void Start()
    {
    }

    public void WriteDialogue(string talker, string dialogue)
    {
        gameObject.SetActive(true);
        StartCoroutine(Write("<b>" + talker + "</b>\n" + dialogue));
    }

    public void ClearDialogue()
    {
        dialogueText.text = "";
        clickImage.SetBool("IsVisible", false);
    }

    public void CloseDialogue()
    {
        ClearDialogue();
        gameObject.SetActive(false);
    }

    private IEnumerator Write(string dialogue)
    {
        if (firstAnim)
            firstAnim = false;
        else
            ClearDialogue();
        writing = true;
        foreach (char letter in dialogue)
        {
            dialogueText.text += letter;
            float delay = writeDelay;
            if (letter == '\n')
                delay *= 4;
            yield return new WaitForSeconds(delay);
        }
        writing = false;
        clickImage.SetBool("IsVisible", true);
    }

    public bool CanWrite()
    {
        return !writing && Input.GetMouseButton(0);
    }

    public bool CanConsecutiveWrite()
    {
        return !writing;
    }
}
