using System.Collections;
using UnityEngine;

public class LightController : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(StartLight());
    }

    private IEnumerator StartLight()
    {
        yield return new WaitForSeconds(Random.Range(0.0f, 5.0f));
        animator.SetTrigger("Start");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
