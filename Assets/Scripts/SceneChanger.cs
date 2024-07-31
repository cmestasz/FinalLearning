using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneChanger
{
    private static GameObject fade;
    public static IEnumerator ChangeScene(string scene)
    {
        fade = GameObject.Find("Fade");
        fade.GetComponent<Animator>().SetTrigger("Fading");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(scene);
    }
}