using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackCap : MonoBehaviour
{
    public Animator anim;
    public bool b_opened;
    void OnMouseDown()
        {
            if (!b_opened)
            {
                anim.SetTrigger("Open");
                b_opened = true;
            }
            else
            {
                anim.SetTrigger("Close");
                b_opened = false;
            }
            Debug.Log ("Clicked");
        }
}
