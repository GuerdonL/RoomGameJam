using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    public int health = 3;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("bullet")){
            health-=1;
            if(health<=0){
                Destroy(gameObject);
            }
        }
    }
}
