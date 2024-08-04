using System.Collections;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    private DialogueBox dialogueBox;
    private Animator animator;
    private string[] dialogues = {
        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam euismod congue pharetra. Suspendisse nibh justo, fermentum a sem eget, congue maximus eros. In eget euismod leo. Donec eu leo bibendum, luctus justo ut, viverra ligula. Etiam lobortis, urna ut eleifend fermentum, velit lectus iaculis nisi, a condimentum eros lorem ut lectus. Sed scelerisque nisi vitae pharetra volutpat. Sed vestibulum finibus elit vitae placerat. Etiam imperdiet nec ante eu rhoncus. Sed aliquet elit nisi. Nulla facilisi. Maecenas vel gravida eros. Sed scelerisque euismod scelerisque. Proin euismod dapibus nibh vitae finibus. Donec tincidunt tristique ex sed euismod. ",
        "Morbi aliquam cursus nibh, ac vestibulum massa bibendum in. Fusce posuere convallis consequat. Morbi a accumsan nunc. Nullam accumsan ligula vel volutpat auctor. Nulla facilisi. Cras eleifend libero ac magna porttitor, vel aliquam diam gravida. Sed iaculis est ac eros tempus imperdiet. Donec sit amet interdum dui. Ut dui felis, hendrerit vitae ornare et, elementum et nisl. Suspendisse quis ultricies massa, non pretium lorem. Vivamus et nisi erat. ",
        "Phasellus lacinia urna eu elit tincidunt venenatis. Nullam vel lacus mollis, tempor ante nec, finibus enim. Suspendisse venenatis dolor nec purus eleifend, malesuada congue quam rutrum. Donec nisi arcu, porttitor sed viverra sed, ultricies ut diam. Donec vulputate justo tellus, et euismod sem hendrerit in. Aenean leo augue, tincidunt ut turpis non, viverra dictum ante. Vestibulum dignissim eu enim ac volutpat. Quisque fringilla ante lorem, nec ultrices metus aliquam id. Suspendisse potenti. Duis non nibh vel sem semper mattis. Curabitur nunc nisl, dignissim eget cursus in, commodo sed ante. Interdum et malesuada fames ac ante ipsum primis in faucibus. "
    };

    // Start is called before the first frame update
    void Start()
    {
        dialogueBox = GetComponentInChildren<DialogueBox>();
        animator = GetComponent<Animator>();
        PlayerPrefs.SetInt("Intro", 0);
        if (PlayerPrefs.GetInt("Intro") == 0)
        {
            PlayerPrefs.SetInt("Intro", 1);
            PlayerPrefs.Save();
            StartCoroutine(PlayIntro());
        } else 
        {
            gameObject.SetActive(false);
        }

    }

    private IEnumerator PlayIntro()
    {
        yield return new WaitForSeconds(1f);
        foreach (string dialogue in dialogues)
        {
            dialogueBox.WriteDialogue("...", dialogue);
            yield return new WaitUntil(dialogueBox.CanWrite);
        }

        animator.SetTrigger("FadeOut");
    }
}
