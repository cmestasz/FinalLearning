using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworkController : MonoBehaviour
{
    [SerializeField] private float duration;
    [SerializeField] private float interval;
    [SerializeField] private AudioClip start, end;
    private AudioSource audioSource;
    private ParticleSystem mainSystem;

    // Start is called before the first frame update
    void Start()
    {
        mainSystem = GetComponent<ParticleSystem>();
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(Explode());
    }

    // Update is called once per frame
    void Update()
    {
    }

    private IEnumerator Explode()
    {
        while (true)
        {
            yield return new WaitForSeconds(duration);
            audioSource.clip = end;
            audioSource.Play();
            yield return new WaitForSeconds(interval);
            mainSystem.Play();
            audioSource.clip = start;
            audioSource.Play();
        }
    }
}
