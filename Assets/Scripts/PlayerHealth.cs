using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public GameObject text;
    public RectTransform healthBar;
    public int health = 10;
    float sizeIncrement;

    private void Start() {
        sizeIncrement = healthBar.sizeDelta.x/health;
        text.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("enemy")||other.CompareTag("boss")){
            health -= 1;
            healthBar.sizeDelta -= new Vector2(sizeIncrement,0);
            if(health<=0){
                text.SetActive(true);
                health = 1000;
            }
        }
    }
}
