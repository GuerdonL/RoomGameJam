using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    public TimerControl timerScript;
    void OnTriggerEnter2D(Collider2D other)
    {
       if (other.CompareTag("Player"))
        {
            timerScript.win = true;
        }
    }
}
