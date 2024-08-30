using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    int currentCapacity;
    int maxCapacity = 10;
    bool active = false;

    int currentFloor;
    int targetFloor;
    int clickedFloor;
    List<int> floorsClicked = new List<int> { 1 ,3 , 5};

    bool IsElevatorActive(int currentCapacity, int maxCapacity , bool active)
    {
        Debug.Log("Checking if elevator is active...");
        if (maxCapacity >= currentCapacity)
        {
            active = true;
            Debug.Log($"Elevator is active");
        }
        else
        {
            active = false;
            Debug.Log($"Elevator is not active");
        }
        return active;
    }
    int isClicked( List<int> floorsClicked , int currentFloor ,int clickedFloor, int targetFloor) //calculated target floor convert clicked to target, remove previous floor and sort ro calculate target.
    {
        //add clicked floor to list
        floorsClicked.Add(clickedFloor);
        Debug.Log($"Clicked floor is {clickedFloor}");
        Debug.Log($"floors clicked count= {floorsClicked.Count}");


        //set previous floor and remove from list, sort list, set target
        floorsClicked.Remove(currentFloor);
        floorsClicked.Sort();

        for (int i = 0; i < floorsClicked.Count; i++) 
        {
            Debug.Log(floorsClicked[i]);
        }

        floorsClicked[0] = targetFloor;
        Debug.Log($"Next floor is {targetFloor}");

        return targetFloor;
    }
    //static elevatorMovment() 
    //{ 
    //}

    void Start()
    {
        IsElevatorActive(3, maxCapacity, active);
        if (active)
        {
            isClicked(floorsClicked, 1, 8, 3);
        }
    }
}