using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class callSceneTransition : MonoBehaviour
{
    public KeyCode interactKey;
    public LayerController lc;
    public bool isInRange;
    public int sceneNumToCall;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange=true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
       if (other.CompareTag("Player"))
        {
            isInRange=false;
        }
    }


    void Update()
    {
        if(isInRange)
        {
            if(Input.GetKeyDown(KeyCode.Alpha0))
            {
                lc.TransitionByNum(0);
            }
            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                lc.TransitionByNum(1);
            }
            if(Input.GetKeyDown(KeyCode.Alpha2))
            {
                lc.TransitionByNum(2);
            }
        }
    }
}
