using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventSystem : MonoBehaviour
{
    public GameObject SensorObject;
    public InputField UpperBound;
    public InputField LowerBound;
    public Dropdown UnitsDD;
    // Start is called before the first frame update
    void Start()
    {
        Sensor sensor = SensorObject.GetComponent<PressureSensor>().pressureSensor;
        LowerBound.text = sensor.LowerLimit.ToString();
        UpperBound.text = 150.ToString();
        Debug.Log(UpperBound.text);

        UnitsDD.ClearOptions();
        string[] supportedUnits = sensor.GetSupportedUnits();

        for (int i=0; i<supportedUnits.Length; i++)
        {
            UnitsDD.options.Add(new Dropdown.OptionData { text = supportedUnits[i] });
            if (supportedUnits[i] == sensor.Units)
                UnitsDD.value = i;
        }
        sensor.Units = UnitsDD.options[UnitsDD.value].text;
    }
    public void ChangeUnits()
    {
        Sensor sensor = SensorObject.GetComponent<PressureSensor>().pressureSensor;
        sensor.Units = UnitsDD.options[UnitsDD.value].text;
    }
    public void ChangeBounds()
    {
        Sensor sensor = SensorObject.GetComponent<PressureSensor>().pressureSensor;
        double convertedValue;
        double.TryParse(LowerBound.text, out convertedValue);
        sensor.LowerLimit = convertedValue;
        double.TryParse(UpperBound.text, out convertedValue);
        sensor.UpperLimit = convertedValue;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
