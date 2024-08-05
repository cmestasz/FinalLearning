using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public static class APIManager
{
    public static IEnumerator PostRequest(string url, Dictionary<string, string> data, Action<string> callback)
    {
        WWWForm form = new();
        foreach (KeyValuePair<string, string> entry in data)
        {
            form.AddField(entry.Key, entry.Value);
        }
        UnityWebRequest www = UnityWebRequest.Post(url, form);
        www.timeout = 60;
        yield return www.SendWebRequest();
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            callback(www.downloadHandler.text);
        }
    }
}
