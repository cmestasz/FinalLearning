using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndController : MonoBehaviour
{
    [SerializeField] private DialogueBox dialogueBox;
    [SerializeField] private AudioSource musicAudioSource;
    private string endDialogue;

    // Start is called before the first frame update
    void Start()
    {
        string[] dialogue = new string[]
        {
            "El autor:Gracias por jugar. Esta es una pequeña experiencia para demostrar el uso de la API de inteligencia artificial de Vercel (pero ya sabes eso no?)",
            "<<click",
            "El autor:Si quieres saber más sobre el proyecto, puedes visitar el repositorio en GitHub.",
            "<<click",
            "El autor:Si quieres jugar de nuevo, puedes reiniciar el juego (aunque no lo he probado completamente, así que no sé si funcionará).",
            "<<click",
            "El autor:Si llegaste hasta aca, que paciencia, no?",
            "<<click",
            "El autor:Sin mucho más que decir,",
            "<<click",
            "El autor:Hecho con esmero por<br>Luis Sequeiros (@gusCreator)<br>Christian Mestas (@cmestasz)<br>Yenaro Noa (@ynoacamino)<br>Mariel Jara (@Alsnj20)<br>Álvaro Quispe (@ALVARO-QUISPE-UNSA)<br>Jhonatan Arias (@JhonatacDczel)<br>Ricardo Chambilla (@rikich3)<br>Diego Carbajal (@Gocardi)",
            "<<end",
        };
        endDialogue = string.Join("|||", dialogue);
        EndGame();
    }

    public void EndGame()
    {
        gameObject.SetActive(true);
        StartCoroutine(EndGameCoroutine());
    }

    private IEnumerator EndGameCoroutine()
    {
        PlayerController.canMove = false;
        yield return new WaitForSeconds(3);
        musicAudioSource.Play();
        yield return DialogueBuilder.WriteDialogue(dialogueBox, endDialogue, true);
        yield return new WaitForSeconds(2);
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
