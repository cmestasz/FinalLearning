using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefs.GetInt("volume") * 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeIn(float time)
    {
        StartCoroutine(FadeInCoroutine(time));
    }

    public void FadeOut(float time)
    {
        StartCoroutine(FadeOutCoroutine(time));
    }

    private IEnumerator FadeInCoroutine(float time)
    {
        audioSource.Play();
        audioSource.volume = 0;
        float speed = PlayerPrefs.GetInt("volume") * 0.01f / time;
        while (audioSource.volume < PlayerPrefs.GetInt("volume") * 0.01f)
        {
            audioSource.volume += speed * Time.deltaTime;
            yield return null;
        }
    }

    private IEnumerator FadeOutCoroutine(float time)
    {
        float speed = PlayerPrefs.GetInt("volume") * 0.01f / time;
        while (audioSource.volume > 0)
        {
            audioSource.volume -= speed * Time.deltaTime;
            yield return null;
        }
        audioSource.Stop();
    }
}
