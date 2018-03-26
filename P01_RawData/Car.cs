using System;
using System.Collections.Generic;
using System.Text;


public class Car
{
    public string model;
    public int engineSpeed;
    public int enginePower;
    public int cargoWeight;
    public string cargoType;
    public Tires[] tires;

    public Car(string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType,Tires[] tires)
    {
        this.model = model;
        this.engineSpeed = engineSpeed;
        this.enginePower = enginePower;
        this.cargoWeight = cargoWeight;
        this.cargoType = cargoType;
        this.tires = tires;
    }
    
}

