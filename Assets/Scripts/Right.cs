using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right : MonoBehaviour
{
    public Animator anim;
    void OnMouseDown()
        {
        anim.SetTrigger("Click");
            Debug.Log ("Clicked");
        }
}
