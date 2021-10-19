using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossArenaAnimController : MonoBehaviour
{
    public float animLength = 2;
    public GameObject solidArena;
    private bool waiting;
    void Start()
    {
        waiting = true;
        solidArena.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(waiting){
            if(animLength>0){
                animLength-=Time.deltaTime;
            }
            else{
                solidArena.SetActive(true);
                gameObject.GetComponent<Animator>().enabled = false;
            }
        }
    }
}
