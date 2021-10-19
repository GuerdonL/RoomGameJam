using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
       if (other.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);//decrement player health
        }
        else if(other.CompareTag("bullet")){
            gameObject.SetActive(false);//decrement enemy health
        };
    }
}
