using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnInteract : MonoBehaviour
{
    public GameObject pressE;
    public List<GameObject> dialogue;
    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;
    private int index = 0;
    
    void Start()
    {
        pressE.SetActive(false);
        foreach (GameObject go in dialogue){
            go.SetActive(false);
        }
    }
  void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("but triggered");
        if (other.CompareTag("Player"))
        {
            isInRange=true;
            pressE.SetActive(true);
            //Debug.Log("Player in range of interactable");

       }
    }
void OnTriggerExit2D(Collider2D other)
    {
       if (other.CompareTag("Player"))
        {
            isInRange=false;
            pressE.SetActive(false);
            //Debug.Log("Player not in range");

        }
    }


    void Update()
    {
        if(isInRange)
        {
            if(Input.anyKeyDown)
            {
                if(dialogue.Count!=0 && dialogue.Count != index){
                    dialogue[index].SetActive(true);
                    index++;
                } else if (Input.GetKeyDown(interactKey)){
                    interactAction.Invoke();
                }
            }
        }
    }
 
 
}
