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
    [SerializeField] private float cameraSpeed, zoomSpeed;
    public bool classDone = false;
    [SerializeField] private TMP_Text pageText;
    private string[] classPages;
    private int pageIdx = -1;

    void Start()
    {
        StartCoroutine(FetchResponse());
        courseText.text = GlobalStorage.GetCourse();
        topicText.text = GlobalStorage.GetTopic().name;
    }

    public void StartClass()
    {
        StartCoroutine(StartClassCoroutine());
    }

    private IEnumerator StartClassCoroutine()
    {
        topicBanner.SetBool("isVisible", false);
        player.canMove = false;
        mainCamera.GetComponent<CameraController>().isFollowingPlayer = false;
        yield return StartCoroutine(MoveResizeCamera(classCenter, 5));
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
        player.canMove = true;
        mainCamera.GetComponent<CameraController>().isFollowingPlayer = true;
        topicBanner.SetBool("isVisible", true);
    }

    private IEnumerator MoveResizeCamera(Vector3 targetPos, float targetSize)
    {
        while (Vector3.Distance(mainCamera.transform.position, targetPos) > 0.15f || Mathf.Abs(mainCamera.orthographicSize - targetSize) > 0.15f)
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

        void callback(string response)
        {
            Debug.Log(response);
            Pages res = JsonUtility.FromJson<Pages>(response);
            Debug.Log(res.pages);
            classPages = res.pages;
        }

        Dictionary<string, string> data = new()
        {
            { "course", GlobalStorage.GetCourse() },
            { "topicName", GlobalStorage.GetTopic().name },
            { "topicDescription", GlobalStorage.GetTopic().description }
        };

        yield return APIManager.PostRequest("http://localhost:5000/classData", data, callback);
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
        public string[] pages;
    }
}
