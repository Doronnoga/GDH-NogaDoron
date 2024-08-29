using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IfsAndSwitches : MonoBehaviour
{
    int num = 4;
    int num1 = 2;
    int sum; //do I have to declare sum here for the script to work?

    static int calculator( int num, int num1)
    {
        num *= num1;
        Debug.Log(num);
        Debug.Log(num1);
        return num;
    }

    void MySwitch( int num)
    {
        switch(num)
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

    static void Start()
    {
        Debug.Log("bla");
        calculator(num, num1);
        
        
    }
}
