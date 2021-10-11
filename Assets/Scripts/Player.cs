using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform trans;
    public Rigidbody2D body;
    public float moveSpeed=5f;
    Vector2 movement;
    // Start is called before the first frame update




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
           

                Debug.Log("hit detected");

         
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





 





