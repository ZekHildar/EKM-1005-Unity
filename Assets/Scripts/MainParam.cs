using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    Dictionary<string, (double k, double b)> _supportedUnits = new Dictionary<string, (double k, double b)>();

    public void AddUnits(string UnitName, double _k, double _b)
    {
        _supportedUnits.Add(UnitName, (_k, _b));
    }

    private string _units;

    public string Units
    {
        get { return _units; }
        set
        {
            if (_supportedUnits.ContainsKey(value))
                _units = value;
            else _units = DefaultUnits;
        }
    }
    public string DefaultUnits { get; set; }

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
