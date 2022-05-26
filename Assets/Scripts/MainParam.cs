using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
        _Parameters = InValue + 10f*(Mathf.Sin(0.1f*t));
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

    public string[] GetSupportedUnits()
    {
        int UnitsCount = _supportedUnits.Count;
        string[] _out = new string[UnitsCount];
        int i = 0;
        foreach (var u in _supportedUnits)
        {
            _out[i] = u.Key;
            i++;
        }
        return _out;
    }

    public void Measure(double param)
    {
        _MeasuredValue = Math.Round(param, 2);
        if (param < LowerLimit) _MeasuredValue = Math.Round(LowerLimit,2);
        if (param > UpperLimit) _MeasuredValue = Math.Round(UpperLimit, 2);
        if (_units == "ÊÏà") _MeasuredValue = _MeasuredValue * _supportedUnits[_units].k + _supportedUnits[_units].b;
        else if (_units == "kgf/cm^2") _MeasuredValue = Math.Round((_MeasuredValue * _supportedUnits[_units].k + _supportedUnits[_units].b), 4);
        else _MeasuredValue = Math.Round((_MeasuredValue * _supportedUnits[_units].k + _supportedUnits[_units].b), 4);
        if (LowerLimit > UpperLimit) LowerLimit = UpperLimit;
        if (UpperLimit < LowerLimit) UpperLimit = LowerLimit; //test

    }

    public Sensor()
    {
        LowerLimit = 50d;
        UpperLimit = 150;
        _MeasuredValue = 100d;
    }
}

public class MainParam : MonoBehaviour
{
    
}
