using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left : MonoBehaviour
{
    public Animator anim;
    Sensor pressureSensor = new Sensor();
    void OnMouseDown()
        {
        anim.SetTrigger("Click");
            Debug.Log ("Clicked");
        }
}
