using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class TasksClassWork : MonoBehaviour
{
    async void DoShit()
    {
        Debug.Log("Kusememememmmccccc");
    }
    
    // Start is called before the first frame update
    public void async Start()
    {
        await Task.DoShit()(1000);
    }

    // Update is called once per frame
     async void Update()
    {
        
    }
}
