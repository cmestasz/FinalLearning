using System;
using System.Collections;
using UnityEngine;

public static class DialogueBuilder
{
    public static IEnumerator WriteDialogue(DialogueBox dialogueBox, string dialogue, bool priority)
    {
        if (!dialogueBox.CanConsecutiveWrite())
        {
            if (priority)
            {
                Debug.Log("Priority dialogue override");
                dialogueBox.CloseDialogue();
            }
            else
            {
                Debug.Log("Dialogue box is busy");
                yield break;
            }
        }

        string[] lines = dialogue.Split("|||");
        foreach (string line in lines)
        {
            if (line.StartsWith("<<click"))
            {
                yield return new WaitUntil(dialogueBox.CanWrite);
            }
            else if (line.StartsWith("<<timewait"))
            {
                string[] parts = line.Split(' ');
                float waitTime = float.Parse(parts[1]);
                yield return new WaitUntil(dialogueBox.CanConsecutiveWrite);
                yield return new WaitForSeconds(waitTime);
            }
            else if (line.StartsWith("<<forceend"))
            {
                dialogueBox.CloseDialogue();
            }
            else if (line.StartsWith("<<end"))
            {
                yield return new WaitUntil(dialogueBox.CanWrite);
                dialogueBox.CloseDialogue();
            }
            else if (line.StartsWith("<<inputstart"))
            {
                dialogueBox.EnableInput();
            }
            else if (line.StartsWith("<<inputend"))
            {
                yield return new WaitUntil(dialogueBox.InputDone);
                dialogueBox.SaveInput();
                dialogueBox.DisableInput();
            }
            else
            {
                int idx = line.IndexOf(':');
                string talker = line[..idx];
                string diag = line[(idx + 1)..];
                dialogueBox.WriteDialogue(talker, diag);
            }
        }
    }
}
