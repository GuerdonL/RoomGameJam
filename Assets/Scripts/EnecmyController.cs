/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnecmyController : MonoBehaviour
{
    public GameObject player;
    public bool breaksAnim;
    public bool pumpKin;
    public bool ghost;
    public bool skeleton;

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
    private void PumpKin(){
        //precompute our ray settings
        Vector3 start = transform.position;
        Vector3 direction = (player.transform.position - transform.position).normalized;
        float distance = detectionOptions.detectionRange;
    
        //draw the ray in the editor
        Debug.DrawRay(start,direction,distance,Color.Red);
 
        //do the ray test
        RaycastHit2D sightTest = Physics2D.Raycast(start,  direction, distance);
        if (sightTest.collider != null) 
        {
            if (sightTest.collider.gameObject != gameObject)
            {
                finalDetected = null;
                Debug.Log ("Rigidbody collider is: " + sightTest.collider);
            }
        }
    }
    private void Ghost(){

    }
    private void Skeleton(){

    }
}
*/