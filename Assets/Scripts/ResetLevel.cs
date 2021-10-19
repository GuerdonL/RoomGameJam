using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ResetLevel : MonoBehaviour
{
    public LayerController lc;
    public GameObject text;
    public Camera cam2;
    public float endCameraScale;
    public float moveSpeed;
    public Transform cameraOverlook;
    private Vector3 camPosition;
    private Vector3 dir;
    private Aimer aimer;
    private Camera cam;
    private bool deleting = false;
    private bool camera = true;
    private SwitchInteract[] switchLights;
    private float totalDistance;
    private float begginingCameraScale;
    void Start()
    {
        text.SetActive(false);
        cam2.enabled = false;
        
        GameObject[] temp = GameObject.FindGameObjectsWithTag("SwitchBraziers");
        switchLights = new SwitchInteract[temp.Length];
        for(int i = 0; i < temp.Length; i++){
            switchLights[i]=temp[i].GetComponent<SwitchInteract>();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            aimer = other.gameObject.GetComponent<Aimer>();
            cam =  aimer.cam;
            camPosition = cam.transform.position;
            begginingCameraScale = cam.orthographicSize;
            cameraOverlook.position = new Vector3(cameraOverlook.position.x, cameraOverlook.position.y, camPosition.z);
            dir = new Vector3(cameraOverlook.position.x-camPosition.x, cameraOverlook.position.y-camPosition.y, 0);
            totalDistance = dir.magnitude;
            dir = Vector3.Normalize(dir);                            
            aimer.enabled = !(deleting=ActiveLights());
        }
    }

    private bool disabling = false;
    private float waitBetweenLights = .2f;
    private float currentWait = .2f;
    private int currentLight = 0;
    private void Update() {
        if(deleting){
            
            if(camera){
                //if(IterateCamera(1, cameraOverlook.position)){
                    cam.enabled = false;
                    cam2.enabled = true;
                    camera = false;
                    disabling = true;
                    waitBetweenLights = .2f;
                    currentWait = waitBetweenLights;
                    currentLight = 0;
                //}
            }
            else if(disabling){
                currentWait-=Time.deltaTime;
                if(currentWait<=0){
                    if(!ActiveLights()||switchLights.Length==0){
                        disabling = false;
                    }
                    else{
                        switchLights[currentLight].flipped = false;
                        currentLight++;
                    }
                }
            }
            else{
                //if(IterateCamera(-1, camPosition)){
                    deleting = false;
                    aimer.enabled = true;
                    cam2.enabled=false;
                    cam.enabled = true;
                    text.SetActive(true);
                    lc.TransitionByNum(0);
                    lc.switchesFlipped = 0;
                    lc.BossLevel();
                //}
            }
        }
    }
    private bool ActiveLights(){
        foreach(SwitchInteract light in switchLights){
            if(light.flipped){
                return true;
            }
        }
        return false;
    }
}
