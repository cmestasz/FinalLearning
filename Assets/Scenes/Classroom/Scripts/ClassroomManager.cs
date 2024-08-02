using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

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

    void Start()
    {
        StartCoroutine(FetchResponse());
        courseText.text = GlobalStorage.GetCourse();
        topicText.text = GlobalStorage.GetTopic();
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
        yield return new WaitForSeconds(3);
        yield return EndClass();
    }

    private IEnumerator EndClass()
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
        while (Vector3.Distance(mainCamera.transform.position, targetPos) > 0.5f || Mathf.Abs(mainCamera.orthographicSize - targetSize) > 0.15f)
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
        WWWForm form = new();
        form.AddField("course", GlobalStorage.GetCourse());
        form.AddField("topic", GlobalStorage.GetTopic());

        UnityWebRequest request = UnityWebRequest.Post("http://localhost:5000/classData", form);
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.Success)
        {
            string response = request.downloadHandler.text;
            Response res = JsonUtility.FromJson<Response>(response);
            Debug.Log(res.answer);
        }
        else
        {
            Debug.Log(request.error);
        }
    }

    public void NextPage()
    {
        Debug.Log("Next Page");
    }

    public void PrevPage()
    {
        Debug.Log("Prev Page");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private class Response
    {
        public string answer;
    }
}
