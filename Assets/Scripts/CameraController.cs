using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float cameraDelay;
    [SerializeField] private Transform player;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 cameraDest = new(player.position.x, player.position.y, transform.position.z);
        Vector3 cameraPos = Vector3.Lerp(transform.position, cameraDest, cameraDelay * Time.deltaTime);

        transform.position = cameraPos;
    }
}
