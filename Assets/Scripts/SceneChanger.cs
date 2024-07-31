using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneChanger
{
    public static void ChangeScene(string sceneName)
    {
       SceneManager.LoadScene(sceneName);
    }
}
