using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cap : MonoBehaviour
{
    public Animator anim;
    void OnMouseDown()
        {
        anim.SetTrigger("Open");
            Debug.Log ("Clicked");
        }
}
