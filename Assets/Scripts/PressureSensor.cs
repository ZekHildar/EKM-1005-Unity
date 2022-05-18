using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureSensor : MonoBehaviour
{
    public GameObject Tube;
    Sensor pressureSensor = new Sensor();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //pressureSensor.Measure(Tube.GetComponent<Tube>())
    }
}
