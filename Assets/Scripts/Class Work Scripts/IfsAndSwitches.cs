using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IfsAndSwitches : MonoBehaviour
{
    int num = 1;
    int num1 = 2;
    int sum;
    


    static int calculator( int num, int num1, int sum)
    {
        sum = num * num1;
        return sum;
    }

    void MySwitch( int sum)
    {
        switch(sum)
        {
            case 1:
                Debug.Log("1");
                break;

            case 2:
                Debug.Log("2");
                break;

            case 3:
                Debug.Log("3");
                break;

            default:
                Debug.Log("default");
                break;
        }
    }

    void Start()
    {
        Debug.Log(sum);
        
    }
}
