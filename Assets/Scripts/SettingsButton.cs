using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsButton : MonoBehaviour
{
    public GameObject layout; 
    public bool clicked = true;
    public void Close()
    {
        
        layout.gameObject.SetActive(clicked);
        clicked = !clicked;
    }
       
}
