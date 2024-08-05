using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public static class APIManager
{
    private const string BASE_URL = "https://knowledge-wardens.vercel.app/api/ai/";
    private const string TEST_URL = "http://localhost:5000/";
    public static IEnumerator PostRequest<T>(string url, Dictionary<string, string> data, Action<T> callback, bool test)
    {
        WWWForm form = new();
        foreach (KeyValuePair<string, string> entry in data)
        {
            form.AddField(entry.Key, entry.Value);
        }
        UnityWebRequest www = UnityWebRequest.Post((test ? TEST_URL : BASE_URL) + url, form);
        www.timeout = 60;
        yield return www.SendWebRequest();
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
            SceneChanger.PanicChangeScene("Error");
        }
        else
        {
            try
            {
                T res = JsonUtility.FromJson<T>(www.downloadHandler.text);
                callback(res);
            }
            catch (Exception e)
            {
                Debug.Log(e);
                SceneChanger.PanicChangeScene("Error");
            }
        }
    }
}
