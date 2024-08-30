using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CarPrinter : MonoBehaviour
{
    int thisYear = 2024;

    List<Car> carList = new List<Car>()
    {
        new Car("Toto", "Toyota", 1964, 0),
        new Car("HonHon", "Honda", 1956, 0),
        new Car("RealUglyCar", "Ugly", 1969, 0),
        new Car("Hewow", "BMW", 1955, 0),
        new Car("TheWaon", "Folkwagen", 1904, 0),
        new Car("WhtIsThisCar", "What", 1915, 0)
    };

    private void Start()
    {
        foreach (var car in carList) // calculate the age dynamically by calling the inside var age for each Car instance 
        { 
            car.age = thisYear - car.year;
        }

        carList = carList.OrderBy(Car => Car.age).ToList(); 

        foreach (var car in carList) // print the next item
        { 
            Debug.Log($"Car age: {car.age}, Car age: {car.brand}, Car age: {car.year}, Car age: {car.model}");
        }
    }
}
// how was the mission in extended easier then this?? I had so much trouble here!