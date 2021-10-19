using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EnemyController : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    public bool isInRange;
    public bool breaksAnim;
    public bool pumpKin;
    public bool ghost;
    public bool skeleton;
    
    void Start(){
        rb = this.GetComponent<Rigidbody2D>();
    }

 void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange=true;
        }
        if (other.CompareTag("enemybarrier"))
        {
            isInRange=false;
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
        if (pumpKin){
            PumpKin();
        }
        if (ghost){
            Ghost();
        }
        if (skeleton){
            Skeleton();
        }
    }
    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }       
    private void FixedUpdate() 
    {
        moveCharacter(movement);
    }
 
    private void PumpKin()
    {
        if (isInRange)
            {
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            //rb.rotation = angle;
            direction.Normalize();
            movement = direction;
            }
    }
    private void Ghost(){

    }
    private void Skeleton(){

    }
}
