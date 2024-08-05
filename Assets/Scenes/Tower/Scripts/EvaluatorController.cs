using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvaluatorController : AnyCharacterController, IKeyInteractable
{
    [SerializeField] private DialogueBox dialogueBox;
    [SerializeField] private UnityEngine.GameObject fireworks;
    [SerializeField] private EndController endController;
    [SerializeField] private PlayerController player;
    private string[] questions;
    private string[] answers;
    private bool[] results;
    private string[] correct;
    private bool questionsLoaded = false;
    private bool fetching = false;
    public static bool blockLeave;

    public IEnumerator Interact()
    {
        if (GlobalStorage.IsCourseDone())
        {
            yield return DialogueBuilder.WriteDialogue(dialogueBox, $"{characterName}:Ya has demostrado que sabes lo necesario.\n<<end", true);
            yield break;
        }

        if (!questionsLoaded)
        {
            if (!fetching)
                FetchQuestions();
            yield return DialogueBuilder.WriteDialogue(dialogueBox, $"{characterName}:Espera un momento, estoy cargando las preguntas.\n<<end", true);
            yield break;
        }

        yield return PerformTest();
    }

    private IEnumerator PerformTest()
    {
        PlayerController.canMove = false;

        List<string> dialogue = new()
            {
                $"{characterName}:Crees saber lo que es necesario?",
                "<<click",
                $"{characterName}:Vamos a ver si puedes responder a estas preguntas.",
                "<<click"
            };

        foreach (string question in questions)
        {
            dialogue.Add($"{characterName}:{question}");
            dialogue.Add("<<click");
            dialogue.Add("<<inputstart");
            dialogue.Add("<<inputend");
        }
        dialogue.Add($"{characterName}:Dame un momento para revisar tus respuestas.");
        dialogue.Add("<<end");

        string dialogueString = string.Join("\n", dialogue);
        yield return DialogueBuilder.WriteDialogue(dialogueBox, dialogueString, true);

        answers = dialogueBox.GetInputs();
        dialogueBox.ClearInputs();
        yield return ValidateAnswers();

        dialogue = new();
        int correctCount = 0;
        for (int i = 0; i < correct.Length; i++)
        {
            if (results[i])
                correctCount++;
            string corr = results[i] ? "Correcto" : "Incorrecto";
            dialogue.Add($"{characterName}:{questions[i]}<br>{correct[i]}<br><b>{corr}</b>");
            dialogue.Add("<<click");
        }
        dialogue.Add($"{characterName}:Has respondido correctamente a {correctCount} de {questions.Length} preguntas.");
        dialogue.Add("<<click");
        bool hasWon = correctCount >= questions.Length * 2 / 3;
        if (hasWon)
        {
            dialogue.Add($"{characterName}:Bien hecho! Has demostrado que sabes lo que necesitas.");
            GlobalStorage.SetCourseDone();
        }
        else
        {
            dialogue.Add($"{characterName}:Entonces, eres invesil? (Sigue intentando).");
        }
        dialogue.Add("<<end");

        dialogueString = string.Join("\n", dialogue);
        yield return DialogueBuilder.WriteDialogue(dialogueBox, dialogueString, true);
        if (hasWon)
        {
            if (GlobalStorage.AreAllCoursesDone())
                endController.EndGame();
            else
                fireworks.SetActive(true);
        }
        blockLeave = false;
        PlayerController.canMove = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        blockLeave = false;
        ChooseNameSprite();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator ValidateAnswers()
    {
        void callback(Results res)
        {
            results = res.results;
            correct = res.correct;
        }

        Dictionary<string, string> data = new()
        {
            { "questions", string.Join("^^^", questions) },
            { "answers", string.Join("^^^", answers) }
        };

        yield return APIManager.PostRequest<Results>("responses", data, callback, false);
    }

    private void FetchQuestions()
    {
        StartCoroutine(FetchQuestionsCoroutine());
    }

    private IEnumerator FetchQuestionsCoroutine()
    {
        void callback(Questions res)
        {
            questions = res.questions;
            questionsLoaded = true;
        }

        Dictionary<string, string> data = new()
        {
            { "course", GlobalStorage.GetCurrentCourse() },
            { "topicName", GlobalStorage.GetCurrentTopic().name },
            { "topicDescription", GlobalStorage.GetCurrentTopic().description }
        };

        blockLeave = true;
        fetching = true;
        yield return APIManager.PostRequest<Questions>("questions", data, callback, false);
    }

    private class Results
    {
        public bool[] results;
        public string[] correct;
    }

    private class Questions
    {
        public string[] questions;
    }
}
