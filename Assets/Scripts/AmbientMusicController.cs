using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientMusicController : MonoBehaviour
{
    public static GameObject instance;
    
    void Start()
    {
        if (instance == null)
        {
            instance = gameObject;
            DontDestroyOnLoad(gameObject);
            GetComponent<AudioController>().FadeIn(1);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
