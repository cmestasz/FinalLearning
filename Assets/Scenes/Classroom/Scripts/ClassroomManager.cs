using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClassroomManager : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Animator topicBanner;
    [SerializeField] private TMP_Text courseText;
    [SerializeField] private TMP_Text topicText;
    [SerializeField] private Vector3 classCenter;
    [SerializeField] private GameObject classContainer;
    [SerializeField] private DialogueBox dialogueBox;
    public static bool classDone;
    [SerializeField] private TMP_Text pageText;
    private string[] classPages;
    private int pageIdx = -1;
    public bool classLoaded = false;
    private AudioSource audioSource;

    void Start()
    {
        classDone = false;
        StartCoroutine(FetchResponse());
        courseText.text = GlobalStorage.GetCurrentCourse();
        topicText.text = GlobalStorage.GetCurrentTopic().name;
        audioSource = GetComponent<AudioSource>();
    }

    public void StartClass()
    {
        StartCoroutine(StartClassCoroutine());
    }

    private IEnumerator StartClassCoroutine()
    {
        topicBanner.SetBool("isVisible", false);
        PlayerController.canMove = false;
        audioSource.Play();
        mainCamera.GetComponent<CameraController>().isFollowingPlayer = false;
        yield return StartCoroutine(MoveResizeCamera(classCenter, 2.5f));
        classContainer.SetActive(true);
        yield return new WaitForSeconds(2);
        NextPage();
    }

    private IEnumerator EndClassCoroutine()
    {
        classContainer.GetComponent<Animator>().SetTrigger("ClassEnded");
        Vector3 playerPos = player.transform.position;
        playerPos.z = mainCamera.transform.position.z;
        classDone = true;
        yield return StartCoroutine(MoveResizeCamera(playerPos, 8));
        PlayerController.canMove = true;
        mainCamera.GetComponent<CameraController>().isFollowingPlayer = true;
        topicBanner.SetBool("isVisible", true);
        yield return DialogueBuilder.WriteDialogue(dialogueBox, "SISTEMA:Puedes acercarte al profesor para realizar cualquier pregunta.|||<<end", true);
    }

    private IEnumerator MoveResizeCamera(Vector3 targetPos, float targetSize)
    {
        float cameraSpeed = Vector3.Distance(mainCamera.transform.position, targetPos);
        float zoomSpeed = Mathf.Abs(mainCamera.orthographicSize - targetSize);
        while (Vector3.Distance(mainCamera.transform.position, targetPos) > 25e-3 || Mathf.Abs(mainCamera.orthographicSize - targetSize) > 25e-3)
        {
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, targetPos, cameraSpeed * Time.deltaTime);
            mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, targetSize, zoomSpeed * Time.deltaTime);
            yield return new WaitForSeconds(0.01f);
        }
        mainCamera.transform.position = targetPos;
        mainCamera.orthographicSize = targetSize;
    }

    private IEnumerator FetchResponse()
    {

        void callback(Pages res)
        {
            Debug.Log(res.courses);
            classPages = res.courses;
            classLoaded = true;
        }

        Dictionary<string, string> data = new()
        {
            { "course", GlobalStorage.GetCurrentCourse() },
            { "topicName", GlobalStorage.GetCurrentTopic().name },
            { "topicDescription", GlobalStorage.GetCurrentTopic().description }
        };

        yield return APIManager.PostRequest<Pages>("courses", data, callback);
    }

    public void NextPage()
    {
        pageIdx = (pageIdx + 1) % classPages.Length;
        pageText.text = FormatPage(classPages[pageIdx]);
    }

    public void PrevPage()
    {
        pageIdx = (pageIdx - 1 + classPages.Length) % classPages.Length;
        pageText.text = FormatPage(classPages[pageIdx]);
    }

    public void EndClass()
    {
        StartCoroutine(EndClassCoroutine());
    }

    private string FormatPage(string page)
    {
        string res = "<b>" + (pageIdx + 1) + "/" + classPages.Length + "</b>\n";
        res += page;
        return res;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private class Pages
    {
        public string[] courses;
    }
}
