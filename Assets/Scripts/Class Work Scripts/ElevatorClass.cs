using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField]
    int currentCapacity;
    int maxCapacity = 10;

    bool capacityLimitOkay;
    bool fucntionalOkay;
    bool active = false;

    [SerializeField]
    int currentFloor;
    int targetFloor = 3;

    [SerializeField] 
    int clickedFloor;

    [SerializeField]
    int sinceCheck;
    int maxMaintnanceDays = 80;

    bool maintnanceCheck() 
    {
        if (maxMaintnanceDays > sinceCheck)
        {
            fucntionalOkay = true;
            Debug.Log($"{sinceCheck} days since last checked.");

        }
        else if (maxMaintnanceDays < sinceCheck)
        {
            fucntionalOkay = false;
            Debug.Log($"{sinceCheck} days since last checked.");
            Debug.Log("Elevator is past due maintnance, please contact your supplier.");
        }

        return fucntionalOkay;
    }
    bool checkCapacity()
    {
        if (maxCapacity >= currentCapacity)
        {
            capacityLimitOkay = true;
        }
        else if (maxCapacity < currentCapacity)
        {
            capacityLimitOkay = false;
            Debug.Log($"Current capacity exceeds the maximum.");

        }
        return capacityLimitOkay;
    }
    bool isActive() 
    { 
        maintnanceCheck();
        checkCapacity();
        if (capacityLimitOkay && fucntionalOkay)
        {
            active = true;
            Debug.Log("Elevator is active.");
        }
        else 
        { 
            active = false;
            Debug.Log("Elevator is deactivated.");
        }
        return active;

    }
    int isClicked(int currentFloor ,int clickedFloor, int targetFloor)
    {
        List<int> floorsClicked = new List<int> { 2 , 3 , 5 };

        floorsClicked.Add(clickedFloor);
        Debug.Log($"Clicked floor is {clickedFloor}");
        floorsClicked.Remove(currentFloor);
        Debug.Log($"There are {floorsClicked.Count} floors in queue.");
        floorsClicked.Sort();

        for (int i = 0; i < floorsClicked.Count; i++)
        {
            Debug.Log($"Floor { floorsClicked[i]}");
        }

        if (clickedFloor < targetFloor)
        {
            Debug.Log($"Next floor is {targetFloor}");
        }
        else if(clickedFloor == targetFloor)
        {
            Debug.Log($"This is floor {targetFloor}, please disembark or choose again.");
        }
        else
        {
            targetFloor = floorsClicked[0];
            Debug.Log($"Next floor is {targetFloor}");
        }
            

        return targetFloor;
    }
    

    void Start()
    {
        isActive();
        if (active)
        {
            isClicked(currentFloor, clickedFloor, targetFloor);
        }
        else
        {
            Debug.Log("Elevator is out of order");
        }
    }
}