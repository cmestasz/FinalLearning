using System.Collections;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    private DialogueBox dialogueBox;
    private Animator animator;
    private string[] dialogues = {
        "Te adentras cada noche en el bosque tranquilo que rodea tu pequeño pueblo. Eres parte de un grupo de aprendices determinados a liberar a su maestro, quien ha sido aprisionado por una entidad maligna antigua que se hace llamar el 'mago brujo'. Durante el día, te ves forzado a escuchar las enseñanzas de este ser oscuro, pero tu corazón y tu mente permanecen fieles a tu verdadero maestro. Sientes la urgencia de liberarlo, pero sabes que la tarea no será fácil.",
        "En tu búsqueda nocturna, te enfrentas a un desafío aún mayor que la simple liberación de tu maestro. Te das cuenta de que para vencer al mago brujo, primero debes enfrentarte a los temibles conocimientos que poseen juntos, tanto tu maestro como el villano. El mago brujo ha declarado que solo dejará en paz a tu maestro si es vencido por estos conocimientos combinados. La tarea parece abrumadora, y a menudo te preguntas si tú y tus compañeros aprendices estarán a la altura del desafío.",
        "Sin embargo, en una de tus expediciones nocturnas, descubres algo que renueva tu esperanza. Te encuentras con los antiguos guardianes del conocimiento, seres misteriosos y sabios que habitan en lo más profundo del bosque. Estos guardianes, impresionados por tu determinación y la de tus compañeros, prometen ayudarte en tu tarea de vencer al mago brujo. Con este nuevo aliado, sientes que la balanza comienza a inclinarse a tu favor. Ahora, con renovada energía y determinación, te preparas para el desafío final, sabiendo que el destino de tu maestro y posiblemente el del pueblo entero, depende de ti y de tus compañeros aprendices..."
    };

    // Start is called before the first frame update
    void Start()
    {
        dialogueBox = GetComponentInChildren<DialogueBox>();
        animator = GetComponent<Animator>();
        // PlayerPrefs.SetInt("Intro", 0);
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
