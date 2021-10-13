using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
       if (other.CompareTag("Player"))
        {
            if (other.gameObject.GetComponent<IsInvincible>().isInvincible){
                gameObject.SetActive(false);
            } else{
            other.gameObject.SetActive(false);
            }
        }
    }
}
