using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IfsAndSwitches : MonoBehaviour
{
    int num = 4;
    int num1 = 2;

    //Create a method that accepts an integer, operates it and prints out the result.
    static int calculator(int num, int num1)
    {
        num *= num1;
        Debug.Log(num);
        Debug.Log(num1);
        return num;
    }
    
    //Create a method that accepts an integer, with an if statement about this integer.
    static int ifCalculator(int num, int num1)
    {
        num = num * num1;
        if (num > 0)
        {
            Debug.Log($"{num} > 0");
        }
        else if (num == 0) 
        {
            Debug.Log($"{num} = 0");
        }
        else
        {
            Debug.Log($"{num} < 0");
        }
        return num;
    }

    //Create a method that accepts an integer, with a switch statement with 3 cases about this integer. Print something in the cases.
    void MySwitch( int num)
    {
        switch(num)
        {
            case 2:
                Debug.Log($"it's a {num}!");
                break;

            case 4:
                Debug.Log($"it's a {num}!");
                break;

            case 8:
                Debug.Log($"it's a {num}!");
                break;

            default:
                Debug.Log("default");
                break;
        }
    }

     void Start()
     {
        calculator(2, 4);
        ifCalculator(1, 4);
        MySwitch(num);
     }
}


