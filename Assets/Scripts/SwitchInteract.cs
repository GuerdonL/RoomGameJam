using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchInteract : MonoBehaviour
{
     public GameObject text;
    public bool flipped = false;
    public bool called = false;
    //---------------------------------------------
    public GameObject red;
    public Collider2D interactRadius;
    public int triggerableFromLayer;
    public int layerToTrigger;
    public LayerController lc;
    private bool inRange = false;
    private void Start() {
        red.SetActive(false);
        text.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            inRange = true;
        }
    }
    private void Update() {
        if(!flipped){
            red.SetActive(false);
        }
        if(inRange){
            if(Input.GetKeyDown(KeyCode.E)){
                if(lc.GetLayer()==triggerableFromLayer){
                    lc.TransitionByNum(layerToTrigger);
                    flipped=true;
                    red.SetActive(true);
                    //Debug.Log(red.activeSelf);
                    try{
                        if(called){
                            text.SetActive(true);
                            lc.switchesFlipped+=1;
                            lc.BossLevel();
                        }
                        
                        //flipped=true;
                    }catch{/*Debug.Log("error");*/}
                }
                /*else if(lc.GetLayer()!=triggerableFromLayer&&!red.activeSelf){
                    lc.Trannsition
                }*/
            }
        }
    }
}
