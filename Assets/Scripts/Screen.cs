using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen : MonoBehaviour
{
    public Object Left, Right, Central;
    public Animator buttons;
    
    void OnMouseDown()
        {
            buttons.SetTrigger("Click");
            Debug.Log("CLICKED!");
        }
}