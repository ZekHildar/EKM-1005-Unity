using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PressureSensor : MonoBehaviour
{
    public GameObject Tube;
    public TMPro.TextMeshPro Text;
    public TMPro.TextMeshPro Text2;
    Sensor pressureSensor = new Sensor();
    public void Awake()
    {
        pressureSensor.AddUnits("kgf/cm^2", 0.0102, 0);
        pressureSensor.AddUnits("Ãœ‡", 0.001, 0);
        pressureSensor.AddUnits(" œ‡", 1, 0);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pressureSensor.Measure(Tube.GetComponent<Pipe>().pressure.Parameters);
        Debug.Log(pressureSensor.MeasuredValue);
        string DisplayedValue = pressureSensor.MeasuredValue.ToString().Substring(0, 5);
        string LowerDisp = pressureSensor.LowerLimit.ToString().Substring(0, 2);
        Text2.text = LowerDisp;
    }
}
