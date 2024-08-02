using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Format:

talker:dialogue
<<click
<<wait 0.25
<<end
*/


public static class DialogueBuilder
{
    public static IEnumerator WriteDialogue(DialogueBox dialogueBox, string dialogue)
    {
        string[] lines = dialogue.Split('\n');
        foreach (string line in lines)
        {
            if (line.StartsWith("<<click"))
            {
                yield return new WaitUntil(dialogueBox.CanWrite);
            }
            else if (line.StartsWith("<<wait"))
            {
                string[] parts = line.Split(' ');
                float waitTime = float.Parse(parts[1]);
                yield return new WaitUntil(dialogueBox.CanConsecutiveWrite);
                yield return new WaitForSeconds(waitTime);
            }
            else if (line.StartsWith("<<endforce"))
            {
                dialogueBox.CloseDialogue();
            }
            else if (line.StartsWith("<<end")) 
            {
                yield return new WaitUntil(dialogueBox.CanWrite);
                dialogueBox.CloseDialogue();
            }
            else
            {
                string[] parts = line.Split(':');
                dialogueBox.WriteDialogue(parts[0], parts[1]);
            }
        }
    }
}
