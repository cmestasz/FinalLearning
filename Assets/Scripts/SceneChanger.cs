using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneChanger
{
    private static GameObject fade;
    public static IEnumerator ChangeScene(string scene, Transform player, Vector3 dest)
    {
        fade = GameObject.Find("Fade");
        PlayerController.canMove = false;
        fade.GetComponent<Animator>().SetTrigger("Fading");
        yield return MovePlayer(player, dest);
        SceneManager.LoadScene(scene);
    }

    public static IEnumerator ChangeScenePlayerless(string scene)
    {
        fade = GameObject.Find("Fade");
        fade.GetComponent<Animator>().SetTrigger("Fading");
        PlayerController.canMove = false;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(scene);
    }

    public static void PanicChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    private static IEnumerator MovePlayer(Transform player, Vector3 dest)
    {
        float speed = Vector3.Distance(player.position, dest);
        while (Vector3.Distance(player.position, dest) > 10e-3)
        {
            player.position = Vector3.MoveTowards(player.position, dest, speed * Time.deltaTime);
            yield return null;
        }
    }
}