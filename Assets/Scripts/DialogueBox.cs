using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueBox : MonoBehaviour
{
    public bool writing;
    public static DialogueBox instance;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private Animator clickImage;
    [SerializeField] private bool singleton;
    [SerializeField] private float writeDelay;
    private bool firstAnim = true;
    

    void Start()
    {
        GameObject parent = transform.parent.gameObject;
        if (singleton)
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(parent);
            }
            else
            {
                Destroy(parent);
            }
        }
    }

    public void WriteDialogue(string dialogue)
    {
        StartCoroutine(Write(dialogue));
    }

    public void ClearDialogue()
    {
        dialogueText.text = "";
        clickImage.SetTrigger("FadeOut");
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
        gameObject.SetActive(true);
        writing = true;
        foreach (char letter in dialogue)
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(writeDelay);
        }
        writing = false;
        clickImage.SetTrigger("FadeIn");
    }

    public bool CanWrite()
    {
        return !writing && Input.GetMouseButton(0);
    }
}
