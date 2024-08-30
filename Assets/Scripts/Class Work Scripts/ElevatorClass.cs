using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Elevator : MonoBehaviour
    {
        int currentCapacity;
        int maxCapacity = 10;
        bool active;

        bool isElevatorActive(int currentCapacity, int maxCapacity)
        {
            Debug.Log("Checking if elevator is active...");
            if (maxCapacity >= currentCapacity)
            {
                active = true;
                Debug.Log($"Elevator is active");
            }
            else if (maxCapacity < currentCapacity)
            {
                active = false;
                Debug.Log($"Elevator is not active");
            }
            return active;
        }

        void Start()
        {
            Debug.Log("dd");
            isElevatorActive(8, maxCapacity, active);
        }

    }
