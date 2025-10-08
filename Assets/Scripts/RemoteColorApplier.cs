using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class RemoteColorApplier : ColorApplierBase
{
    [SerializeField] private string _apiURL = "http://localhost:8000/color";
    [SerializeField] private int _requestTimeOutDuration = 10;

    private void Start()
    {
        StartCoroutine(FetchAndApplyColor());
    }

    private IEnumerator FetchAndApplyColor()
    {
        Debug.Log($"Sent request at {_apiURL}");
        var request = UnityWebRequest.Get(_apiURL);

        request.timeout = _requestTimeOutDuration;
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(request.error);
            yield break;
        }
        
        string jsonResult = request.downloadHandler.text;
        ColorDataEntity colorData = JsonUtility.FromJson<ColorDataEntity>(jsonResult);
        
        ApplyColor(colorData.GetColor());
        Debug.Log($"Applied {colorData} on cube");
    }
}
