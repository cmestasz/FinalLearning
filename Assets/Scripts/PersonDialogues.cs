using UnityEngine;

public static class PersonDialogues
{
    public static string[][] dialogues = new string[][] {
        new string[] {
            "/name/:Por qué todas las torres se ven iguales?",
            "<<click",
            "SISTEMA:Todas las torres son la misma torre.",
            "<<click",
            "<<end"
        },
        new string[] {
            "/name/:Por qué los profesores cambian cada vez que entras a una clase?",
            "<<click",
            "SISTEMA:Es como si alguien fuera tan flojo como para no guardar el estado de los personajes.",
            "<<click",
            "<<end"
        },
        new string[] {
            "/name/:Por qué los profesores no preguntan si estás listo para la clase?",
            "<<click",
            "SISTEMA:Imagina poder hacer un sistema de selección de diálogos.",
            "<<click",
            "<<end"
        },
        new string[] {
            "/name/:No, no vas a encontrar ningún secreto aquí.",
            "<<click",
            "<<end"
        },
        new string[] {
            "/name/:Por qué no hay más variedad en los diálogos?",
            "<<click",
            "SISTEMA:Porque no hay más variedad en los diálogos.",
            "<<click",
            "<<end"
        },
        new string[] {
            "/name/:Felicidades, encontraste un diálogo con 1/6 de probabilidad de aparecer.",
            "<<click",
            "SISTEMA:(Habían tan pocos?)",
            "<<click",
            "<<end"
        },
    };

    public static string GetRandomDialogue(string name)
    {
        string[] dialogue = dialogues[Random.Range(0, dialogues.Length)];
        for (int i = 0; i < dialogue.Length; i++)
        {
            dialogue[i] = dialogue[i].Replace("/name/", name);
        }
        string dialogueString = string.Join("\n", dialogue);
        return dialogueString;
    }
}
