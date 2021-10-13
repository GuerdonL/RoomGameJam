using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerControl : MonoBehaviour
{
    public Text text;
    private float time=50;
    public GameObject player;
    public bool win = false;
    private void Start() {
        text.text = "time";
        
    }

    public void Update(){
        if (win==false){
        time -= Time.deltaTime;
        text.text = time + "";
        if(time<=0){
            player.SetActive(false);
        }
        if(!player.activeSelf){
            text.text =  "You have died. Try again.";
        }
        }
        else{
            text.text = "You Win!";
        }
    }

}
