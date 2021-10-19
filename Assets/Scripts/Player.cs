using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Transform trans;
    private Rigidbody2D body;
    public float moveSpeed=5f;
    Vector2 movement;
    // Start is called before the first frame update
    private void Start() {
        trans=gameObject.transform;
        body=gameObject.GetComponent<Rigidbody2D>();
    }



    // Update is called once per frame
    void Update()
    {
    MovementInput();
    }

    void MovementInput()
    {
    float mx=Input.GetAxisRaw("Horizontal");
    float my=Input.GetAxisRaw("Vertical");
    movement=new Vector2(mx, my).normalized;
    }
    
    void FixedUpdate() {
       // if (cango){
    body.MovePosition(body.position+movement* moveSpeed *Time.fixedDeltaTime);
  //  }
   // else
   // {}
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //hit detected         
    }
    }


//transform.position.y+moveVector.y*speed* Time.deltaTime));
/*
private void OnTriggerEnter2D(Collider2D other)
    {
            if (other.tag == "Activator")
            {
                canGo = true;

            }
    }
    */





 





