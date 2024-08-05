using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueBox : MonoBehaviour
{
    public bool writing;
    public bool inputting;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private TMP_InputField inputText;
    [SerializeField] private Animator clickImage;
    [SerializeField] private float writeDelay;
    private bool firstAnim = true;
    public List<string> inputList = new List<string>();


    void Start()
    {
    }

    public void WriteDialogue(string talker, string dialogue)
    {
        gameObject.SetActive(true);
        StartCoroutine(Write("<b>" + talker + "</b>\n" + dialogue));
    }

    public string GetInput(int index)
    {
        return inputList[index];
    }

    public string[] GetInputs()
    {
        return inputList.ToArray();
    }

    public void ClearInputs()
    {
        inputList.Clear();
    }

    public void SaveInput()
    {
        inputList.Add(inputText.text);
    }

    public void EnableInput()
    {
        inputText.gameObject.SetActive(true);
        clickImage.SetBool("IsVisible", false);
        dialogueText.gameObject.SetActive(false);
        inputting = true;
    }

    public void DisableInput()
    {
        inputText.text = "";
        inputText.gameObject.SetActive(false);
        dialogueText.gameObject.SetActive(true);
        inputting = false;
    }

    public void ClearDialogue()
    {
        dialogueText.text = "";
        clickImage.SetBool("IsVisible", false);
    }

    public void CloseDialogue()
    {
        ClearDialogue();
        writing = false;
        inputting = false;
        gameObject.SetActive(false);
    }

    private IEnumerator Write(string dialogue)
    {
        writing = true;
        if (firstAnim)
            firstAnim = false;
        else
            ClearDialogue();
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
        return !writing && !inputting && Input.GetMouseButton(0);
    }

    public bool CanConsecutiveWrite()
    {
        return !writing && !inputting;
    }

    public bool InputDone()
    {
        return Input.GetKeyDown(KeyCode.Return);
    }
}
