using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using Slider = UnityEngine.UI.Slider;

public class TasksClassWork : MonoBehaviour
{
    [SerializeField] int boilingTime = 4;
    [SerializeField] private Slider slider;
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
        MakeCoffee();
    }

    private async Task UpdateSliderAsync(float boilingDuration, CancellationToken token)
    {
        float elapsedTime = 0f;

        while (elapsedTime < boilingDuration)
        {
            if (token.IsCancellationRequested)
            {
                Debug.Log("Boiling canceled.");
                return; // Exit the task if canceled
            }

            elapsedTime += Time.deltaTime;
            float progress = Mathf.Clamp01(elapsedTime / boilingDuration); // Normalize progress
            slider.value = progress;

            await Task.Yield(); // This ensures the task yields control to the main thread

        }
        slider.value = 1f;
    }
    private async Task<string> BoilWater(int boilingTime , CancellationToken token)
    {
        Debug.Log("Filled kettle with water.");
        Debug.Log("Turned the kettle on.");

        try
        {
            Debug.Log("The water is being boiled, please wait...");
            await Task.Delay(boilingTime * 1000, token);
            return "The kettle is done, the water is boiling.";
        }
        
        catch (TaskCanceledException)
        {
            Debug.Log("Boiling canceled.");
            return "The kettle has turned off.";
        }
    }

    private async void MakeCoffee()
    {
        Debug.Log("Let's make coffee.");

        var boilingTask = BoilWater(boilingTime , _cancelToken.Token);
        var sliderTask = UpdateSliderAsync(boilingTime, _cancelToken.Token);
        
        await Task.WhenAny(boilingTask, sliderTask);
        Debug.Log("Drink coffee, enjoy async tasks.");
    }
  
}
