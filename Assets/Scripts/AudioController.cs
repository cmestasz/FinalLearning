using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<AudioSource>().volume = PlayerPrefs.GetInt("volume") * 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
