using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField]
    int currentCapacity;
    int maxCapacity = 10;
    bool active = false;

    int currentFloor;
    int targetFloor;
    [SerializeField] 
    private int clickedFloor;


    bool isElevatorActive(int currentCapacity, int maxCapacity , bool active)
    {
        Debug.Log("Checking if elevator is active...");
        if (maxCapacity > currentCapacity)
        {
            active = true;
            Debug.Log($"Elevator is active");
        }
        else if (maxCapacity < currentCapacity)
        {
            active = false;
            Debug.Log($"Elevator is not active");
            Debug.Log($"Current capacity exceeds the maximum.");

        }
        return active;
    }

    int isClicked(int currentFloor ,int clickedFloor, int targetFloor)
    {
        List<int> floorsClicked = new List<int> { 1 , 3 , 5 };

        floorsClicked.Add(clickedFloor);
        Debug.Log($"Clicked floor is {clickedFloor}");
        floorsClicked.Remove(currentFloor);
        Debug.Log($"Floors in clicked = {floorsClicked.Count}");
        floorsClicked.Sort();

        for (int i = 0; i < floorsClicked.Count; i++)
        {
            Debug.Log($"Floor { floorsClicked[i]}");
        }
            targetFloor = floorsClicked[0];
            Debug.Log($"Next floor is {targetFloor}");

        return targetFloor;
    }
    //static elevatorMovment() 
    //{ 
    //}

    void Start()
    {
        isElevatorActive(currentCapacity, maxCapacity, active);
        Debug.Log($"before if, active is:{active}");
        if (isElevatorActive)
        {
            isClicked(1,clickedFloor, 3);
        }
        else //active not transferin delete this after test
        {
            Debug.Log("Elevator is out of order");
            isClicked(1,clickedFloor, 3);
        }
    }
}