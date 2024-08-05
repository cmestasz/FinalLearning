using System.Collections;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    private DialogueBox dialogueBox;
    private Animator animator;
    private AudioSource audioSource;
    private string[] dialogues = {
        "Tú:Desde que tengo memoria, nuestro pueblo vivió en paz bajo la protección de mi maestro. Él vencía con facilidad todos los peligros que nos acechaban. Sin embargo, como predijo, un día fatídico estaba por venir. Cuando me adoptó como su discípulo, me advirtió que mi misión sería derrotarlo, pues un cambio inevitable se avecinaba. Ese oscuro día llegó antes de lo esperado: el mago brujo, con un solo hechizo, venció a mi maestro y poseyó su cuerpo.",
        "<<click",
        "Tú:Sin haber completado mi entrenamiento, no tuve más opción que huir hacia el bosque, siguiendo las palabras de mi maestro, quien me aseguró que allí encontraría ayuda. Tras dos días de travesía, descubrí un misterioso fortín que parecía abandonado. Sin dudarlo, entré en busca de alimento, pero, encontré algo más que solo eso.",
        "<<click",
        "Tú:Por dentro, parecía no estar abandonado, habían mesas y libros e incluso antorchas que iluminaban el lugar. Y luego pude verlos a ellos, la leyenda que me contó mi maestro era cierta, eran ellos, los guardianes son reales...",
        "<<end"
    };

    // Start is called before the first frame update
    void Start()
    {
        dialogueBox = GetComponentInChildren<DialogueBox>();
        audioSource = GetComponent<AudioSource>();
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
        yield return DialogueBuilder.WriteDialogue(dialogueBox, string.Join("|||", dialogues), true);

        audioSource.Play();
        animator.SetTrigger("FadeOut");
    }
}
