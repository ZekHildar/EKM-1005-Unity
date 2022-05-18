using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
[System.Runtime.InteropServices.ComVisible(true)]

public class TechParameters
{
    public double InValue { get; set; }

    private double _OutValue;
    public double OutValue
    {
        get { return _OutValue; }
    }

    private double _Parameters;
    public double Parameters
    {
        get { return _Parameters; }
    }

    public void Calculus(float t)
    {
        _Parameters = InValue + (Mathf.Sin(9 * t) / 10);
        _OutValue = _Parameters;
    }
    public TechParameters()
    {
        InValue = 100;
    }
}

public class Sensor
{
    private double _MeasuredValue;
    public double MeasuredValue
    {
        get { return _MeasuredValue; }
    }

    public double LowerLimit { get; set; }
    public double UpperLimit { get; set; }

    public void Measure(double param)
    {
        if (param < LowerLimit) _MeasuredValue = LowerLimit;
        if (param > UpperLimit) _MeasuredValue = UpperLimit;
    }

    public Sensor()
    {
        LowerLimit = 95;
        UpperLimit = 105;
        _MeasuredValue = 100;
    }
}

public class MainParam : MonoBehaviour
{

}
