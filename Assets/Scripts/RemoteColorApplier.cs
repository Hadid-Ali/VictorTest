using System;
using System.Text;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class RemoteColorApplier : ColorApplierBase,IColorMediatorComponent
{
    [SerializeField] private string _apiURL = "http://localhost:8000/color";
    [SerializeField] private int _requestTimeOutDuration = 10;
    
    private void Start()
    {
        StartCoroutine(FetchAndApplyColor());
    }

    void IColorMediatorComponent.ApplyColorStyle(Color color)
    {
        StartCoroutine(PostColorToServer(color));
    }

    private IEnumerator PostColorToServer(Color color)
    {
        Debug.Log($"Sending Color {color}");
        ColorDataEntity entity = new()
        {
            r = Mathf.RoundToInt(color.r),
            g = Mathf.RoundToInt(color.g),
            b = Mathf.RoundToInt(color.b),
            a = color.a
        };
        
        string json = JsonUtility.ToJson(entity);

        var request = new UnityWebRequest(_apiURL, "POST");
        byte [] dataset = Encoding.UTF8.GetBytes(json);
        
        request.uploadHandler = new UploadHandlerRaw(dataset);
        request.downloadHandler = new DownloadHandlerBuffer();
        
        request.SetRequestHeader("Content-Type", "application/json");
        request.timeout = _requestTimeOutDuration;

        yield return request.SendWebRequest();
        
        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(request.error);
            yield break;
        }
        
        Debug.Log("Color Sent Successfully, Please Reset Color Play the Editor to Test");
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
