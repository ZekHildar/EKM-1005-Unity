using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PressureSensor : MonoBehaviour
{
    public GameObject Tube;
    public TMPro.TextMeshPro Text;
    public TMPro.TextMeshPro LOWB_TEXT;
    public TMPro.TextMeshPro UPPB_TEXT;
    public TMPro.TextMeshPro kpaText;
    public TMPro.TextMeshPro mpaText;
    public TMPro.TextMeshPro kgfText;

    public Sensor pressureSensor = new Sensor();
    public void Awake()
    {
        pressureSensor.AddUnits(" œ‡", 1, 0);
        pressureSensor.AddUnits("kgf/cm^2", 0.0102, 0);
        pressureSensor.AddUnits("Ãœ‡", 0.001, 0);
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pressureSensor.Measure(Tube.GetComponent<Pipe>().pressure.Parameters);
        //Debug.Log(pressureSensor.MeasuredValue);
        string DisplayedValue = pressureSensor.MeasuredValue.ToString().Substring(0);
        Text.text = DisplayedValue;
        string LowerDisp = pressureSensor.LowerLimit.ToString().Substring(0);
        LOWB_TEXT.text = LowerDisp;
        string UpperDisp = pressureSensor.UpperLimit.ToString().Substring(0);
        UPPB_TEXT.text = UpperDisp;
        if (pressureSensor.Units == " œ‡")
        {
            kpaText.gameObject.SetActive(true);
            mpaText.gameObject.SetActive(false);
            kgfText.gameObject.SetActive(false);
        }
        else if (pressureSensor.Units == "Ãœ‡")
        {
            mpaText.gameObject.SetActive(true);
            kgfText.gameObject.SetActive(false);
            kpaText.gameObject.SetActive(false);
        }
        else
        {
            mpaText.gameObject.SetActive(false);
            kgfText.gameObject.SetActive(true);
            kpaText.gameObject.SetActive(false);
        }

    }
}
