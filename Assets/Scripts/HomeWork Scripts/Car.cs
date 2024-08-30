using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car
{
    public string model;
    public string brand;
    public int year;
    public int age ;
    public int thisYear = 2024;

    public Car(string model, string brand, int year , int age)
    {
        this.model = model;
        this.brand = brand;
        this.year = year;
        this.age = age;
    }
}
