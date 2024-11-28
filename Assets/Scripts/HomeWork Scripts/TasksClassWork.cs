using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Serialization;
using Slider = UnityEngine.UI.Slider;

public class TasksClassWork : MonoBehaviour
{
    [SerializeField] int waitTime;
    [SerializeField] string fileName;
    [SerializeField] private int loadPart;
    [SerializeField] private Slider slider;
    private List<Task<string>> taskList;
    private CancellationTokenSource _cancelToken = new CancellationTokenSource();

    public void OnClickCancel()
    {
        Debug.Log("Click Cancel");
        _cancelToken.Cancel();
        slider.value = 0;
    }

    public void OnClickStartTask()
    {
        Debug.Log("Click Start");
        _cancelToken.Cancel();
        _cancelToken = new CancellationTokenSource(); 
        LoadAllFiles();
    }

    private async Task UpdateSliderAsync(float waitTime, int loadTime, CancellationToken token)
    {
        float elapsedTime = loadTime;

        while (elapsedTime < waitTime)
        {
            if (token.IsCancellationRequested)
            {
                Debug.Log("Loading canceled.");
                return;
            }

            elapsedTime += Time.deltaTime;
            float progress = Mathf.Clamp01(elapsedTime / waitTime); 
            slider.value = progress;

            await Task.Yield();

        }
        slider.value = 1f;
    }
    private async Task<string> Fileloader(int waitTime , string fileName, int loadPart, CancellationToken token)
    {
        Debug.Log($"started loading file with name {fileName}.");
        try
        {
            Debug.Log($"{fileName}, is loading please wait...");
            await Task.Delay(waitTime * 1000, token);
            return $"{fileName} is done loading.";
        }
        
        catch (TaskCanceledException)
        {
            Debug.Log("Loading canceled.");
            return "The Loading has been turned off.";
        }
    }

    private void CycleThroughList()
    {
        taskList = new List<Task<string>>
        {
            Fileloader(3, "MyFile", loadPart, _cancelToken.Token),
            Fileloader(4, "DoNotOpen", loadPart, _cancelToken.Token),
            Fileloader(5, "GroceryList", loadPart, _cancelToken.Token),
            Fileloader(2, "PrivateBussinessFile", loadPart, _cancelToken.Token),
            Fileloader(1, "NOtes", loadPart, _cancelToken.Token),
        };
    }

    private async void LoadAllFiles()
    {
        Debug.Log("Let's load all files:");

        var boilingTask = Fileloader(waitTime ,"PrivateFile", 1, _cancelToken.Token);
        var sliderTask = UpdateSliderAsync(waitTime, loadPart, _cancelToken.Token);
        
        await Task.WhenAny(boilingTask, sliderTask);
        Debug.Log("All Files have been loaded.");
    }
  
}
