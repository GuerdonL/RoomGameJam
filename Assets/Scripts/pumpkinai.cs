using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class pumpkinai : MonoBehaviour{
    private Transform player;
    public float moveSpeed = .5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    public bool isInRange;
    public Vector3 originalPos;

       void Start()
       {
        originalPos = gameObject.transform.position;
        rb = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectsWithTag("Player")[0].transform;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
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
        Vector3 direction;
        //transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.y);
        if (isInRange)
        {
            direction = Vector3.Normalize(player.position-transform.position);
            //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            //rb.rotation = angle;
            direction.Normalize();
            movement = new Vector2(direction.x, direction.y);
        }
        /*else
        {
            direction = originalPos - transform.position;
            //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            direction.Normalize();
            movement = new Vector2(direction.x, direction.y);
        }*/
        //transform.position += new Vector3(movement.x,movement.y,0)*moveSpeed*Time.deltaTime;
    }

        
    private void FixedUpdate() {
        moveCharacter(movement);
    }
    void moveCharacter(Vector2 dir){
        rb.MovePosition((Vector2)transform.position + (dir * moveSpeed));
    }
}