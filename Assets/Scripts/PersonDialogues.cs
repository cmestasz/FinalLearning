using UnityEngine;

public static class PersonDialogues
{
    public static string[][] fixedDialogues = new string[][] {
        new string[] {
            "/name/:Las clases estan en cada puerta, asegurate de revisarlas una por una.",
            "<<click",
            "/name/:Cuando termines, ve al último piso.",
            "<<click",
            "/name/:Ahí encontrarás a alguien que verificará si estás listo para dar el curso por terminado.",
            "<<click",
            "/name/:Buena suerte!",
            "<<end"
        },
        new string[] {
            "/name/:...Las puertas que se encuentran a cada lado de la torre, con dos antorchas a cada lado.",
            "<<end"
        },
        new string[] {
            "/name/:.....Muevete directamente a la izquierda y un poco hacia arriba de donde estoy parado.",
            "<<end"
        },
        new string[] {
            "/name/:No tengo más información para darte.",
            "<<end"
        },
    };

    public static string[][] randomDialogues = new string[][] {
        new string[] {
            "/name/:Por qué todas las torres se ven iguales?",
            "<<click",
            "SISTEMA:Todas las torres son la misma torre.",
            "<<end"
        },
        new string[] {
            "/name/:Por qué los profesores cambian cada vez que entras a una clase?",
            "<<click",
            "SISTEMA:Es como si alguien fuera tan flojo como para no guardar el estado de los personajes.",
            "<<click",
            "SISTEMA:...O las torres, o las clases, o algo en este juego.",
            "<<click",
            "SISTEMA:De hecho, si se guardan los cursos y los temas.",
            "<<end"
        },
        new string[] {
            "/name/:Por qué los profesores no preguntan si estás listo para la clase?",
            "<<click",
            "SISTEMA:Imagina poder hacer un sistema de selección de diálogos.",
            "<<end"
        },
        new string[] {
            "/name/:No, no vas a encontrar ningún secreto aquí.",
            "<<end"
        },
        new string[] {
            "/name/:Por qué no hay más variedad en los diálogos?",
            "<<click",
            "SISTEMA:Porque no hay más variedad en los diálogos.",
            "<<end"
        },
        new string[] {
            "/name/:He escuchado que los profesores te encierran en la escena de clase hasta que hagas la clase.",
            "<<click",
            "SISTEMA:No quiero imaginar a alguien haciendo multiples peticiones a la API a propósito.",
            "<<end"
        },
        new string[] {
            "/name/:También he escuchado que los evaluadores te encierran en la escena de torre hasta que hagas la evaluación.",
            "<<click",
            "SISTEMA:No es mi culpa que los modelos de IA demoren tanto en responder.",
            "<<end"
        },
        new string[] {
            "/name/:Si vas al menú de configuración y subes tu velocidad al máximo, puedes atravesar las paredes.",
            "<<click",
            "SISTEMA:No lo hagas. (igualmente no puedes)",
            "<<end"
        },
        new string[] {
            "/name/:Deberías intentar salvar al pueblo en vez de hablar conmigo.",
            "<<end"
        },
        new string[] {
            "/name/:Si quieres hacer una clase de nuevo, sal y vuelve a entrar.",
            "<<end"
        },
        new string[] {
            "/name/:Si quieres hacer una evaluación de nuevo, pues no puedes.",
            "<<click",
            "SISTEMA:Las evaluaciones son una de las pocas cosas que se guardan en este juego.",
            "<<end"
        },
        new string[] {
            "/name/:No mires a los fuegos artificiales por mucho tiempo.",
            "<<click",
            "/name/:Hay muchas cosas de madera aquí...",
            "<<end"
        },
        new string[] {
            "/name/:Felicidades, encontraste un diálogo con 1/6 de probabilidad de aparecer.",
            "<<click",
            "SISTEMA:El que escribió este diálogo decidió aumentar más diálogos y no actualizar este.",
            "<<end"
        },
    };

    public static string GetDialogue(int index, string name)
    {
        if (index < fixedDialogues.Length)
        {
            return GetFixedDialogue(index, name);
        }
        else
        {
            return GetRandomDialogue(name);
        }
    }

    private static string GetFixedDialogue(int index, string name)
    {
        string[] dialogue = fixedDialogues[index];
        return FormatDialogue(name, dialogue);
    }

    private static string GetRandomDialogue(string name)
    {
        string[] dialogue = randomDialogues[Random.Range(0, randomDialogues.Length)];
        return FormatDialogue(name, dialogue);
    }

    private static string FormatDialogue(string name, string[] dialogue)
    {
        for (int i = 0; i < dialogue.Length; i++)
        {
            dialogue[i] = dialogue[i].Replace("/name/", name);
        }
        string dialogueString = string.Join("|||", dialogue);
        return dialogueString;
    }
}
