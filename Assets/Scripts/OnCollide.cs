using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnCollide : MonoBehaviour
{
    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;
    
    void Start()
    {

    }
  void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange=true;
            Debug.Log("Player in range of interactable");

       }
    }
void OnTriggerExit2D(Collider2D other)
    {
       if (other.CompareTag("Player"))
        {
            isInRange=false;
            Debug.Log("Player not in range");

        }
    }


    void Update()
    {
        if(isInRange)
        {
           
                interactAction.Invoke();
            
        }
    }
 
 
}
