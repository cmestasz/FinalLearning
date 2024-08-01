using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClassroomManager : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Animator topicBanner;
    [SerializeField] private TMP_Text courseText;
    [SerializeField] private TMP_Text topicText;
    [SerializeField] private Vector3 classCenter;
    [SerializeField] private float cameraSpeed, zoomSpeed;

    void Start()
    {
        courseText.text = GlobalStorage.CourseData.courses[TowerData.course].name;
        topicText.text = GlobalStorage.CourseData.courses[TowerData.course].topics[ClassroomData.topic].name;

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
        while (Vector3.Distance(mainCamera.transform.position, classCenter) > 0.5f || Mathf.Abs(mainCamera.orthographicSize - 5) > 0.15f)
        {
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, classCenter, cameraSpeed * Time.deltaTime);
            mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, 5, zoomSpeed * Time.deltaTime);
            yield return new WaitForSeconds(0.01f);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
